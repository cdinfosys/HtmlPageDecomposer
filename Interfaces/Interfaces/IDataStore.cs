using System;
using HtmlAgilityPack;

namespace HtmlPageDecomposer
{
    public interface IDataStore
    {
        #region Properties
            HtmlDocument HtmlDocument { get; }
        #endregion // Properties

        #region Public methods
            void LoadHtmlFromURL(String documentURL);
        #endregion // Public methods
    }
}
