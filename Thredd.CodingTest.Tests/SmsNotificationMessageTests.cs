using FluentAssertions;
using System;
using Thredd.Codingtest.Core;
using Thredd.Codingtest.Core.Services;
using Xunit;

namespace Thredd.CodingTest.Tests
{
    public class SmsNotificationMessageTests
    {
        [Fact]
        public void Can_Send_ValidMessage_ReturnsTrue()
        {
            var smsNotification = new SmsNotificationMessage();
            var notificationEvent = new NotificationEvent
            {
                To = "1234567890",
                From = "0987654321",
                Message = "Account credited"
            };

            var result = smsNotification.Send(notificationEvent, out var error);

            result.Should().BeTrue();
            error.Should().BeEmpty();
        }

        [Fact]
        public void Can_Send_InvalidTo_ThrowsException()
        {
            var smsNotification = new SmsNotificationMessage();
            var notificationEvent = new NotificationEvent
            {
                To = string.Empty,
                From = "0987654321",
                Message = "Hello"
            };

            var result = smsNotification.Send(notificationEvent, out var error);
            result.Should().BeFalse();
            error.Should().Contain("To field is required");
        }

        [Fact]
        public void Can_Send_InvalidFrom_ThrowsException()
        {
            var smsNotification = new SmsNotificationMessage();
            var notificationEvent = new NotificationEvent
            {
                To = "1234567890",
                From = string.Empty,
                Message = "Hello"
            };

            var result = smsNotification.Send(notificationEvent, out var error);
            result.Should().BeFalse();
            error.Should().Contain("From field is required");
        }

        [Fact]
        public void Can_Send_InvalidMessage_ThrowsException()
        {
            var smsNotification = new SmsNotificationMessage();
            var notificationEvent = new NotificationEvent
            {
                To = "1234567890",
                From = "0987654321",
                Message = string.Empty
            };

            var result = smsNotification.Send(notificationEvent, out var error);
            result.Should().BeFalse();
            error.Should().Contain("Message field is required");
        }
    }
}
