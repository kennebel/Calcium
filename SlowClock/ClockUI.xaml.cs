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

namespace Calcium.SlowClock
{
	/// <summary>
	/// Interaction logic for ClockUI.xaml
	/// </summary>
	public partial class ClockUI : Page
	{
		#region Properties
		public double Radius { get; set; }
		#endregion

		#region Construct / Destruct
		public ClockUI()
		{
			InitializeComponent();

			Init();
		}
		#endregion

		#region Methods
		public void Init()
		{
			Radius = 150d;

			DrawTicks();
		}

		public void DrawTicks()
		{
			DrawOneTick(0, Radius / 10, 1.5);
			DrawOneTick(90, Radius / 10, 1.5);
		}

		public void DrawOneTick(double angle, double width, double height)
		{
			Rectangle rect = new Rectangle() { Width = width, Height = height, Fill = Brushes.LightGray };
			rect.RenderTransformOrigin = new Point(0.5d, 0.5d);
			rect.LayoutTransform = new RotateTransform(angle);
			TickLayer.Children.Add(rect);
		}
		#endregion
	}
}
