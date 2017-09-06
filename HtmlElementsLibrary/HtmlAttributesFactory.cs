using System;

namespace HtmlPageDecomposer
{
    /// <summary>
    ///     Factory object to create instances of HTML attribute handler objects.
    /// </summary>
    public static class HtmlAttributesFactory
    {
        public static IHtmlAttribute CreateAttribute(HtmlAgilityPack.HtmlAttribute attribute)
        {
            if (String.Compare(attribute.Name, "href", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return new AttributeHRef(attribute);
            }

            return new HtmlGenericAttribute(attribute);
        }
    } // class HtmlAttributesFactory
} // namespace HtmlPageDecomposer
