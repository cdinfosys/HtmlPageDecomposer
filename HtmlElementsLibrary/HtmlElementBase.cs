using System;
using HtmlAgilityPack;

namespace HtmlPageDecomposer
{
    /// <summary>
    ///     Base class for HTML element classes.
    /// </summary>
    public abstract class HtmlElementBase : IHtmlElement
    {
        #region Private data members
            /// <summary>
            ///     Stores a reference to the HTML node from the HTML document that was opened.
            /// </summary>
            private HtmlNode htmlNode;
        #endregion Private data members

        #region Construction
            /// <summary>
            ///     Construct an HTML element wrapper object.
            /// </summary>
            /// <param name="htmlNode">
            ///     Reference to the HTML node from the HTML document.
            /// </param>
            protected HtmlElementBase(HtmlNode htmlNode)
            {
                this.htmlNode = htmlNode;
            }
        #endregion //Construction

        #region Public propterties
            /// <summary>
            ///     Gets the attribute object that was retrieved from the HTML document.
            /// </summary>
            public HtmlNode Node => this.htmlNode;
        #endregion // Public propterties

    } // class HtmlElementBase
} // namespace HtmlPageDecomposer
