using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Thredd.Codingtest.Core.Services
{
    public class StatusService
    {
        private ConcurrentDictionary<Guid, string> _messageStatusDictionary;

        public StatusService()
        {
            _messageStatusDictionary = new ConcurrentDictionary<Guid, string>();
        }

        public void SetStatus(Guid id, string status)
        {
            _messageStatusDictionary[id] = status;
        }

        public string GetStatus(Guid id)
        {
            if (_messageStatusDictionary.TryGetValue(id, out string status))
            {
                return status;
            }
            return string.Empty;
        }
    }
}