using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Calcium.AppLauncher
{
    public class CalciumModule : ICalciumModuleWithSettings
    {
        #region Fields
        protected Page _InitialPage = null;
        protected Page _SettingsPage = null;
        protected ISettingsManager _TheSettings = null;
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

        public Page SettingsPage
        {
            get
            {
                if (_SettingsPage == null)
                {
                    _SettingsPage = new AppSettings();
                }
                return _SettingsPage;
            }
        }

        public ISettingsManager TheSettings
        {
            get
            {
                return _TheSettings;
            }
            set
            {
                _TheSettings = value;
            }
        }
        #endregion
    }
}
