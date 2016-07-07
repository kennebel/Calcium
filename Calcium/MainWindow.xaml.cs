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

        public ModuleManager MM { get; protected set; }

        public SettingsManager SM { get; set; }
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
        #endregion

        #region Methods
        protected void SetUp()
        {
            // Title Version
            Title += ": " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            // Prep
            MM = new ModuleManager();
            SM = SettingsManager.Load();

            // Pop Overlay Screen
            if (MM.Overlay != null)
            {
                Overlay.Navigate(MM.Overlay);
            }

            // Listen for errors in order to update badge
            ViewModel?.ListenForErrors();
        }
        #endregion
    }
}
