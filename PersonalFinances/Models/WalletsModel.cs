using System.Collections.ObjectModel;

namespace PersonalFinances
{
    internal class WalletsModel
    {
        readonly ObservableCollection<Wallet> wallets = new();

        public ObservableCollection<Wallet> Wallets
        {
            get => wallets;
        }
    }
}