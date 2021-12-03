using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances
{
    abstract class Wallet
    {
        public string Name { get; set; }
        public string Currency { get; protected set; }

        public double Balance { get; protected set; }

        public abstract void WithDraw(double sum);

        public abstract void Replenish(double sum);
    }
}
