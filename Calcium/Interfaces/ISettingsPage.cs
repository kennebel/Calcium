using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcium
{
    public interface ISettingsPage
    {
        void Save();

        void Cancel();
    }
}
