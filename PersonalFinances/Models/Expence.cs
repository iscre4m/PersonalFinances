using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances
{
    class Expence:Notifier
    {
        public string Category { get; set; }
        public double Sum { get; set; }
        public string Comment { get; set; }

        public Expence(string category,double sum, string comment)
        {
            Category = category;
            Sum = sum;
            Comment = comment;
        }
    }
}
