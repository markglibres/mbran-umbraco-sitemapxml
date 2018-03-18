using System;
using System.Xml.Serialization;

namespace MBran.SitemapXml.Models
{
    public class SitemapXmlItem
    {
        [XmlElement("loc")]
        public string Location { get; set; }

        [XmlIgnore]
        public DateTime LastModified { get; set; }

        [XmlElement("lastmod")]
        public string LastModifiedString
        {
            get => LastModified.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:sszzz");
            set => LastModified = DateTime.Parse(value);
        }

        [XmlElement("changefreq")]
        public string ChangeFrequencyString { get; set; }

        [XmlIgnore]
        public SitemapFrequency ChangeFrequency
        {
            get => (SitemapFrequency) Enum.Parse(typeof(SitemapFrequency), ChangeFrequencyString);
            set => ChangeFrequencyString = Enum.GetName(typeof(SitemapFrequency), value)?.ToLower();
        }

        [XmlElement("priority")] public double Priority { get; set; }
    }
}