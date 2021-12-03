using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances
{
    class UAHWallet:Wallet
    {
        public UAHWallet(string name)
        {
            this.Name = name;
            this.Currency = "UAH";
        }

        public override void  WithDraw(double sum)
        {
            if(this.Balance-sum>=0)
            {
                this.Balance -= sum;
            }
        }

        public override void Replenish(double sum)
        {
            this.Balance += sum;
        }
    }
}
