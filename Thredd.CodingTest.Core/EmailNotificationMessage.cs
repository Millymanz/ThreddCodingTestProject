using Microsoft.Extensions.Logging;
using System;
using Thredd.Codingtest.Core.Interfaces;
using Thredd.Codingtest.Core.Services;

namespace Thredd.Codingtest.Core
{
    public class EmailNotificationMessage : INotificationMessage
    {
        private readonly EmailService emailService;

        private readonly ILogger<EmailNotificationMessage> _logger;

        public EmailNotificationMessage(ILogger<EmailNotificationMessage> logger)
        {
            _logger = logger;

            emailService = new EmailService();
        }

        public bool Send(NotificationEvent notificationEvent, out string error)
        {
            bool result = false;
            error = string.Empty;

            try
            {
                if (!emailService.IsServiceRunning())
                {
                    error = "Service is currently not running";
                    return false;
                }

                _logger.LogInformation("Sending Email to {Recipient}", notificationEvent.To);

                result = emailService.Send(notificationEvent.To, notificationEvent.From, notificationEvent.Title, notificationEvent.Message);
            }
            catch (Exception e)
            {
                error = e.Message;
            }

            _logger.LogError("Error occurred: {ErrorMessage}", error);

            return result;
        }
    }
}