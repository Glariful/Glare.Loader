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
using MahApps.Metro.Controls;

namespace Glare.Loader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            ///Add Following Line to ToSAccepted
            RightWindowCommands.Visibility = Visibility.Collapsed;
        }

        private void NewsButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 1;            
        }

        private void LoaderButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 2;
        }
        private void SettingsButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 3;
        }

        private void TosAccept_Click(object sender, RoutedEventArgs e)
        {
            ///Config.Instance.TosAccepted = true;
            MainTabControl.SelectedIndex = 1;
            RightWindowCommands.Visibility = Visibility.Visible;
            TosBrowser.Visibility = Visibility.Collapsed;
        }

        private void TosDecline_Click(object sender, RoutedEventArgs e)
        {
            ///MainWindow_OnClosing(null, null);
            Environment.Exit(0);
        }
    }
}
