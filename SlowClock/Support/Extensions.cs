using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcium.SlowClock
{

    /// <summary>
    /// Convert to Radians.
    /// </summary>
    /// <see cref="https://www.stormconsultancy.co.uk/blog/development/code-snippets/convert-an-angle-in-degrees-to-radians-in-c/"/>
    /// <param name="val">The value to convert to radians</param>
    /// <returns>The value in radians</returns>
    public static class NumericExtensions
    {
        public static double ToRadians(this double val)
        {
            return (Math.PI / 180) * val;
        }
    }
}
