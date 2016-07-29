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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class AppSettingsUI : Page
    {
        #region Properties
        public SettingsViewModel ViewModel
        {
            get
            {
                return this.DataContext as SettingsViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
        #endregion

        #region Construct / Destruct
        public AppSettingsUI() : this(null) { }

        public AppSettingsUI(SettingsViewModel viewModel)
        {
            InitializeComponent();

            ViewModel = viewModel ?? new SettingsViewModel();

            Setup();
        }
        #endregion

        #region Methods
        protected void Setup()
        {
            ViewModel.Load();
        }
        #endregion
    }
}
