using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcium
{
    public class SettingsHolderViewModel : BaseNotify
    {
        #region Fields
        protected ObservableCollection<ModuleWithSettings> _ModulesWithSettings = new ObservableCollection<ModuleWithSettings>();
        #endregion

        #region Properties
        public ObservableCollection<ModuleWithSettings> ModulesWithSettings
        {
            get
            {
                return _ModulesWithSettings;
            }
            set
            {
                if (_ModulesWithSettings != value)
                {
                    _ModulesWithSettings = value ?? new ObservableCollection<ModuleWithSettings>();
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Methods
        public void SetUp()
        {
            // Iterate through the loaded modules to look for ones with settings
            foreach (KeyValuePair<string, List<ICalciumModule>> kvp in MainWindow.instance.TheModules.Modules)
            {
                kvp.Value.ForEach(e =>
                {
                    if (e is ICalciumModuleWithSettings)
                    {
                        ModulesWithSettings.Add(ModuleWithSettings.Convert((ICalciumModuleWithSettings)e)); // TODO: Sort this list for consistent UX
                    }
                });
            }
        }
        #endregion

        #region Inner Classes
        public class ModuleWithSettings
        {
            public string ModuleName { get; set; }

            public ICalciumModuleWithSettings ModuleProper { get; set; }

            public static ModuleWithSettings Convert(ICalciumModuleWithSettings fromModule)
            {
                return new ModuleWithSettings() { ModuleName = fromModule.ModuleName, ModuleProper = fromModule };
            }
        }
        #endregion
    }
}
