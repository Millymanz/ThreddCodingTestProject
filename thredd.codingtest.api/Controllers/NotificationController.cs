using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thredd.Codingtest.Core;
using Thredd.Codingtest.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thredd.Codingtest.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Thredd.Codingtest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly StatusService _statusService;

        private readonly ILogger<NotificationController> _logger;
        private readonly NotificationMessageFactory _notificationMessageFactory;

        public NotificationController(ILogger<NotificationController> logger, NotificationMessageFactory notificationMessageFactory, StatusService statusService)
        {
            _logger = logger;
            _statusService = statusService;
            _notificationMessageFactory = notificationMessageFactory;
        }

        [HttpPost]
        public IActionResult SendNotification([FromBody] NotificationEvent notificationEvent)
        {
            _logger.LogInformation("Sending Notification");

            var message = _notificationMessageFactory.CreateNotificationMessage(notificationEvent.NotificationType);
            var result = message.Send(notificationEvent, out var errormessage);

            if (!result)
            {
                return BadRequest(errormessage);
            }
            _statusService.AddStatus(notificationEvent.Id, "Notification Sent");

            _logger.LogInformation("Notification sent successfully");

            return Ok("Message Sent");
        }

        [HttpGet]
        [Route("status/{id}")]
        public IActionResult Status([FromRoute] Guid id)
        {
            _logger.LogInformation("Fetching status for Id: {Id}", id);

            return Ok(_statusService.GetStatus(id));
        }
    }
}
