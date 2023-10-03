using System;
using System.ComponentModel.DataAnnotations;

namespace thredd.codingtest.core
{
    public class NotificationEvent
    {
        public Guid Id { get; set; } = new Guid();

        public string To { get; set; }

        public string From { get; set; }

        public string Message { get; set; }

        [Required]
        public string NotificationType { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
    }
}
