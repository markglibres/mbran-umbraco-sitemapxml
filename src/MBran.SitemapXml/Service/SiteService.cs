using System;
using System.Linq;
using System.Web;
using MBran.SitemapXml.Service.Interface;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace MBran.SitemapXml.Service
{
    public class SiteService : ISiteService
    {
        private readonly UmbracoHelper _umbracoHelper;

        public SiteService()
        {
            _umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
        }

        public IPublishedContent GetDomainRoot()
        {
            var domainId = GetDomainRootId();
            return domainId == 0 ? null : _umbracoHelper.TypedContent(domainId);
        }

        public int GetDomainRootId()
        {
            var domainService = ApplicationContext.Current.Services.DomainService;

            return domainService
                       ?.GetAll(true)
                       .FirstOrDefault(domain => domain.DomainName.Equals(HttpContext.Current.Request.Url.Host,
                           StringComparison.InvariantCultureIgnoreCase))
                       ?.Id ?? _umbracoHelper.TypedContentAtRoot().FirstOrDefault()?.Id ?? 0;
        }
    }
}