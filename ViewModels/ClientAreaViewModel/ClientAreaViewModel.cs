using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace HtmlPageDecomposer
{
    /// <summary>
    ///     View model for the client area control of the main window.
    /// </summary>
    public class ClientAreaViewModel : ViewModelBase, IClientAreaViewModel
    {
        #region  Private data members
            /// <summary>
            ///     Root element of the HTML elements tree.
            /// </summary>
            private List<HtmlElementsTreeNode> htmlPageRootElement;

            /// <summary>
            ///     Reference to the data store object.
            /// </summary>
            private readonly IDataStore dataStore;
        #endregion // Private data members

        #region Construction
            /// <summary>
            ///     Construct a view model for the client area container control.
            /// </summary>
            /// <param name="eventAggregator">
            ///     Reference to a Unity event aggregator object.
            /// </param>
            /// <param name="container">
            ///     Reference to a Unity container object.
            /// </param>
            public ClientAreaViewModel(IEventAggregator eventAggregator, IUnityContainer container)
                :   base(eventAggregator, container)
            {
                eventAggregator.GetEvent<HtmlDocumentLoadedEvent>().Subscribe(OnHtmlDocumentLoaded);
                dataStore = container.Resolve<IDataStore>();
            }
        #endregion Construction

        #region Public properties
            /// <summary>
            ///     Gets the root node of the HTML elements tree
            /// </summary>
            public IEnumerable<HtmlElementsTreeNode> HtmlElementsTreeRootNode
            {
                get
                {
                    return this.htmlPageRootElement;
                }
                private set 
                {
                    this.htmlPageRootElement = new List<HtmlElementsTreeNode>(value);
                    RaisePropertyChanged();
                }
            }
        #endregion Public properties

        #region Private helper methods
            /// <summary>
            ///     Event handler for the <c>HtmlDocumentLoadedEvent</c> that is fired when the user loads an HTML document.
            /// </summary>
            private void OnHtmlDocumentLoaded()
            {
                HtmlDocument document = dataStore.HtmlDocument;
                List<HtmlElementsTreeNode> rootNode = new List<HtmlElementsTreeNode>(TraverseElementsTree(document.DocumentNode));
                HtmlElementsTreeRootNode = rootNode;
                /*
                    htmlPageRootElement = new HtmlElementsTreeNode
                    (
                        "foo", 
                        new List<HtmlElementsTreeNode>() 
                        {
                            new HtmlElementsTreeNode("Bar1"),
                            new HtmlElementsTreeNode("Bar2"),
                        }
                    );
                    */
            }

            /// <summary>
            ///     Build a tree of nodes. The method recursively calls itself until it reaches a leaf node.
            /// </summary>
            /// <param name="htmlNode">
            ///     First node of a sub-level.
            /// </param>
            /// <returns></returns>
            private List<HtmlElementsTreeNode> TraverseElementsTree(HtmlNode htmlNode)
            {
                List<HtmlElementsTreeNode> result = new List<HtmlElementsTreeNode>();


                HtmlNode siblingNode = htmlNode;
                while (siblingNode != null)
                {
                    IHtmlElement element = HtmlElementsFactory.CreateHtmlElement(siblingNode);

                    // Skip text and comments
                    if 
                    (
                        (siblingNode.NodeType == HtmlNodeType.Document) ||
                        (siblingNode.NodeType == HtmlNodeType.Element)
                    )
                    {
                        if (siblingNode.HasChildNodes)
                        {
                            result.Add(new HtmlElementsTreeNode(siblingNode, TraverseElementsTree(siblingNode.FirstChild)));
                        }
                        else
                        {
                            result.Add(new HtmlElementsTreeNode(siblingNode));
                        }
                    }
                    siblingNode = siblingNode.NextSibling;
                }

                return result;
            }
        #endregion // Private helper methods
    } // class ClientAreaViewModel
} // namespace HtmlPageDecomposer
