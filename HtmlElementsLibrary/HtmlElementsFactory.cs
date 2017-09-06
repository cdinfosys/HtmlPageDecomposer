using System;
using HtmlAgilityPack;

namespace HtmlPageDecomposer
{
    /// <summary>
    ///     Object to identify HTML elements and generate type specific element objects.
    /// </summary>
    public static class HtmlElementsFactory
    {
        public static IHtmlElement CreateHtmlElement(HtmlNode node)
        {
            if (String.Compare(node.Name, "link", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return new ElementLink(node);
            }

            // There is no specialised class for this node type so return a generic handler.
            return new HtmlGenericElement(node);
        }
    } // class HtmlElementsFactory
} // namespace HtmlPageDecomposer

