using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcium
{
    public interface ISettingsManager
    {
        Dictionary<string, Dictionary<string, string>> StoredSettings { get; set; }

        void SetSetting(string module, string name, string value);

        void SetSettings(string module, Dictionary<string, string> moduleSettings);

        string GetSetting(string module, string name, bool nullOnNotFound = true);

        Dictionary<string, string> GetSettings(string module, bool nullOnNotFound = true);
    }
}
