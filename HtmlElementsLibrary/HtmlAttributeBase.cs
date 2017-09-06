using System;
using HtmlAgilityPack;

namespace HtmlPageDecomposer
{
    /// <summary>
    ///     Base class for HTML element attribute classes.
    /// </summary>
    public abstract class HtmlAttributeBase : IHtmlAttribute
    {
        #region Private data members
            /// <summary>
            ///     Reference to the attribute object that was retrieved from the HTML document.
            /// </summary>
            private HtmlAgilityPack.HtmlAttribute attribute;
        #endregion // Private data members

        #region Construction
            /// <summary>
            ///     Construct a HTML element attribute wrapper object.
            /// </summary>
            /// <param name="attribute"></param>
            protected HtmlAttributeBase(HtmlAgilityPack.HtmlAttribute attribute)
            {
                this.attribute = attribute;
            }
        #endregion // Construction

        #region Public propterties
            /// <summary>
            ///     Get a value that identifies the attribute type
            /// </summary>
            public abstract AttributeTypeIdentifier AttributeType { get; }

            /// <summary>
            ///     Gets the attribute object that was retrieved from the HTML document.
            /// </summary>
            public HtmlAttribute Attribute => this.attribute;
        #endregion // Public propterties
    } // class HtmlAttributeBase
} // namespace HtmlPageDecomposer
