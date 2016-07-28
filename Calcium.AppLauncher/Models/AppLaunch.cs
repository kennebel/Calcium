using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcium.AppLauncher
{
    public class AppLaunch
    {
        #region Constants
        public const string DEFAULT_COLOR = "#00FF00";
        #endregion

        #region Fields
        protected string _Color = DEFAULT_COLOR;
        #endregion

        #region Properties
        public string Name { get; set; }

        public string Target { get; set; }

        public string StartIn { get; set; }

        public string Arguments { get; set; }

        public string Color
        {
            get
            {
                return _Color;
            }
            set
            {
                _Color = string.IsNullOrWhiteSpace(value) ? DEFAULT_COLOR : value;
            }
        }

        // TODO: Add support for drop down style button for a compact set up
        public List<AppLaunch> SubElements { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }

        public static AppLaunch FromString(string jsonAppLaunch)
        {
            return JsonConvert.DeserializeObject<AppLaunch>(jsonAppLaunch);
        }
        #endregion
    }
}
