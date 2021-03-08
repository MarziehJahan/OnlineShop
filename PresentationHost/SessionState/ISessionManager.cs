using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationHost.SessionState
{
    public interface ISessionManager
    {
        string GetLogInfo();
        void SetLogInfo(string SessionKeyName);
    }
}
