using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcium
{
    public interface ISettings
    {
        void SetSetting(string module, string name, string value);

        string GetSetting(string module, string name, bool nullOnNotFound = true);
    }
}
