using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Mangau.Demos.StockChat.Infrastructure;
using Mangau.Demos.StockChat.Web.Models;
using Mangau.Demos.StockChat.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Mangau.Demos.StockChat.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public MessagesController()
        {
        }

        [HttpPost()]
        public async Task<IActionResult> AddMessage([FromBody] ChatMessage chatMessage, [FromServices] IChatMessagesQueue messages, CancellationToken cancellationToken)
        {
            var surname = User.FindFirst(c => c.Type == ClaimTypes.Surname);

            if (surname != null)
            {
                if (Int64.TryParse(surname.Value, out long userId))
                {
                    await messages.AddMessage(HttpContext.RequestServices, chatMessage, userId, cancellationToken);

                    return Ok();
                }

                return BadRequest();
            }

            return Forbid();
        }

        [HttpGet]
        public async Task<IActionResult> GetMessages([FromServices] IChatMessagesQueue messages, CancellationToken cancellationToken)
        {
            return Ok(await messages.GetMessages(HttpContext.RequestServices, cancellationToken));
        }
    }
}
