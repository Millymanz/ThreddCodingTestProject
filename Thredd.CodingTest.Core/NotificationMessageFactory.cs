using System;
using System.Collections.Generic;
using System.Text;
using Thredd.Codingtest.Core.Interfaces;

namespace Thredd.Codingtest.Core
{
    public class NotificationMessageFactory
    {
        public static INotificationMessage CreateNotificationMessage(string notificationType)
        {
            if (notificationType == "Sms")
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
