using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Thredd.Codingtest.Core;
using Thredd.Codingtest.Core.Services;
using Xunit;

namespace Thredd.Codingtest.Tests
{
    public class EmailNotificationMessageTests
    {
        [Fact]
        public void Can_Send_ValidMessage_ReturnsTrue()
        {
            var emailNotification = new EmailNotificationMessage();
            var notificationEvent = new NotificationEvent
            {
                To = "test@email.com",
                From = "from@email.com",
                Message = "Account credited"
            };

            var result = emailNotification.Send(notificationEvent, out var error);

            result.Should().BeTrue();
            error.Should().BeEmpty();
        }

        [Fact]
        public void Can_Send_InvalidTo_ThrowsException()
        {
            var emailNotification = new EmailNotificationMessage();
            var notificationEvent = new NotificationEvent
            {
                To = string.Empty,
                From = "from@email.com",
                Message = "Account credited"
            };

            var result = emailNotification.Send(notificationEvent, out var error);
            result.Should().BeFalse();
            error.Should().Contain("To field is required");
        }

        [Fact]
        public void Can_Send_InvalidFrom_ThrowsException()
        {
            var emailNotification = new EmailNotificationMessage();
            var notificationEvent = new NotificationEvent
            {
                To = "test@gmail.com",
                From = string.Empty,
                Message = "Account credited"
            };

            var result = emailNotification.Send(notificationEvent, out var error);
            result.Should().BeFalse();
            error.Should().Contain("From field is required");
        }

        [Fact]
        public void Can_Send_InvalidMessage_ThrowsException()
        {
            var emailNotification = new EmailNotificationMessage();
            var notificationEvent = new NotificationEvent
            {
                To = "test@email.com",
                From = "from@email.com",
                Message = string.Empty
            };

            var result = emailNotification.Send(notificationEvent, out var error);
            result.Should().BeFalse();
            error.Should().Contain("Message field is required");
        }

    }
}
