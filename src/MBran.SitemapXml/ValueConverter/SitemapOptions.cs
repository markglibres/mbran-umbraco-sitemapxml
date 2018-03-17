using System.Runtime.Serialization;

namespace MBran.SitemapXml.ValueConverter
{
    [DataContract]
    public class SitemapOptions
    {
        [DataMember(Name = "exclude")]
        public bool Exclude { get; set; }
        [DataMember(Name = "frequency")]
        public SitemapFrequency Frequency { get; set; }
        [DataMember(Name = "priority")]
        public double Priority { get; set; }
    }
}