using System.Windows.Input;
using System.Text.RegularExpressions;

namespace PersonalFinances
{
    internal class WalletsViewModel : Notifier
    {
        WalletsModel walletsModel;
        public WalletsModel WalletsModel
        {
            set
            {
                walletsModel = value;
            }
            get
            {
                return walletsModel;
            }
        }

        int selectedWalletIndex = -1;
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
                    OnPropertyChanged("SelectedWalletIndex");
                    selectedWalletTitle = ((WalletModel)walletsModel.Wallets[selectedWalletIndex]).Title;
                    OnPropertyChanged("SelectedWalletTitle");
                }
            }
        }

        string selectedWalletTitle = "";
        public string SelectedWalletTitle
        {
            get
            {
                return selectedWalletTitle;
            }
            set
            {
                if (value != selectedWalletTitle)
                {
                    selectedWalletTitle = value;
                    OnPropertyChanged("SelectedWalletTitle");
                }
            }
        }
        Regex titleRegEx = new Regex(@"^[a-zA-Z]\w*$");
        Regex balanceRegEx = new Regex(@"(^0|^[1-9][0-9]*)(\.(0[1-9]|[1-9][0-9]?))?$");
        ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new DelegateCommand(param => AddWallet(),
                                                     param => (titleRegEx.IsMatch(Title)
                                                            && SelectedCurrencyIndex > -1
                                                            && balanceRegEx.IsMatch(Balance)));
                }
                return addCommand;
            }
        }
        void AddWallet()
        {
            walletsModel.Wallets.Add(new WalletModel(Title, currencies[selectedCurrencyIndex], double.Parse(Balance)));
            Title = "";
            Balance = "0";
            SelectedCurrencyIndex = -1;
        }

        ICommand removeCommand;
        public ICommand RemoveCommand
        {
            get
            {
                if (removeCommand == null)
                {
                    removeCommand = new DelegateCommand(param => RemoveWallet(),
                                                        param => (SelectedWalletIndex > -1));
                }
                return removeCommand;
            }
        }
        void RemoveWallet()
        {
            walletsModel.Wallets.RemoveAt(selectedWalletIndex);
        }

        string title = "";
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (value != title)
                {
                    title = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        string balance = "0";
        public string Balance
        {
            get
            {
                return balance;
            }
            set
            {
                if (value != balance)
                {
                    balance = value;
                    OnPropertyChanged("Balance");
                }
            }
        }

        string[] currencies = { "UAH", "USD", "EUR" };
        public string[] Currencies
        {
            get
            {
                return currencies;
            }
        }

        int selectedCurrencyIndex = -1;
        public int SelectedCurrencyIndex
        {
            get
            {
                return selectedCurrencyIndex;
            }
            set
            {
                if (value != selectedCurrencyIndex)
                {
                    selectedCurrencyIndex = value;
                    OnPropertyChanged("SelectedCurrencyIndex");
                }
            }
        }
    }
}