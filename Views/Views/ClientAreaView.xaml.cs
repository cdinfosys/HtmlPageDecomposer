using System;
using System.Windows.Controls;

namespace HtmlPageDecomposer
{
    /// <summary>
    /// Interaction logic for ClientAreaView.xaml
    /// </summary>
    public partial class ClientAreaView : UserControl, IClientAreaView
    {
        #region Construction
            /// <summary>
            ///     Construct a view for the client area of the program.
            /// </summary>
            /// <param name="viewModel">
            ///     Reference to the view model object of the view.
            /// </param>
            public ClientAreaView(IClientAreaViewModel viewModel)
            {
                InitializeComponent();
                this.DataContext = viewModel;
            }
        #endregion // Construction
    }
}
