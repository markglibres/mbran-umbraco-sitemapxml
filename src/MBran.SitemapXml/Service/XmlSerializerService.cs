using System.Xml.Serialization;
using MBran.SitemapXml.Service.Interface;

namespace MBran.SitemapXml.Service
{
    public class XmlSerializerService : IXmlSerializerService
    {
        public string ToXmlString(object objectToSerialize)
        {
            string xmlString;

            var xmlSerializer = new XmlSerializer(objectToSerialize.GetType());

            using (var textWriter = new StringWriterUtf8())
            {
                xmlSerializer.Serialize(textWriter, objectToSerialize);
                xmlString = textWriter.ToString();
            }

            return xmlString;
        }
    }
}