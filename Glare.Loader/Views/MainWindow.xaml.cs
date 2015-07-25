using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;
using MahApps.Metro.Controls;

namespace Glare.Loader
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;
    using System.Windows.Interop;
    using Glare.Loader.Class;
    using Glare.Loader.Data;
    using MahApps.Metro.Controls.Dialogs;
    using Microsoft.Build.Evaluation;

    public partial class MainWindow : MetroWindow
    {
        public Config Config
        {
            get { return Config.Instance; }
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            Browser.Visibility = Visibility.Hidden;
            TosBrowser.Visibility = Visibility.Hidden;
            DataContext = this;
                       

            #region ToS

            if (!Config.Instance.TosAccepted)
            {
                RightWindowCommands.Visibility = Visibility.Collapsed;
            }
            else
            {
                MainTabControl.SelectedIndex = 1;
            }

            #endregion                            

            Config.Instance.FirstRun = false;            

            NewsTabItem.Visibility = Visibility.Hidden;            
            SettingsTabItem.Visibility = Visibility.Hidden;
        }

        private async void ShowLoginDialog()
        {
            MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Theme;
            var result =
                await
                    this.ShowLoginAsync(
                        "Project Glare", "Sign in",
                        new LoginDialogSettings
                        {
                            ColorScheme = MetroDialogOptions.ColorScheme,
                            NegativeButtonVisibility = Visibility.Visible
                        });

            var loginResult = new Tuple<bool, string>(false, "Cancel button pressed");
            if (result != null)
            {
                var hash = Auth.Hash(result.Password);

                loginResult = Auth.Login(result.Username, hash);
            }

            if (result != null && loginResult.Item1)
            {
                //Save the login credentials
                Config.Instance.Username = result.Username;
                Config.Instance.Password = Auth.Hash(result.Password);

                OnLogin(result.Username);
            }
            else
            {
                if (result == null)
                {
                    ///MainWindow_OnClosing(null, null);
                    Environment.Exit(0);
                }

                ShowAfterLoginDialog(
                    string.Format(Utility.GetMultiLanguageText("FailedToLogin"), loginResult.Item2), true);
                Utility.Log(
                    LogStatus.Error, Utility.GetMultiLanguageText("Login"),
                    string.Format(
                        Utility.GetMultiLanguageText("LoginError"), (result != null ? result.Username : "null"),
                        loginResult.Item2), Logs.MainLog);
            }
        }

        private async void ShowAfterLoginDialog(string message, bool showLoginDialog)
        {
            await this.ShowMessageAsync("Login", message);
            if (showLoginDialog)
            {
                ShowLoginDialog();
            }
        }

        public async void ShowTextMessage(string title, string message)
        {
            var visibility = Browser.Visibility;
            Browser.Visibility = Visibility.Hidden;
            await this.ShowMessageAsync(title, message);
            Browser.Visibility = (visibility == Visibility.Hidden) ? Visibility.Hidden : Visibility.Visible;
        }

        private void OnLogin(string username)
        {
            Utility.Log(LogStatus.Ok, "Login", string.Format("Succesfully signed in as {0}", username), Logs.MainLog);
            Browser.Visibility = Visibility.Visible;
            TosBrowser.Visibility = Visibility.Visible;
            try
            {
                Utility.MapClassToXmlFile(typeof(Config), Config.Instance, Directories.ConfigFilePath);
            }
            catch
            {
                MessageBox.Show(Utility.GetMultiLanguageText("ConfigWriteError"));
            }            
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
