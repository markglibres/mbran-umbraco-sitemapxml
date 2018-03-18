# mbran-umbraco-sitemapxml
MBran SitemapXml is a package to auto-generate sitemap xml on these simple steps:

[1]: https://our.umbraco.org/projects/backoffice-extensions/mbran-sitemap-xml/ "Umbraco Package Link"
[2]: https://www.nuget.org/packages/MBran.SitemapXml/ "NuGet Package Link"

## From NuGet:

1. Install package ([https://www.nuget.org/packages/MBran.SitemapXml/][2])
2. Create new data type of type "Sitemap Xml (MBran.SitemapXml)"
3. Create a doc type property called "sitemapOption" of data type "Sitemap Xml"
4. Browse to your website http://yourdomain.com/sitemap

## From Umbraco Package  Manager:

1. Download and install package ([https://our.umbraco.org/projects/backoffice-extensions/mbran-sitemap-xml/][1])
2. Create a doc type property called "sitemapOption" of data type "Sitemap Xml".
3. Browse to your website http://yourdomain.com/sitemap

## Features:

* Multi-tenant support
* Sitemap protocol format with UTF-8 encoding
* Universal last modified date with time offset
* Default values for: priority (0.5) and frequency (daily)
