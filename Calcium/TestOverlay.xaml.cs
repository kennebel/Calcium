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
	/// Interaction logic for TestOverlay.xaml
	/// </summary>
	public partial class TestOverlay : Page
	{
		#region Properties
		public double Radius { get; set; }
		#endregion

		#region Construct / Destruct
		public TestOverlay()
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

		// Inspiration pulled from Stopwatch Netbeans projec.
		public void DrawTicks()
		{
			int MainTIcks = 12;
			int MinorTicks = 60;
			double Angle = 0d;

			for (int i = 0; i < MainTIcks; i++)
			{
				Angle = (360 / MainTIcks) * i;
				DrawOneTick(Angle, Radius / 10, 1.5);
			}
			for (int i = 0; i < MinorTicks; i++)
			{
				Angle = (360 / MinorTicks) * i;
				DrawOneTick(Angle, Radius / 20, 1);
			}
		}

		public void DrawOneTick(double angle, double width, double height)
		{
			Rectangle rect = new Rectangle() { Width = width, Height = height, Fill = Brushes.Black };
			//rect.RenderTransformOrigin = new Point(0.5d, 0.5d);
			TransformGroup TG = new TransformGroup();
			TG.Children.Add(new RotateTransform(angle));
			TG.Children.Add(new TranslateTransform((Radius * Math.Cos(angle.ToRadians())) + Radius + width, (Radius * Math.Sin(angle.ToRadians())) + Radius + height));
			rect.RenderTransform = TG;
			
			TickLayer.Children.Add(rect);
		}
		#endregion
	}

	/// <summary>
	/// Convert to Radians.
	/// </summary>
	/// <see cref="https://www.stormconsultancy.co.uk/blog/development/code-snippets/convert-an-angle-in-degrees-to-radians-in-c/"/>
	/// <param name="val">The value to convert to radians</param>
	/// <returns>The value in radians</returns>
	public static class NumericExtensions
	{
		public static double ToRadians(this double val)
		{
			return (Math.PI / 180) * val;
		}
	}
}
