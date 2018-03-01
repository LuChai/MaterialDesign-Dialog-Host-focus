using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HiddenPannelVisibilityButton_Click(object sender, RoutedEventArgs e)
        {
            OpenCancelPanel.IsEnabled = true;
            HiddenPanel.Visibility = Visibility.Collapsed;
        }

        private void HiddenPanelCancel_Click(object sender, RoutedEventArgs e)
        {
            OpenCancelPanel.IsEnabled = true;
            HiddenPanel.Visibility = Visibility.Collapsed;
        }

        private void OpenHiddenPanel_Click(object sender, RoutedEventArgs e)
        {
            HiddenPanel.Visibility = Visibility.Visible;
            OpenCancelPanel.IsEnabled = false;
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (ExampleDrawerHost.IsBottomDrawerOpen)
            {
                e.CanExecute = true;
            }
            else
                e.CanExecute = false;
            e.Handled = true;
        }
    }
}
