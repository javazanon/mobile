using Microsoft.Owin;
using Owin;
using POS_ERP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

[assembly: OwinStartup(typeof(POS_ERP.App_Start.Startup))]
namespace POS_ERP.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here  zanon update
           // app.MapSignalR();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}