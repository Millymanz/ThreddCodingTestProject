using System;
using Thredd.Codingtest.Core.Interfaces;
using Thredd.Codingtest.Core.Services;

namespace Thredd.Codingtest.Core
{
    public class EmailNotificationMessage : INotificationMessage
    {
        private readonly EmailService emailService;

        public EmailNotificationMessage()
        {
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
                
                result = emailService.Send(notificationEvent.To, notificationEvent.From, notificationEvent.Title, notificationEvent.Message);
            }
            catch (Exception e)
            {
                error = e.Message;
            }

            return result;
        }
    }
}