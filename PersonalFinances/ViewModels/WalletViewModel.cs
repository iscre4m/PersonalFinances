using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace PersonalFinances
{
    internal class WalletViewModel : Notifier
    {
        ObservableCollection<IWallet> wallets = new ObservableCollection<IWallet>();
        int selectedWalletIndex;
        ICommand addCommand;
        ICommand removeCommand;

        public WalletViewModel()
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
        public int SelectedWalletIndex
        {
            get
            {
                return selectedWalletIndex;
            }
            set
            {
                if (value != selectedWalletIndex)
                {
                    selectedWalletIndex = value;
                    OnPropertyChanged("SelectedWallet");
                }
            }
        }
        Regex titleRegEx = new Regex(@"^[a-zA-Z]\w*$");
        Regex balanceRegEx = new Regex(@"(^0|^[1-9][0-9]*)(\.[0-9]{1,2})?$");
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new DelegateCommand(param => AddWallet(),
                                                     param => (titleRegEx.IsMatch(Title)
                                                            && Currency != ""
                                                            && balanceRegEx.IsMatch(Balance)));
                }
                return addCommand;
            }
        }
        void AddWallet()
        {
            wallets.Add(new Wallet(Title, Currency, double.Parse(Balance)));
        }
        public ICommand RemoveCommand
        {
            get
            {
                if (removeCommand == null)
                {
                    removeCommand = new DelegateCommand(param => RemoveWallet(),
                                                        param => (SelectedWalletIndex != -1));
                }
                return removeCommand;
            }
        }

        void RemoveWallet()
        {
            wallets.RemoveAt(selectedWalletIndex);
        }
    }
}