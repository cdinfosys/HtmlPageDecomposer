using System;

namespace HtmlPageDecomposer
{
    public class HtmlGenericAttribute : HtmlAttributeBase
    {
        #region Construction
            /// <summary>
            ///     Construct a HTML element attribute wrapper object.
            /// </summary>
            /// <param name="attribute"></param>
            public HtmlGenericAttribute(HtmlAgilityPack.HtmlAttribute attribute)
                :   base(attribute)
            {
            }
        #endregion // Construction

        #region Public propterties
            /// <summary>
            ///     Get a value that identifies the attribute type
            /// </summary>
            public override AttributeTypeIdentifier AttributeType => AttributeTypeIdentifier.Generic;
        #endregion // Public propterties

    } // class HtmlGenericAttribute
} // namespace HtmlPageDecomposer
