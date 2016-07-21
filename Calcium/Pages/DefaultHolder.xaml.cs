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
    /// Interaction logic for DefaultView.xaml
    /// </summary>
    public partial class DefaultHolder : Page
    {
        public DefaultHolder(ModuleManager theModules, SettingsManager theSettings)
        {
            InitializeComponent();

            Setup(theModules, theSettings);
        }

        public void Setup(ModuleManager theModules, SettingsManager theSettings)
        {
            Content.Children.Clear();

            string UtilityKey = "calcium.utility";
            if (theModules.Modules.ContainsKey(UtilityKey))
            {
                RowDefinition AutoRow;
                Frame Holder;
                int RowCount = 0;

                // TODO: Use settings to determine which utilities to load and in which order
                foreach (var OneModule in theModules.Modules[UtilityKey])
                {
                    AutoRow = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };
                    Content.RowDefinitions.Add(AutoRow);

                    Holder = new Frame() { NavigationUIVisibility = NavigationUIVisibility.Hidden };
                    Holder.Navigate(OneModule.InitialPage);
                    Grid.SetRow(Holder, RowCount);
                    RowCount++;
                    Content.Children.Add(Holder);
                }
            }
        }
    }
}
