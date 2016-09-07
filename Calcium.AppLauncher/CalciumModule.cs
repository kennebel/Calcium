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
        protected ISettingsPage _SettingsPage = null;
        protected ISettingsManager _TheSettingsManager = null;
        protected Settings _TheSettings = new Settings();
        #endregion

        #region Properties
        public static CalciumModule instance { get; private set; }

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

        public ISettingsPage SettingsPage
        {
            get
            {
                if (_SettingsPage == null)
                {
                    _SettingsPage = new AppSettingsUI();
                }
                return _SettingsPage;
            }
        }

        public ISettingsManager TheSettingsManager
        {
            get
            {
                return _TheSettingsManager;
            }
            set
            {
                _TheSettingsManager = value;
                if (value != null)
                {
                    TheSettings.Load();
                }
            }
        }

        public Settings TheSettings
        {
            get
            {
                return _TheSettings;
            }
            set
            {
                _TheSettings = value ?? new Settings();
            }
        }
        #endregion

        #region Construct / Destruct
        public CalciumModule()
        {
            instance = this;
        }
        #endregion
    }
}
