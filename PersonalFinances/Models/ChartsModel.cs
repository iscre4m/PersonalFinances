using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace PersonalFinances
{
    internal class ChartsModel:Notifier
    {
        readonly ObservableCollection<ExpenseCapacitor> capacitor = new();

        public ObservableCollection<ExpenseCapacitor> Capacitor
        {
            get
            {
                return capacitor;
            }
        }
    }
}
