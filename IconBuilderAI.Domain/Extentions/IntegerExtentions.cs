using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IconBuilderAI.Domain.Extentions
{
    public static class IntegerExtentions
    {
        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }
    }
}
