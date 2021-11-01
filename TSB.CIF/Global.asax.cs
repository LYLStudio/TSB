using System;

using TSB.Services.Logger;

namespace TSB.CIF
{
    public class Global : System.Web.HttpApplication
    {
        private static ILogService _logger = null;
        public static ILogService Logger { get; set; }

        protected void Application_Start(object sender, EventArgs e)
        {
            Logger = _logger ?? new LogService(Server.MapPath("/App_Data/Logs"));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}