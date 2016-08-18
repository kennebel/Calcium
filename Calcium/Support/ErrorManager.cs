using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcium
{
    public delegate void ErrorReportHandler(object sender, IError reported);

    public class ErrorManager
    {
        #region Event Points
        public static event ErrorReportHandler ErrorReport;
        #endregion

        #region Methods
        public static void Report(string message, ErrorSeverity severity = ErrorSeverity.None, object sender = null)
        {
            OnErrorReport(sender, new Error() { Message = message, Severity = severity });
        }
        #endregion

        #region Event Triggers
        private static void OnErrorReport(object sender, IError reported)
        {
            ErrorReport?.Invoke(sender, reported);
        }
        #endregion
    }
}
