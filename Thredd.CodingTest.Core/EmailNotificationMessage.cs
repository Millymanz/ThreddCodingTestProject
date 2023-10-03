using System;
using Thredd.Codingtest.Core.Interfaces;

namespace Thredd.Codingtest.Core
{
    public class EmailNotificationMessage : INotificationMessage
    {
        public bool Send(NotificationEvent notificationEvent, out string error)
        {
            throw new NotImplementedException();
        }
    }
}