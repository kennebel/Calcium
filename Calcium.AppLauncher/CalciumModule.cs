using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Calcium.AppLauncher
{
    public class CalciumModule : ICalciumModule
    {
        #region Fields
        protected Page _InitialPage;
        #endregion

        #region Properties
        public Page InitialPage
        {
            get
            {
                if (_InitialPage == null)
                {
                    _InitialPage = new AppLauncherUI();
                }

                return _InitialPage;
            }
        }

        public string ModuleName
        {
            get
            {
                return "Application Launcher";
            }
        }

        public string ModuleType
        {
            get
            {
                return "calcium.utility";
            }
        }
        #endregion
    }
}
