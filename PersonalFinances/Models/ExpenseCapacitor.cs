using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances
{
    internal class ExpenseCapacitor: Notifier
    {
        double sum=0;
        string category="";
        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                if(value!=category)
                {
                    category = value;
                }
            }
        }
        public double Sum
        {
            get
            {
                return sum;
            }
            set
            {
                if (value != sum)
                {
                    sum = value;
                }
               
            }
        }

        public ExpenseCapacitor(string category,double sum)
        {
            Category = category;
            Sum = sum;
        }

        public void AddSum(double sum)
        {
            Sum += sum;
        }
    }
}
