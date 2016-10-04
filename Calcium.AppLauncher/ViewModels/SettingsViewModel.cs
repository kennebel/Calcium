using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcium.AppLauncher
{
    public class SettingsViewModel : BaseNotify
    {
        #region Fields
        protected ObservableCollection<AppLaunch> _Apps = new ObservableCollection<AppLaunch>();
        protected int _ColumnCount = Settings.DEFAULT_COLUMNS;
        #endregion

        #region Properties
        public Settings TheSettings
        {
            get
            {
                return CalciumModule.instance.TheSettings;
            }
        }

        public ObservableCollection<AppLaunch> Apps
        {
            get
            {
                return _Apps;
            }
            set
            {
                if (_Apps != value)
                {
                    _Apps = value ?? new ObservableCollection<AppLaunch>();
                    OnPropertyChanged();
                }
            }
        }

        public int ColumnCount
        {
            get
            {
                return _ColumnCount;
            }
            set
            {
                if (_ColumnCount != value)
                {
                    _ColumnCount = Math.Max(1, value);
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Methods
        public void Load()
        {
            // Proactively clear
            Apps.Clear();

            // Load Data
            TheSettings.AppsToShow.ForEach(e => Apps.Add(e));
            ColumnCount = TheSettings.ColumnCount;
        }

        public void Save()
        {
            TheSettings.ColumnCount = ColumnCount;
            TheSettings.Save();
        }
        #endregion
    }
}
