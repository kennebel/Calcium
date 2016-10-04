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

namespace Calcium.Pages
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class SettingsHolder : Page
    {
        #region Properties
        public SettingsHolderViewModel ViewModel
        {
            get
            {
                return this.DataContext as SettingsHolderViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        public ISettingsPage CurrentSubSettings { get; set; }
        #endregion

        #region Construct / Destruct
        public SettingsHolder() : this(viewModel: null)
        {
        }

        public SettingsHolder(SettingsHolderViewModel viewModel)
        {
            InitializeComponent();

            ViewModel = viewModel ?? new SettingsHolderViewModel();
            ViewModel.SetUp();
        }
        #endregion

        #region Events
        private void ShowSubSettings_Click(object sender, RoutedEventArgs e)
        {
            var Selected = ((Button)sender).Tag as ICalciumModuleWithSettings;
            if (Selected != null)
            {
                CurrentSubSettings = Selected.SettingsPage as ISettingsPage;
                SettingsArea.Navigate(CurrentSubSettings);
                SettingsAreaRig.Visibility = Visibility.Visible;
            }
        }

        private void CancelSubSettings_Click(object sender, RoutedEventArgs e)
        {
            CurrentSubSettings.Cancel();
            SettingsAreaRig.Visibility = Visibility.Hidden;
        }

        private void SaveSubSettings_Click(object sender, RoutedEventArgs e)
        {
            CurrentSubSettings.Save();
            SettingsAreaRig.Visibility = Visibility.Hidden;
        }
        #endregion
    }
}
