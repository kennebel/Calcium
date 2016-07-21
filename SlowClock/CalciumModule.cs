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
		protected Page _InitialPage;
		#endregion

		#region Properties
		public string ModuleType
		{
			get
			{
				return "calcium.overlay";
			}
		}

        public string ModuleName
        {
            get
            {
                return "SlowClock";
            }
        }

		public Page InitialPage
		{
			get
			{
				if (_InitialPage == null)
				{
					_InitialPage = new ClockUI();
				}

				return _InitialPage;
			}
		}
		#endregion
	}
}
