using System.Collections.Generic;
using MBran.SitemapXml.Models;
using Umbraco.Core.Models;

namespace MBran.SitemapXml.Service.Interface
{
    public interface ISitemapService
    {
        IEnumerable<IPublishedContent> GetSitemapPages();
        SitemapOptions GetSitemapOptions(IPublishedContent content);
        SitemapXmlItem GetSitemapXmlItem(IPublishedContent content);
        SitemapXmlRoot GetSitemapXml();
        string GetSitemapXmlString();
    }
}