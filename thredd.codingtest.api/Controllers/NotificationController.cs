using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thredd.codingtest.core;
using thredd.codingtest.core.Models;
using thredd.codingtest.core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace thredd.codingtest.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        public NotificationController()
        {
        }

        [HttpPost]
        public async Task<IActionResult> SendNotification([FromBody] NotificationEvent notificationEvent)
        {
            var message = CheckType(notificationEvent);
            var result = message.send(notificationEvent, out var errormessage);

            if (!result)
            {
                return BadRequest(errormessage);
            }

            return Ok("Message Sent");
        }

        [HttpGet]
        [Route("status/{id}")]
        public async Task<IActionResult> GetStatus([FromRoute] Guid id)
        {
            return Ok(StatusService.GetStatus(id));
        }

        private INotificationMessage CheckType(NotificationEvent notificationEvent)
        {
            if (notificationEvent.NotificationType == "Sms")
            {
                return new SmsNotificationMessage();
            }
            else
            {
                return new EmailNotificationMessage();
            }
        }
    }
}
