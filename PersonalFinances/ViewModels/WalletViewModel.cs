using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PersonalFinances
{
    internal class WalletViewModel : Notifier
    {
        ObservableCollection<Wallet> wallets = new ObservableCollection<Wallet>();
        IWallet selectedWallet;
        ICommand addCommand;
        ICommand removeCommand;

        public IWallet SelectedWallet
        {
            get
            {
                return selectedWallet;
            }
            set
            {
                if (value != selectedWallet)
                {
                    selectedWallet = value;
                    OnPropertyChanged("SelectedWallet");
                }
            }
        }
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new DelegateCommand(param => AddWallet(),
                                                     param => (SelectedWallet != null));
                }
                return addCommand;
            }
        }

        void AddWallet()
        {
            
        }
    }
}