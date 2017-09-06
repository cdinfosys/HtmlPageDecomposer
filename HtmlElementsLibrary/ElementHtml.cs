using System;
using HtmlAgilityPack;

namespace HtmlPageDecomposer
{
    /// <summary>
    ///     Handler for a <c>HTML</c> element type
    /// </summary>
    public class ElementHtml : HtmlElementBase
    {
        #region Construction
            /// <summary>
            ///     Construct an HTML element wrapper object.
            /// </summary>
            /// <param name="htmlNode">
            ///     Reference to the HTML node from the HTML document.
            /// </param>
            public ElementHtml(HtmlNode htmlNode)
                :   base(htmlNode)
            {
            }
        #endregion //Construction
    } // class ElementHtml
} // namespace HtmlPageDecomposer
