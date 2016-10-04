using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Calcium.AppLauncher
{
    /// <summary>
    /// Interaction logic for AppLauncherUI.xaml
    /// </summary>
    public partial class AppLauncherUI : Page
    {
        #region Properties
        public Settings TheSettings
        {
            get
            {
                return CalciumModule.instance.TheSettings;
            }
        }
        #endregion

        #region Construct / Destruct
        public AppLauncherUI()
        {
            InitializeComponent();
            Setup();
        }
        #endregion

        #region Events
        void Shortcut_Click(object sender, RoutedEventArgs e)
        {
            AppLaunch OneApp = (AppLaunch)((Button)sender).Tag;

            try
            {
                if (!System.IO.File.Exists(OneApp.Target))
                {
                    ErrorManager.Report("Missing App Launcher Target: " + OneApp.Target, ErrorSeverity.Critical);
                    return;
                }

                ProcessStartInfo PSI = new ProcessStartInfo(OneApp.Target) { UseShellExecute = false };
                if (!String.IsNullOrWhiteSpace(OneApp.Arguments)) { PSI.Arguments = OneApp.Arguments; }
                if (!String.IsNullOrWhiteSpace(OneApp.StartIn)) { PSI.WorkingDirectory = OneApp.StartIn; }
                Process.Start(PSI);
            }
            catch (Exception ex)
            {
                ErrorManager.Report(ex.ToString(), ErrorSeverity.Critical);
            }
        }
        #endregion

        #region Methods
        protected void Setup()
        {
            // Prep
            Content.Children.Clear();

            // Build columns and rows
            for (int i = 0; i < TheSettings.ColumnCount; i++) { Content.ColumnDefinitions.Add(new ColumnDefinition()); }

            int Rows = Math.Max((int)Math.Ceiling((double)TheSettings.AppsToShow.Count / (double)TheSettings.ColumnCount), 2);
            for (int i = 0; i < Rows; i++) { Content.RowDefinitions.Add(new RowDefinition()); }

            // Build Buttons
            int Col = 0;
            int Row = 0;
            Button TmpButton = null;
            foreach (AppLaunch OneApp in TheSettings.AppsToShow)
            {
                TmpButton = new Button() { Content = new Viewbox() { Child = new TextBlock() { Text = OneApp.Name } }, Tag = OneApp, Margin = new Thickness(2), Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(OneApp.Color)) };
                TmpButton.Click += Shortcut_Click;
                Content.Children.Add(TmpButton);
                Grid.SetRow(TmpButton, Row);
                Grid.SetColumn(TmpButton, Col);

                Col++;
                if (Col >= TheSettings.ColumnCount)
                {
                    Col = 0;
                    Row++;
                }
            }
        }
        #endregion
    }
}
