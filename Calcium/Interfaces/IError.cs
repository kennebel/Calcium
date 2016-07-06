using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcium
{
    public interface IError
    {
        string Message { get; set; }
        DateTime ReportedOn { get; set; }
        int Severity { get; set; }

        string ToString();
    }
}
