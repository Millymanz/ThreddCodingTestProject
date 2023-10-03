using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thredd.Codingtest.Core;
using Thredd.Codingtest.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thredd.Codingtest.Core.Interfaces;

namespace Thredd.Codingtest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly StatusService _statusService;

        [HttpPost]
        public IActionResult SendNotification([FromBody] NotificationEvent notificationEvent)
        {
            var message = NotificationMessageFactory.CreateNotificationMessage(notificationEvent.NotificationType);
            var result = message.Send(notificationEvent, out var errormessage);

            if (!result)
            {
                return BadRequest(errormessage);
            }

            return Ok("Message Sent");
        }

        [HttpGet]
        [Route("status/{id}")]
        public IActionResult Status([FromRoute] Guid id)
        {
            return Ok(_statusService.GetStatus(id));
        }
    }
}
