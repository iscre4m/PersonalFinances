using System.Windows.Input;
using System.Text.RegularExpressions;

namespace PersonalFinances
{
    internal class WalletsViewModel : Notifier
    {
        WalletsModel walletsModel;
        int selectedWalletIndex = -1;
        string[] currencies = { "UAH", "USD", "EUR" };
        int selectedCurrencyIndex = -1;

        ICommand addCommand;
        ICommand removeCommand;

        public WalletsViewModel()
        {
            Title = "";
            Balance = "0";
        }

        public string Title { get; set; }
        public string Balance { get; set; }
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
                }
            }
        }
        public string[] Currencies
        {
            get
            {
                return currencies;
            }
        }
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
        Regex titleRegEx = new Regex(@"^[a-zA-Z]\w*$");
        Regex balanceRegEx = new Regex(@"(^0|^[1-9][0-9]*)(\.(0[1-9]|[1-9][0-9]?))?$");
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
            OnPropertyChanged("Title");
            Balance = "0";
            OnPropertyChanged("Balance");
            SelectedCurrencyIndex = -1;
            OnPropertyChanged("SelectedCurrencyIndex");
        }
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
    }
}