using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances
{
    class Income:Operation
    {
        public DateTime Date { get; set; }
        public string WalletName { get; set; }
        public string Sum { get; set; }
        public string Comment { get; set; }

        public Income(string walletName, string sum, DateTime date, string comment)
        {
            WalletName = walletName;
            Sum = sum;
            Date = date;
            Comment = comment;
        }

        public override string ToString()
        {
            return WalletName + "\t" + Sum + "\t" + Date.Day.ToString() + "." + Date.Month.ToString()
                + Date.Year.ToString() + "\t" + Comment;
        }
    }
}
