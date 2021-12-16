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
        Wallet newWallet = new();
        public Wallet NewWallet
        {
            get => newWallet;
            set
            {
                if (value != newWallet)
                {
                    newWallet = value;
                    OnPropertyChanged("NewWallet");
                }
            }
        }

        public string[] Currencies { get; } = { "UAH", "USD", "EUR" };

        readonly Regex titleRegEx = new Regex(@"^[a-zA-Z]\w*$");
        readonly Regex balanceRegEx = new Regex(@"(^0|^[1-9][0-9]*)(\.(0[1-9]|[1-9][0-9]?))?$");
        ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new DelegateCommand(param => AddWallet(),
                                                     param => titleRegEx.IsMatch(newWallet.Title)
                                                           && newWallet.Currency != ""
                                                           && balanceRegEx.IsMatch(newWallet.Balance.ToString()));
                }
                return addCommand;
            }
        }
        void AddWallet()
        {
            walletsModel.Wallets.Add(newWallet);
            newWallet = new();
            OnPropertyChanged("NewWallet");
        }
        #endregion

        #region Удаление кошелька
        Wallet selectedWallet;
        public Wallet SelectedWallet
        {
            get => selectedWallet;
            set
            {
                if (value != selectedWallet)
                {
                    selectedWallet = value;
                    OnPropertyChanged("SelectedWallet");
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
                                                        param => selectedWallet != null);
                }
                return removeCommand;
            }
        }
        void RemoveWallet()
        {
            walletsModel.Wallets.Remove(selectedWallet);
        }
        #endregion
    }
}