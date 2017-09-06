using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace HtmlPageDecomposer
{
    /// <summary>
    ///     Stores values for a member of the HTML elements tree.
    /// </summary>
    public class HtmlElementsTreeNode
    {
        #region Private data members
            /// <summary>
            ///     List of child elements of this element.
            /// </summary>
            private readonly List<HtmlElementsTreeNode> childElements = new List<HtmlElementsTreeNode>();

            /// <summary>
            ///     Element from the HTML document.
            /// </summary>
            private HtmlNode htmlNode;
        #endregion Private data members

        #region Construction
            /// <summary>
            ///     Construct a new tree node.
            /// </summary>
            /// <param name="node">
            ///     Reference to the object that was extracted from the HTML document.
            /// </param>
            /// <param name="childElements">
            ///     Children of the element.
            /// </param>
            public HtmlElementsTreeNode(HtmlNode node, List<HtmlElementsTreeNode> childElements)
            {
                this.htmlNode = node;
                this.childElements.AddRange(childElements);
            }

            /// <summary>
            ///     Construct a new tree node without child nodes.
            /// </summary>
            /// <param name="elementTag">
            ///     Tag of the element.
            /// </param>
            public HtmlElementsTreeNode(HtmlNode node)
            {
                this.htmlNode = node;
            }
        #endregion Construction

        #region Public properties
            /// <summary>
            ///     Gets the list of child elements.
            /// </summary>
            public IEnumerable<HtmlElementsTreeNode> Children => this.childElements;

            /// <summary>
            ///     Gets the tag for the HTML element. 
            /// </summary>
            public String ElementTag => this.htmlNode.Name;

            public Boolean IsExpanded { get; set; }
            public Boolean IsSelected { get; set; }
        #endregion Public properties
    } // class HtmlElementsTreeMember
} // namespace HtmlPageDecomposer
