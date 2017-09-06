using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace HtmlPageDecomposer
{
    /// <summary>
    ///     Data access routines
    /// </summary>
    public class DataStore : IDataStore
    {
        #region Private data members
            /// <summary>
            ///     Event aggregator instance that was passed to the constructor.
            /// </summary>
            private IEventAggregator eventAggregator;

            /// <summary>
            ///     Unity container instance that was passed to the constructor.
            /// </summary>
            private IUnityContainer container;

            /// <summary>
            ///     Flag to indicate if the document is modified.
            /// </summary>
            private Boolean isModified = false;

            /// <summary>
            ///     The loaded HTML document
            /// </summary>
            private HtmlDocument htmlDocument;

        #endregion Private data members

        #region Construction
            /// <summary>
            ///     Construct an instance of the class
            /// </summary>
            public DataStore(IEventAggregator eventAggregator, IUnityContainer container)
            {
                this.eventAggregator = eventAggregator;
                this.container = container;
            }
        #endregion // Construction

        #region Public properties
            /// <summary>
            ///     Get or sets the flag that indicates if the document was modified.
            /// </summary>
            public Boolean IsModified
            {
                get
                {
                    return isModified;
                }

                set
                {
                    this.isModified = value;
                }
            }

            /// <summary>
            ///     Gets a reference to the HTML document object.
            /// </summary>
            public HtmlDocument HtmlDocument
            {
                get
                {
                    return this.htmlDocument;
                }
            }

        #endregion Public properties

            public void LoadHtmlFromURL(String documentURL)
            {
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.CreateHttp(documentURL);
                using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
                {
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream htmlStream = httpResponse.GetResponseStream())
                        {
                            HtmlDocument htmlDocumentLoader = new HtmlDocument();
                            htmlDocumentLoader.Load(htmlStream);
                            this.htmlDocument = htmlDocumentLoader;
                        }
                    }
                }
            }
    } // class DataStore
} // namespace HtmlPageDecomposer
