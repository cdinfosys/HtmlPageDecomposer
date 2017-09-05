using System;
using System.Windows.Controls;

namespace HtmlPageDecomposer
{
    /// <summary>
    /// Interaction logic for ClientAreaView.xaml
    /// </summary>
    public partial class ClientAreaView : UserControl, IClientAreaView
    {
        public ClientAreaView(IClientAreaViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
