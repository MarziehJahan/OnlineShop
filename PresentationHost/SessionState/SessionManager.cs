using Microsoft.AspNetCore.Http;
using System;


namespace PresentationHost.SessionState
{
    public class SessionManager : ISessionManager
    {
       
       
        private IHttpContextAccessor _httpContextAccessor;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        
        public string GetLogInfo()
        {
            return _httpContextAccessor.HttpContext.Session.GetString("LogInfo");
        }

        public void SetLogInfo(string sessionKeyName)
        {
            //if (string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Session.GetString("LogInfo")))
            //{
         
            _httpContextAccessor.HttpContext.Session.SetString("LogInfo", sessionKeyName);
           // }
        }
    }
}
