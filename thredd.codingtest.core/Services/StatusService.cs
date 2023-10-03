using System;
using System.Collections.Generic;

namespace Thredd.Codingtest.Core.Services
{
    public class StatusService
    {
        public static Dictionary<Guid, string> MessageStatusDictionary;

        public static void SetStatus(Guid id, string status)
        {
            if (MessageStatusDictionary == null)
            {
                MessageStatusDictionary = new Dictionary<Guid, string>();
            }

            MessageStatusDictionary.Add(id, status);
        }

        public static string GetStatus(Guid id)
        {
            if (MessageStatusDictionary == null)
            {
                throw new ApplicationException("No status set");
            }

            if (MessageStatusDictionary.ContainsKey(id))
            {
                return MessageStatusDictionary[id];
            }

            return string.Empty;
        }
    }
}