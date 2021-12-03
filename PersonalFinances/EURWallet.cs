using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances
{
    class EURWallet:Wallet
    {
        EURWallet(string name)
        {
            this.Name = name;
            this.Currency = "EUR";
        }

        public override void WithDraw(double sum)
        {
            if (this.Balance - sum >= 0)
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
