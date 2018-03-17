using System.Web.Mvc;
using MBran.SitemapXml.Service;
using MBran.SitemapXml.Service.Interface;
using Umbraco.Web.Mvc;

namespace MBran.SitemapXml.Controller
{
    [System.Web.Http.RoutePrefix("")]
    public class SitemapXmlController : RenderMvcController
    {
        private readonly ISitemapService _sitemapService;

        public SitemapXmlController()
        {
            _sitemapService = new SitemapService();
        }

        [OutputCache(NoStore = true, Duration = 3600, VaryByParam = "none")]
        public virtual ActionResult Index()
        {
            var sitemap = _sitemapService.GetSitemalXmlString();
            return Content(sitemap, "text/xml");
        }
    }
}