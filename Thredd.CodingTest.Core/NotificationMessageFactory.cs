using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Thredd.Codingtest.Core.Interfaces;

namespace Thredd.Codingtest.Core
{
    public class NotificationMessageFactory
    {
        private readonly ILogger<SmsNotificationMessage> _smsLogger;
        private readonly ILogger<EmailNotificationMessage> _emailLogger;

        public NotificationMessageFactory(ILogger<SmsNotificationMessage> smsLogger, ILogger<EmailNotificationMessage> emailLogger)
        {
            _smsLogger = smsLogger;
            _emailLogger = emailLogger;
        }

        public INotificationMessage CreateNotificationMessage(string notificationType)
        {
            if (notificationType == "Sms")
            {
                return new SmsNotificationMessage(_smsLogger);
            }
            else
            {
                return new EmailNotificationMessage(_emailLogger);
            }
        }
    }
}
