using System;
using Newtonsoft.Json;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;

namespace MBran.SitemapXml.ValueConverter
{
    [PropertyValueType(typeof(SitemapOptions))]
    [PropertyValueCache(PropertyCacheValue.All, PropertyCacheLevel.Content)]
    public class SitemapValueConverter : IPropertyValueConverter
    {
        public bool IsConverter(PublishedPropertyType propertyType)
        {
            return propertyType.PropertyEditorAlias.Equals("MBran.SitemapXml",
                StringComparison.InvariantCultureIgnoreCase);
        }

        public object ConvertDataToSource(PublishedPropertyType propertyType, object source, bool preview)
        {
            return Convert.ToString(source);
        }

        public object ConvertSourceToObject(PublishedPropertyType propertyType, object source, bool preview)
        {
            var option = JsonConvert.DeserializeObject<SitemapOptions>(source as string);
            return option;
        }

        public object ConvertSourceToXPath(PublishedPropertyType propertyType, object source, bool preview)
        {
            throw new NotImplementedException();
        }
    }
}