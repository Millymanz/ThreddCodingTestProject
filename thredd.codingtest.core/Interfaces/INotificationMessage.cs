using System.Collections.Generic;
using System.Text;

namespace Thredd.Codingtest.Core.Interfaces
{
    public interface INotificationMessage
    {
        bool Send(NotificationEvent notificationEvent, out string error);
    }
}
