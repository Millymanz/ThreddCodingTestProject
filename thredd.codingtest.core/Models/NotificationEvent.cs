using System;
using System.ComponentModel.DataAnnotations;

namespace Thredd.Codingtest.Core
{
    public class NotificationEvent
    {
        public Guid Id { get; set; } = new Guid();

        public string To { get; set; }

        public string From { get; set; }

        public string Message { get; set; }

        public string Title { get; set; }

        [Required]
        public string NotificationType { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
    }
}
