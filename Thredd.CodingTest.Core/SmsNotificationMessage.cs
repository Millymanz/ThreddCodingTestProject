using Microsoft.Extensions.Logging;
using System;
using Thredd.Codingtest.Core.Interfaces;
using Thredd.Codingtest.Core.Services;


namespace Thredd.Codingtest.Core
{
    public class SmsNotificationMessage : INotificationMessage
    {
        private readonly SmsService smsService;

        private readonly ILogger<SmsNotificationMessage> _logger;

        public SmsNotificationMessage(ILogger<SmsNotificationMessage> logger)
        {
            _logger = logger;

            smsService = new SmsService();
        }

        public bool Send(NotificationEvent notificationEvent, out string error)
        {
            bool result = false;
            error = string.Empty;

            try
            {
                if (!smsService.IsServiceRunning())
                {
                    error = "Service is currently not running";
                    return false;
                }

                _logger.LogInformation("Sending SMS to {Recipient}", notificationEvent.To);

                result = smsService.Send(notificationEvent.To, notificationEvent.From, notificationEvent.Message);
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