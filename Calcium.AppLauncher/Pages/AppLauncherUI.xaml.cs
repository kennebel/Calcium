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
        #region Constants
        public const int COLUMNS = 3;
        #endregion

        #region Properties
        public AppLauncherViewModel ViewModel
        {
            get
            {
                return this.DataContext as AppLauncherViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
        #endregion

        #region Construct / Destruct
        public AppLauncherUI() : this(null) { }

        public AppLauncherUI(AppLauncherViewModel viewModel)
        {
            InitializeComponent();

            ViewModel = viewModel ?? new AppLauncherViewModel();

            Setup();
        }
        #endregion

        #region Events
        void Shortcut_Click(object sender, RoutedEventArgs e)
        {
            AppLaunch OneApp = (AppLaunch)((Button)sender).Tag;

            ProcessStartInfo PSI = new ProcessStartInfo(OneApp.Target) { UseShellExecute = false };
            if (!String.IsNullOrWhiteSpace(OneApp.Arguments)) { PSI.Arguments = OneApp.Arguments; }
            if (!String.IsNullOrWhiteSpace(OneApp.StartIn)) { PSI.WorkingDirectory = OneApp.StartIn; }
            Process.Start(PSI);
        }
        #endregion

        #region Methods
        protected void Setup()
        {
            // Prep
            Content.Children.Clear();
            ViewModel.AppsToShow = new List<AppLaunch>();

            // TODO: Pull list of applications from settings, also to do, make the settings screen work; temp list for testing
            ViewModel.AppsToShow.Add(new AppLaunch() { Name = "RDP", Target = @"C:\Program Files (x86)\Microsoft\Remote Desktop Connection Manager\RDCMan.exe" });
            ViewModel.AppsToShow.Add(new AppLaunch() { Name = "Calc", Target = @"C:\Windows\system32\calc.exe" });
            ViewModel.AppsToShow.Add(new AppLaunch() { Name = "SQL", Target = @"C:\Program Files (x86)\Microsoft SQL Server\110\Tools\Binn\ManagementStudio\Ssms.exe" });
            ViewModel.AppsToShow.Add(new AppLaunch() { Name = "putty", Target = @"C:\Users\cunninghamJ\Apps\putty\putty.exe" });
            ViewModel.AppsToShow.Add(new AppLaunch() { Name = "pageant", Target = @"C:\Users\cunninghamJ\Apps\putty\pageant.exe" });
            ViewModel.AppsToShow.Add(new AppLaunch() { Name = "PR", Target = @"C:\Program Files\Git\git-bash.exe", StartIn = @"C:\Users\cunninghamJ\Documents\SourceTree\plateau-replacement" });

            // Build columns and rows
            for (int i = 0; i < COLUMNS; i++) { Content.ColumnDefinitions.Add(new ColumnDefinition()); }

            int Rows = Math.Max((int)Math.Ceiling((double)ViewModel.AppsToShow.Count / (double)COLUMNS), 2);
            for (int i = 0; i < Rows; i++) { Content.RowDefinitions.Add(new RowDefinition()); }

            // Build Buttons
            int Col = 0;
            int Row = 0;
            Button TmpButton = null;
            foreach (AppLaunch OneApp in ViewModel.AppsToShow)
            {
                TmpButton = new Button() { Content = new Viewbox() { Child = new TextBlock() { Text = OneApp.Name } }, Tag = OneApp, Margin = new Thickness(2), Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(OneApp.Color)) };
                TmpButton.Click += Shortcut_Click;
                Content.Children.Add(TmpButton);
                Grid.SetRow(TmpButton, Row);
                Grid.SetColumn(TmpButton, Col);

                Col++;
                if (Col >= COLUMNS)
                {
                    Col = 0;
                    Row++;
                }
            }
        }
        #endregion
    }
}
