using System.Collections.ObjectModel;

namespace PersonalFinances
{
    internal class WalletsModel : Notifier
    {
        ObservableCollection<IWalletModel> wallets = new ObservableCollection<IWalletModel>();

        public ObservableCollection<IWalletModel> Wallets
        {
            get
            {
                return wallets;
            }
        }
    }
}