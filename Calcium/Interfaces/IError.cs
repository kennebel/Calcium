using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcium
{
    public enum ErrorSeverity { None = 0, Informational, Warning, Critical };

    public interface IError
    {
        string Message { get; set; }
        DateTime ReportedOn { get; set; }
        ErrorSeverity Severity { get; set; }

        string ToString();
    }
}
