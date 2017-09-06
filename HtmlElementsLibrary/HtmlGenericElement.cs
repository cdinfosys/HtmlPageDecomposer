using System;
using HtmlAgilityPack;

namespace HtmlPageDecomposer
{
    /// <summary>
    ///     Generic class for HTML elements that do not have specialized handler classes.
    /// </summary>
    public class HtmlGenericElement : HtmlElementBase
    {
        #region Construction
            /// <summary>
            ///     Construct an HTML element wrapper object.
            /// </summary>
            /// <param name="htmlNode">
            ///     Reference to the HTML node from the HTML document.
            /// </param>
            public HtmlGenericElement(HtmlNode htmlNode)
                :   base(htmlNode)
            {
            }
        #endregion //Construction
    } // class HtmlGenericElement
} // namespace HtmlPageDecomposer
