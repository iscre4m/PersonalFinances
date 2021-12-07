using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PersonalFinances.Models
{
    internal class WalletsModel:Notifier
    {
        ObservableCollection<IWalletModel> wallets = new ObservableCollection<IWalletModel>();
    }
}
