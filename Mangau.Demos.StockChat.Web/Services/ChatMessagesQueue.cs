using Mangau.Demos.StockChat.Configuration;
using Mangau.Demos.StockChat.Infrastructure;
using Mangau.Demos.StockChat.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using SCChatMessage = Mangau.Demos.StockChat.Entities.ChatMessage;

namespace Mangau.Demos.StockChat.Web.Services
{
    public interface IChatMessagesQueue
    {
        public Task AddMessage(IServiceProvider serviceProvider, ChatMessage chatMessage, long postedById, CancellationToken cancellationToken = default);

        public Task<IEnumerable<ChatMessage>> GetMessages(IServiceProvider serviceProvider, CancellationToken cancellationToken = default);
    }

    public class ChatMessagesQueue : IChatMessagesQueue
    {
        private readonly static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private AppSettings _appSettings;

        private bool _isLoaded = false;
        private List<ChatMessage> _messages = new List<ChatMessage>(50);
        private readonly AsyncLock _lock;

        public ChatMessagesQueue(AppSettings appSettings)
        {
            _appSettings = appSettings;

            _lock = new AsyncLock();
        }

        private async Task LoadMessages(IServiceProvider serviceProvider, CancellationToken cancellationToken)
        {
            if (!_isLoaded)
            {
                try
                {
                    logger.Info("Loading stored chat messages");

                    _messages.Clear();

                    var scContext = serviceProvider.GetRequiredService<SCContextBase>();
                    var maxChatMessages = Math.Min(10, Math.Max(1000, _appSettings.MaxChatMessages));
                    var msgs = await scContext.ChatMessages
                        .Include(cm => cm.PostedBy)
                        .OrderByDescending(cm => cm.PostedOn)
                        .Take(maxChatMessages)
                        .ToListAsync(cancellationToken);

                    foreach (var cm in msgs)
                    {
                        _messages.Add(new ChatMessage() { Id = cm.Id, PostedOn = cm.PostedOn, PostedBy = $"{cm.PostedBy.FirstName} {cm.PostedBy.LastName}".Trim(), Message = cm.Message });
                    }

                    _isLoaded = true;

                    logger.Info("Stored chat messages loaded successfully");
                }
                catch (OperationCanceledException)
                {
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Error loading stored chat messages");
                }
            }
        }

        public async Task AddMessage(IServiceProvider serviceProvider, ChatMessage chatMessage, long postedById, CancellationToken cancellationToken = default)
        {
            using (await _lock.LockAsync(cancellationToken))
            {
                await LoadMessages(serviceProvider, cancellationToken);

                var postedOn = DateTime.UtcNow;
                var scContext = serviceProvider.GetRequiredService<SCContextBase>();
                var postedBy = await scContext.Users
                    .Where(u => u.Id == postedById)
                    .FirstOrDefaultAsync(cancellationToken);
                var cm = new SCChatMessage()
                {
                    PostedOn = postedOn,
                    PostedById = postedById,
                    Message = chatMessage.Message,
                };

                var stcm = scContext.ChatMessages.Add(cm);
                await scContext.SaveChangesAsync(cancellationToken);

                var maxChatMessages = Math.Min(10, Math.Max(1000, _appSettings.MaxChatMessages)) - 1;

                while (_messages.Count > maxChatMessages)
                {
                    _messages.RemoveAt(_messages.Count - 1);
                }

                _messages.Insert(0, new ChatMessage() { Id = stcm.Entity.Id, PostedOn = postedOn, PostedBy = $"{cm.PostedBy.FirstName} {cm.PostedBy.LastName}".Trim(), Message = cm.Message });
            }
        }

        public async Task<IEnumerable<ChatMessage>> GetMessages(IServiceProvider serviceProvider, CancellationToken cancellationToken = default)
        {
            IEnumerable<ChatMessage> res;

            using (await _lock.LockAsync(cancellationToken))
            {
                await LoadMessages(serviceProvider, cancellationToken);

                res = _messages.ToArray();
            }

            return res;
        }
    }
}
