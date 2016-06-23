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
using System.Windows.Threading;

namespace Calcium
{
	/// <summary>
	/// Interaction logic for TestOverlay.xaml
	/// </summary>
	public partial class TestOverlay : Page
	{
		#region Properties
		public double Radius { get; set; }
        public double LargeDot { get; set; }
        public double SmallDot { get; set; }

        public double Offset
        {
            get
            {
                return LargeDot / 2d;
            }
        }

        public Line SlowHand { get; set; }

        public DispatcherTimer MoveHandTimer { get; set; }
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
            LargeDot = 3.75d;
            SmallDot = 1.9d;

			DrawTicks();
            DrawHand(new TimeSpan(12, 0, 0));

            //MoveHandTimer = new DispatcherTimer() { Interval = new TimeSpan(0, 1, 0) };
            MoveHandTimer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 10) };
            MoveHandTimer.Tick += (object sender, EventArgs e) => DrawHand();
            MoveHandTimer.Start();
		}

        // Inspiration pulled from Stopwatch Netbeans projec.
        public void DrawTicks()
		{
			//int MainTIcks = 12;
			//int MinorTicks = 60;
            int MainTicks = 24;
            int MinorTicks = 120;
            double Angle = 0d;

            for (int i = 0; i < MinorTicks; i++)
            {
                Angle = (360 / MinorTicks) * i;
                DrawOneTick(Angle, SmallDot, fill: Brushes.Blue);
                Console.WriteLine(Angle);
            }
            for (int i = 0; i < MainTicks; i++)
			{
				Angle = (360 / MainTicks) * i;
				DrawOneTick(Angle, LargeDot);
				Console.WriteLine(Angle);
			}
		}

		public void DrawOneTick(double angle, double width, double height = 0d, Brush fill = null)
		{
			if (height == 0d) { height = width; }
			if (fill == null) { fill = Brushes.Black; }

            // http://stackoverflow.com/a/2939487 ~ "translation does not use an origin so the RenderTransformOrigin does not apply to a TranslateTransform"
            ////Rectangle rect = new Rectangle() { Width = width, Height = height, Fill = fill, RenderTransformOrigin= new Point(0.5d, 0.5d) };
            //Ellipse rect = new Ellipse() { Width = width, Height = height, Fill = fill };
            //rect.RenderTransformOrigin = fill == Brushes.Black ? new Point(0d, 0d) : new Point(1d, 1d);
            ////TransformGroup TG = new TransformGroup();
            ////TG.Children.Add(new RotateTransform(angle < 180 ? angle : angle - 180d));
            ////TG.Children.Add(new RotateTransform(angle));
            ////TG.Children.Add(new TranslateTransform((Radius * Math.Cos(angle.ToRadians())) + Radius, (Radius * Math.Sin(angle.ToRadians())) + Radius));
            ////rect.RenderTransform = TG;
            //rect.RenderTransform = new TranslateTransform((Radius * Math.Cos(angle.ToRadians())) + Radius, (Radius * Math.Sin(angle.ToRadians())) + Radius);
            //TickLayer.Children.Add(rect);

            Grid child = new Grid() { Width = LargeDot, Height = LargeDot };
            Ellipse rect = new Ellipse() { Width = width, Height = height, Fill = fill };
            rect.HorizontalAlignment = HorizontalAlignment.Center;
            rect.VerticalAlignment = VerticalAlignment.Center;
            child.Children.Add(rect);
            child.RenderTransform = new TranslateTransform((Radius * Math.Cos(angle.ToRadians())) + Radius - Offset, (Radius * Math.Sin(angle.ToRadians())) + Radius - Offset);

            TickLayer.Children.Add(child);
		}

        public void DrawHand(DateTime theDate)
        {
            DrawHand(theDate.TimeOfDay);
        }

        public void DrawHand(TimeSpan timeOfDay)
        {
            DrawHand(timeOfDay.TotalMinutes / 1440d);
        }

        public void DrawHand(double? normalized24HourTime = null)
        {
            if (SlowHand == null)
            {
                SlowHand = new Line() { Stroke = Brushes.Black, StrokeThickness = 1, HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
                TickLayer.Children.Add(SlowHand);
            }

            if (!normalized24HourTime.HasValue)
            {
                normalized24HourTime = DateTime.Now.TimeOfDay.TotalMinutes / 1440d;
            }

            double Offset = LargeDot / 2d;
            double Angle = (360d * normalized24HourTime.Value) - 90d;
            SlowHand.X1 = Radius;
            SlowHand.Y1 = Radius;
            SlowHand.X2 = (Radius * Math.Cos(Angle.ToRadians())) + Radius;
            SlowHand.Y2 = (Radius * Math.Sin(Angle.ToRadians())) + Radius;
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
