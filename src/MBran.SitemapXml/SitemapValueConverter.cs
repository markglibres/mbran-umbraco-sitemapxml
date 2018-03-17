using System;
using Newtonsoft.Json.Linq;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;

namespace MBran.SitemapXml
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
            var propertyValue = JObject.Parse(source as string);
            
            return new SitemapOptions
            {
                Exclude = propertyValue["exclude"]?.Value<bool>() ?? false,
                Frequency = (SitemapFrequency)(propertyValue["frequency"]?.Value<int>() ?? (int)SitemapFrequency.Daily),
                Priority = propertyValue["priority"]?.Value<double>() ?? 0.5
            };
        }

        public object ConvertSourceToXPath(PublishedPropertyType propertyType, object source, bool preview)
        {
            throw new NotImplementedException();
        }
    }
}