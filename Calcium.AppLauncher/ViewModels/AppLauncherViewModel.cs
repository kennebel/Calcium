using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcium.AppLauncher
{
    public class AppLauncherViewModel
    {
        #region Constants
        public const int DEFAULT_COLUMNS = 3;
        #endregion

        #region Fields
        protected int _ColumnCount = DEFAULT_COLUMNS;
        #endregion

        #region Properties
        public List<AppLaunch> AppsToShow { get; set; }

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
        #endregion
    }
}
