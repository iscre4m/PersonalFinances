using System.Collections.ObjectModel;

namespace PersonalFinances
{
    internal class WalletsModel : Notifier
    {
        readonly ObservableCollection<WalletModel> wallets = new();

        public ObservableCollection<WalletModel> Wallets
        {
            get
            {
                return wallets;
            }
        }
    }
}