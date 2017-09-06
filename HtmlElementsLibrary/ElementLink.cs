using System;
using HtmlAgilityPack;

namespace HtmlPageDecomposer
{
    public class ElementLink : HtmlElementBase
    {
        #region Construction
            /// <summary>
            ///     Construct an HTML element wrapper object.
            /// </summary>
            /// <param name="htmlNode">
            ///     Reference to the HTML node from the HTML document.
            /// </param>
            public ElementLink(HtmlNode htmlNode)
                :   base(htmlNode)
            {
                ExtractAttributes(htmlNode);
            }
        #endregion //Construction

        #region Private helper methods
            /// <summary>
            ///     Extracts and evaluates the attributes of the node.
            /// </summary>
            /// <param name="htmlNode">
            ///     Reference to the HTML node.
            /// </param>
            private void ExtractAttributes(HtmlNode htmlNode)
            {
                foreach (HtmlAttribute attribute in htmlNode.Attributes)
                {
                    var attr = HtmlAttributesFactory.CreateAttribute(attribute);
                    attr = null;
                }
            }
        #endregion // Private helper methods
    }
}
