namespace MBran.SitemapXml.Service.Interface
{
    public interface IXmlSerializerService
    {
        string ToXmlString(object objectToSerialize);
    }
}