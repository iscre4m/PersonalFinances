using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances
{
    class IncomeSource
    {
        public string Source { get; set; }
        public double Sum { get; set; }

        public IncomeSource(string source,double sum)
        {
            Source = source;
            Sum = sum;
        }
    }
}
