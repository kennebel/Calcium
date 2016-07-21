using Calcium.Pages;
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

namespace Calcium
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        #region Properties
        public MainWindowViewModel ViewModel
        {
            get
            {
                return this.DataContext as MainWindowViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        public ModuleManager TheModules { get; protected set; }

        public SettingsManager TheSettings { get; set; }

        public DefaultHolder UnderlayHolder { get; set; } // TODO: Enable replacement of Underlay holder with a module provided option

        public SettingsHolder SettingsHolder { get; set; }
        #endregion

        #region Construct / Destruct
        public MainWindow() : this(viewModel:null)
        {
        }

        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();

            ViewModel = viewModel ?? new MainWindowViewModel();

            SetUp();
		}
        #endregion

        #region Events
        private void NotificationBadge_MouseUp(object sender, MouseButtonEventArgs e)
        {
            NotificationList.Visibility = Visibility.Visible;
        }

        private void CloseNotifications_MouseUp(object sender, MouseButtonEventArgs e)
        {
            NotificationList.Visibility = Visibility.Hidden;
            ViewModel?.ClearNotifications();
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            ViewModel.OverlayVisibility = Visibility.Hidden;
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            ViewModel.OverlayVisibility = Visibility.Visible;
        }
        #endregion

        #region Methods
        protected void SetUp()
        {
            // Title Version
            Title += ": " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            // Prep
            TheModules = new ModuleManager();
            TheSettings = SettingsManager.Load();

            // Pop Overlay Screen
            if (TheModules.Overlay != null)
            {
                Overlay.Navigate(TheModules.Overlay);
            }

            // Listen for errors in order to update badge
            ViewModel?.ListenForErrors();

            // Prep Underlay
            UnderlayHolder = new DefaultHolder(TheModules, TheSettings);
            PresentUnderlay();

            SettingsHolder = new SettingsHolder();
        }

        public void PresentUnderlay()
        {
            // TODO: Prevent navigation if already active
            Underlay.Navigate(UnderlayHolder);
        }

        public void PresentSettings()
        {
            // TODO: Prevent navigation if already active
            Underlay.Navigate(SettingsHolder);
        }
        #endregion
    }
}
