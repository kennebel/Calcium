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

namespace Calcium.AppLauncher
{
    /// <summary>
    /// Interaction logic for AppLauncherUI.xaml
    /// </summary>
    public partial class AppLauncherUI : Page
    {
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

        #region Methods
        protected void Setup()
        {
            // Prep
            Content.Children.Clear();
            ViewModel.AppsToShow = new List<AppLaunch>();

            // TODO: Pull list of applications from settings, also to do, make the settings screen work; temp list for testing
            ViewModel.AppsToShow.Add(new AppLaunch() { Name = "Remote Desktops", Target = @"C:\Program Files (x86)\Microsoft\Remote Desktop Connection Manager\RDCMan.exe" });
            ViewModel.AppsToShow.Add(new AppLaunch() { Name = "Calculator", Target = @"%windir%\system32\calc.exe" });

            // Build UI
        }
        #endregion
    }
}
