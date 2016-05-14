using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Calcium
{
	public interface ICalciumModule
	{
		string ModuleType { get; }

		Page OpeningPage { get; }
	}
}
