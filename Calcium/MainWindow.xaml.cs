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
        public ModuleManager MM { get; protected set; }

        public SettingsManager SM { get; set; } 
        #endregion

        #region Construct / Destruct
        public MainWindow()
		{
			InitializeComponent();

            // Prep
            MM = new ModuleManager();
            SM = SettingsManager.Load();

            // Pop Overlay Screen
            if (MM.Overlay != null)
            {
                Overlay.Navigate(MM.Overlay);
            }
		}
        #endregion
    }
}
