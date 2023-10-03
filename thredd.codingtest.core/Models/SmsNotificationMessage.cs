using System;
using thredd.codingtest.core.Services;

namespace thredd.codingtest.core.Models
{
    public class SmsNotificationMessage : INotificationMessage
    {
        private readonly SmsService smsService;

        public SmsNotificationMessage()
        {
            smsService = new SmsService();
        }

        public bool send(NotificationEvent notificationEvent, out string error)
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

                result = smsService.Send(notificationEvent.To, notificationEvent.From, notificationEvent.Message);
            }
            catch (Exception e)
            {
                error = e.Message;
            }

            return result;
        }
    }
}