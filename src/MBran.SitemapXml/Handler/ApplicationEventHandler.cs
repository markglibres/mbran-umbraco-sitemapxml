using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core;

namespace MBran.SitemapXml.Handler
{
    public class ApplicationEventHandler : IApplicationEventHandler
    {
        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication,
            ApplicationContext applicationContext)
        {
        }

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication,
            ApplicationContext applicationContext)
        {
            RouteTable.Routes.MapRoute(
                "sitemap",
                "sitemap",
                new
                {
                    controller = "SiteMap",
                    action = "Index"
                });
        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication,
            ApplicationContext applicationContext)
        {
        }
    }
}