using System;
using System.Collections.Generic;
using System.Text;

namespace thredd.codingtest.core.Services
{
    public class SmsService
    {
        public bool IsServiceRunning()
        {
            return true;
        }

        public bool Send(string to, string from, string message)
        {
            if (!string.IsNullOrEmpty(to))
            {
                throw new FailureToSendException("To field is required");
            }

            if (!string.IsNullOrEmpty(from))
            {
                throw new FailureToSendException("To field is required");
            }

            if (!string.IsNullOrEmpty(message))
            {
                throw new FailureToSendException("Message field is required");
            }

            return true;
        }
    }
}
