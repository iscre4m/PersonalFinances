using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PersonalFinances
{
    class ExpenceViewModel:Notifier
    {
        ObservableCollection<Expence> expences = new ObservableCollection<Expence>();
        int selectedWalletIndex = -1;
        ICommand replenishCommand;
        ICommand withdrawCommand;
        public ExpenceViewModel()
        {
            Title = "";
            Currency = "";
            Balance = "0";
        }

        public string Title { get; set; }
        public string Currency { get; set; }
        public string Balance { get; set; }
        public ObservableCollection<IWallet> Wallets
        {
            get
            {
                return wallets;
            }
        }
    }
}
