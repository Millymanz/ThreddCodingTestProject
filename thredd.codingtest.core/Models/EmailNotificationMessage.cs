using System;

namespace thredd.codingtest.core.Models
{
    public class EmailNotificationMessage : INotificationMessage
    {
        public bool send(NotificationEvent notificationEvent, out string error)
        {
            throw new NotImplementedException();
        }
    }
}