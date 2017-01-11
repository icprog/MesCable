using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
[assembly:OwinStartup(typeof(WebUI.Models.RealTimeConnection.HubStartup))]
namespace WebUI.Models.RealTimeConnection {
    public class HubStartup {
        public void Configuration(IAppBuilder app) {
            app.MapSignalR();
        }
    }
}