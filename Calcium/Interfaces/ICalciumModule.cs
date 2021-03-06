﻿using System;
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

        string ModuleName { get; }

		Page InitialPage { get; }
	}

    public interface ICalciumModuleWithSettings : ICalciumModule
    {
        ISettingsPage SettingsPage { get; }

        ISettingsManager TheSettingsManager { set; }
    }
}
