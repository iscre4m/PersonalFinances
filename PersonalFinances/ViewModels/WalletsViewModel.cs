using System.Windows.Input;
using System.Text.RegularExpressions;

namespace PersonalFinances
{
    internal class WalletsViewModel : Notifier
    {
        WalletsModel walletsModel;
        int selectedWalletIndex = -1;
        ICommand addCommand;
        ICommand removeCommand;

        public WalletsViewModel()
        {
            Title = "";
            Currency = "";
            Balance = "0";
        }

        public string Title { get; set; }
        public string Currency { get; set; }
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
                    OnPropertyChanged("SelectedWallet");
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
                                                            && Currency != ""
                                                            && balanceRegEx.IsMatch(Balance)));
                }
                return addCommand;
            }
        }
        void AddWallet()
        {
            walletsModel.Wallets.Add(new WalletModel(Title, Currency, double.Parse(Balance)));
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
            walletsModel.Wallets.RemoveAt(selectedWalletIndex);
        }
    }
}