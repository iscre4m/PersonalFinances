using System.Collections.ObjectModel;

namespace PersonalFinances
{
    internal class WalletsModel
    {
        public ObservableCollection<Wallet> Wallets { get; } = new();
    }
}