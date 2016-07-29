using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcium.AppLauncher
{
    public class SettingsViewModel : BaseNotify
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Methods
        public void Load()
        {
            var RawSettings = CalciumModule.instance.TheSettingsManager.GetSettings(CalciumModule.instance.ModuleName);
            if (RawSettings != null)
            {

            }
        }

        public void Save()
        {

        }
        #endregion
    }
}
