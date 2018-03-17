﻿using System.Collections.Generic;
using System.Linq;
using MBran.SitemapXml.Models;
using MBran.SitemapXml.Service.Interface;
using Newtonsoft.Json;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace MBran.SitemapXml.Service
{
    public class SitemapService : ISitemapService
    {
        private readonly ISiteService _siteService;
        private readonly IXmlSerializerService _xmlSerializer;

        public SitemapService()
        {
            _xmlSerializer = new XmlSerializerService();
            _siteService = new SiteService();
        }

        public SitemapXmlItem GetSitemapXmlItem(IPublishedContent content)
        {
            var option = GetSitemapOptions(content);

            return option != null
                ? new SitemapXmlItem
                {
                    Location = content.UrlAbsolute(),
                    ChangeFrequency = option.Frequency,
                    Priority = option.Priority,
                    LastModified = content.UpdateDate
                }
                : null;
        }

        public IEnumerable<IPublishedContent> GetSitemapPages()
        {
            return _siteService.GetDomainRoot()
                .DescendantsOrSelf()
                .Where(node => node.HasProperty(SitemapConstants.PropertyName));
        }

        public SitemapOptions GetSitemapOptions(IPublishedContent content)
        {
            return content.HasProperty(SitemapConstants.PropertyName)
                ? JsonConvert.DeserializeObject<SitemapOptions>(
                    content.GetPropertyValue<string>(SitemapConstants.PropertyName))
                : null;
        }

        public SitemapXmlRoot GetSitemapXml()
        {
            return new SitemapXmlRoot
            {
                Items = GetSitemapPages()
                    .Select(GetSitemapXmlItem)
                    .ToList()
            };
        }

        public string GetSitemalXmlString()
        {
            var sitemap = GetSitemapXml();
            return this._xmlSerializer.ToXmlString(sitemap);
        }
    }
}