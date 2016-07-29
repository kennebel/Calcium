using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcium.AppLauncher
{
    public class Settings
    {
        #region Constants
        public const int DEFAULT_COLUMNS = 3;
        #endregion

        #region Fields
        protected int _ColumnCount = DEFAULT_COLUMNS;
        protected List<AppLaunch> _AppsToShow = new List<AppLaunch>();
        protected List<Dictionary<string, string>> _AppsToShowRaw = new List<Dictionary<string, string>>();
        #endregion

        #region Properties
        protected ISettingsManager SM { get { return CalciumModule.instance.TheSettingsManager; } }

        protected string ModuleName { get { return CalciumModule.instance.ModuleName; } }

        public int ColumnCount
        {
            get
            {
                return _ColumnCount;
            }
            set
            {
                _ColumnCount = value < 1 ? DEFAULT_COLUMNS : value;
            }
        }

        public List<AppLaunch> AppsToShow
        {
            get
            {
                return _AppsToShow;
            }
            set
            {
                _AppsToShow = value ?? new List<AppLaunch>();
            }
        }

        public List<Dictionary<string, string>> AppsToShowRaw
        {
            get
            {
                return _AppsToShowRaw;
            }
            set
            {
                _AppsToShowRaw = value ?? new List<Dictionary<string, string>>();
            }
        }
        #endregion

        #region Methods
        public void Load()
        {
            // ColumnCount
            string TmpColumnCount = SM.GetSetting(ModuleName, "ColumnCount");
            if (!string.IsNullOrEmpty(TmpColumnCount))
            {
                int TmpInt = 0;
                if (int.TryParse(TmpColumnCount, out TmpInt)) { ColumnCount = TmpInt; }
            }
            else { ColumnCount = DEFAULT_COLUMNS; }

            // Apps
            List<string> Apps = JsonConvert.DeserializeObject<List<string>>(SM.GetSetting(ModuleName, "Apps"));
            foreach (string OneApp in Apps)
            {
                AppsToShow.Add(AppLaunch.FromString(OneApp));
                AppsToShowRaw.Add(JsonConvert.DeserializeObject<Dictionary<string, string>>(OneApp));
            }
        }

        public void Save()
        {
            Dictionary<string, string> NewSettings = new Dictionary<string, string>();

            NewSettings.Add("ColumnCount", ColumnCount.ToString());
            NewSettings.Add("Apps", JsonConvert.SerializeObject(AppsToShow));

            SM.SetSettings(ModuleName, NewSettings);
        }

        public void RebuildApps()
        {

        }
        #endregion
    }
}
