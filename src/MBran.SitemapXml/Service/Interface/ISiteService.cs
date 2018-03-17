using Umbraco.Core.Models;

namespace MBran.SitemapXml.Service.Interface
{
    public interface ISiteService
    {
        int GetDomainRootId();
        IPublishedContent GetDomainRoot();

    }
}
