﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DynamicView_Demo.Startup))]
namespace DynamicView_Demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
