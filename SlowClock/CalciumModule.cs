using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Calcium.SlowClock
{
	public class CalciumModule : ICalciumModule
	{
		#region Fields
		protected Page _OpeningPage;
		#endregion

		#region Properties
		public string ModuleType
		{
			get
			{
				return "calcium.overlay";
			}
		}

		public Page OpeningPage
		{
			get
			{
				if (_OpeningPage == null)
				{
					_OpeningPage = new ClockUI();
				}

				return _OpeningPage;
			}
		}
		#endregion
	}
}
