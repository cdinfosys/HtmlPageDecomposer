using System;

namespace HtmlPageDecomposer
{
    public class AttributeHRef : HtmlAttributeBase
    {
        #region Private data members
            /// <summary>
            ///     URL of the href.
            /// </summary>
            private String url;
        #endregion // Private data members

        #region Construction
            /// <summary>
            ///     Construct a HTML element attribute wrapper object.
            /// </summary>
            /// <param name="attribute"></param>
            public AttributeHRef(HtmlAgilityPack.HtmlAttribute attribute)
                :   base(attribute)
            {
                this.url = attribute.Value;
            }
        #endregion // Construction

        #region Public propterties
            /// <summary>
            ///     Get a value that identifies the attribute type
            /// </summary>
            public override AttributeTypeIdentifier AttributeType => AttributeTypeIdentifier.href;

            /// <summary>
            ///     Returns the URL of the href
            /// </summary>
            public String URL => this.url;
        #endregion // Public propterties
    } // class AttributeHRef
} // namespace HtmlPageDecomposer
