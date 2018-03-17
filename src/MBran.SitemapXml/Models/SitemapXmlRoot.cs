using System.Collections.Generic;
using System.Xml.Serialization;

namespace MBran.SitemapXml.Models
{
    [XmlRoot("urlset", Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9")]
    public class SitemapXmlRoot
    {
        [XmlElement("url")] public List<SitemapXmlItem> Items { get; set; }
    }
}