using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Calcium
{
    public class Settings : ISettings
    {
        public const string SETTINGS_FILE = "Calcium.jset";

        protected Dictionary<string, Dictionary<string, string>> StoredSettings { get; set; }

        public Settings()
        {
            StoredSettings = new Dictionary<string, Dictionary<string, string>>();
        }

        public void SetSetting(string module, string name, string value)
        {
            if (!StoredSettings.ContainsKey(module))
            {
                StoredSettings.Add(module, new Dictionary<string, string>());
            }
            StoredSettings[module][name] = value;
            Save();
        }

        public string GetSetting(string module, string name, bool nullOnNotFound = true)
        {
            if (StoredSettings.ContainsKey(module) && StoredSettings[module].ContainsKey(name))
            {
                return StoredSettings[module][name];
            }

            if (nullOnNotFound)
            {
                return null;
            }
            else
            {
                throw new Exception(string.Format("Setting not found: {0}/{1}", module, name));
            }
        }

        public void Load()
        {

        }

        protected void Save()
        {
            
        }
    }
}
