using System.Windows.Input;
using System.Text.RegularExpressions;

namespace PersonalFinances
{
    internal class WalletsViewModel : Notifier
    {
        WalletsModel walletsModel;
        public WalletsModel WalletsModel
        {
            set => walletsModel = value;
            get => walletsModel;
        }

        #region Добавление кошелька
        string inputTitle = "";
        public string InputTitle
        {
            get => inputTitle;
            set
            {
                if (value != inputTitle)
                {
                    inputTitle = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        public string[] Currencies { get; } = { "UAH", "USD", "EUR" };
        int selectedCurrencyIndex = -1;
        public int SelectedCurrencyIndex
        {
            get => selectedCurrencyIndex;
            set
            {
                if (value != selectedCurrencyIndex)
                {
                    selectedCurrencyIndex = value;
                    OnPropertyChanged("SelectedCurrencyIndex");
                }
            }
        }

        string inputBalance = "0";
        public string InputBalance
        {
            get => inputBalance;
            set
            {
                if (value != inputBalance)
                {
                    inputBalance = value;
                    OnPropertyChanged("Balance");
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
                                                     param => titleRegEx.IsMatch(inputTitle)
                                                           && selectedCurrencyIndex > -1
                                                           && balanceRegEx.IsMatch(inputBalance));
                }
                return addCommand;
            }
        }
        void AddWallet()
        {
            walletsModel.Wallets.Add(new Wallet(inputTitle,
                                                     Currencies[selectedCurrencyIndex],
                                                     double.Parse(inputBalance)));
            InputTitle = "";
            SelectedCurrencyIndex = -1;
            InputBalance = "0";
        }
        #endregion

        #region Удаление кошелька
        int selectedWalletIndex = -1;
        public int SelectedWalletIndex
        {
            get => selectedWalletIndex;
            set
            {
                if (value != selectedWalletIndex)
                {
                    selectedWalletIndex = value;
                    OnPropertyChanged("SelectedWalletIndex");
                    if (selectedWalletIndex == -1)
                    {
                        SelectedWalletTitle = "";
                        SelectedWalletCurrency = "";
                        SelectedWalletBalance = "";
                        return;
                    }
                    SelectedWalletTitle = walletsModel.Wallets[selectedWalletIndex].Title;
                    SelectedWalletCurrency = walletsModel.Wallets[selectedWalletIndex].Currency;
                    SelectedWalletBalance = walletsModel.Wallets[selectedWalletIndex].Balance.ToString();
                }
            }
        }

        ICommand removeCommand;
        public ICommand RemoveCommand
        {
            get
            {
                if (removeCommand == null)
                {
                    removeCommand = new DelegateCommand(param => RemoveWallet(),
                                                        param => selectedWalletIndex > -1);
                }
                return removeCommand;
            }
        }
        void RemoveWallet()
        {
            walletsModel.Wallets.RemoveAt(selectedWalletIndex);
        }
        #endregion
        #region Выбор кошелька
        string selectedWalletTitle = "";
        public string SelectedWalletTitle
        {
            get => selectedWalletTitle;
            set
            {
                selectedWalletTitle = value;
                OnPropertyChanged("SelectedWalletTitle");
            }
        }

        string selectedWalletCurrency = "";
        public string SelectedWalletCurrency
        {
            get => selectedWalletCurrency;
            set
            {
                selectedWalletCurrency = value;
                OnPropertyChanged("SelectedWalletCurrency");
            }
        }

        string selectedWalletBalance = "";
        public string SelectedWalletBalance
        {
            get => selectedWalletBalance;
            set
            {
                selectedWalletBalance = value;
                OnPropertyChanged("SelectedWalletBalance");
            }
        }
        #endregion
    }
}