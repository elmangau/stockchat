using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mangau.Demos.StockChat.Web.Services
{
    public class QueuedHostedBackgroundServicev : BackgroundService
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public QueuedHostedBackgroundServicev(IBackgroundTaskQueue taskQueue)
            : base()
        {
            TaskQueue = taskQueue;
        }

        public IBackgroundTaskQueue TaskQueue { get; }

        protected async override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            logger.Info("Queued Background Tasks Service is starting.");

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var workItem = await TaskQueue.DequeueAsync(cancellationToken);

                    try
                    {
                        await workItem(cancellationToken);
                    }
                    catch (OperationCanceledException)
                    {
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex, $"Error occurred executing {nameof(workItem)}.");
                    }
                }
                catch (OperationCanceledException)
                {
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Error occurred executing task.");
                }
            }

            logger.Info("Queued Background Tasks Service is stopping.");
        }
    }
}
