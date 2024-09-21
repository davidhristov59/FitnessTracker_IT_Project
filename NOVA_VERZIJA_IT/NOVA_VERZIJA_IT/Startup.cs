using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using NOVA_VERZIJA_IT.Models;

[assembly: OwinStartup(typeof(NOVA_VERZIJA_IT.Startup))]

namespace NOVA_VERZIJA_IT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
