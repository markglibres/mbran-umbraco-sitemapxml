using System.IO;
using System.Text;

namespace MBran.SitemapXml.Service
{
    public class StringWriterUtf8 : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}