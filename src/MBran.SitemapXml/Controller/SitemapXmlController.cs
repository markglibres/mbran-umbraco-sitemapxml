using System;
using System.Web.Hosting;
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

        [OutputCache(Duration = 3600 , VaryByHeader = "host")]
        public virtual ActionResult Index()
        {
            var sitemap = _sitemapService.GetSitemapXmlString();
            return Content(sitemap, "text/xml");
        }
    }
}