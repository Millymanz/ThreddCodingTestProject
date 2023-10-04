using System.Net.Mail;

namespace Thredd.Codingtest.Core.Services
{
    public class EmailService
    {
        public bool IsServiceRunning()
        {
            return true;
        }

        public bool Send(string to, string from, string subject, string message)
        {
            if (string.IsNullOrEmpty(to))
            {
                throw new FailureToSendException("To field is required");
            }

            if (string.IsNullOrEmpty(from))
            {
                throw new FailureToSendException("From field is required");
            }

            if (string.IsNullOrEmpty(message))
            {
                throw new FailureToSendException("Message field is required");
            }

            if (!IsValid(to))
            {
                throw new FailureToSendException("To field is invalid");
            }

            if (!IsValid(from))
            {
                throw new FailureToSendException("From field is invalid");
            }

            return true;
        }

        private bool IsValid(string email)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }
    }
}