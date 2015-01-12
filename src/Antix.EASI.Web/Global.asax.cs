using System;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using Antix.EASI.Web.Configuration;
using Castle.Windsor;

namespace Antix.EASI.Web
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            BundleConfig.Init(BundleTable.Bundles);
            WindsorConfig.Init(new WindsorContainer(), GlobalConfiguration.Configuration);
        }
    }
}