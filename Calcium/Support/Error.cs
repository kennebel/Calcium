using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcium
{
    public class Error : IError
    {
        #region Fields
        protected string _Message = "";
        protected string _DateFormat = "yyyy-MM-dd HH:mm:ss";
        #endregion

        #region Properties
        public string Message
        {
            get
            {
                return _Message;
            }

            set
            {
                _Message = value ?? "";
            }
        }

        public DateTime ReportedOn { get; set; }

        public int Severity { get; set; }

        public string DateFormat
        {
            get
            {
                return _DateFormat;
            }
            set
            {
                _DateFormat = value ?? "";
            }
        }
        #endregion

        #region Construct / Destruct
        public Error()
        {
            ReportedOn = DateTime.Now;
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return string.Format("{0} ({1}): {2}", ReportedOn.ToString(DateFormat), Severity, Message);
        }
        #endregion
    }
}
