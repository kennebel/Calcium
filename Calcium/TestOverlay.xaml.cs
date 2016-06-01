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
			Radius = 75d;

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
				DrawOneTick(Angle, Radius / 20d, fill: Brushes.Blue);
				Console.WriteLine(Angle);
			}
			for (int i = 0; i < MinorTicks; i++)
			{
				Angle = (360 / MinorTicks) * i;
				DrawOneTick(Angle, Radius / 40d);
				Console.WriteLine(Angle);
			}
		}

		public void DrawOneTick(double angle, double width, double height = 0d, Brush fill = null)
		{
			if (height == 0d) { height = width; }
			if (fill == null) { fill = Brushes.Black; }

			//Rectangle rect = new Rectangle() { Width = width, Height = height, Fill = fill, RenderTransformOrigin= new Point(0.5d, 0.5d) };
			Ellipse rect = new Ellipse() { Width = width, Height = height, Fill = fill, RenderTransformOrigin= new Point(0.5d, 0.5d) };
			//rect.RenderTransformOrigin = new Point(0.5d, 0.5d);
			//TransformGroup TG = new TransformGroup();
			//TG.Children.Add(new RotateTransform(angle < 180 ? angle : angle - 180d));
			//TG.Children.Add(new RotateTransform(angle));
			//TG.Children.Add(new TranslateTransform((Radius * Math.Cos(angle.ToRadians())) + Radius, (Radius * Math.Sin(angle.ToRadians())) + Radius));
			//rect.RenderTransform = TG;
			rect.RenderTransform = new TranslateTransform((Radius * Math.Cos(angle.ToRadians())) + Radius, (Radius * Math.Sin(angle.ToRadians())) + Radius);


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
