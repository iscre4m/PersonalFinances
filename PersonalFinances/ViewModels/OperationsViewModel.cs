using System.Windows.Input;
using System.Text.RegularExpressions;

namespace PersonalFinances
{
    class OperationsViewModel : Notifier
    {
        WalletsModel walletsModel;
        OperationsModel operationsModel;
        int selectedWalletIndex = -1;
        int selectedCategoryIndex = -1;
        string[] categories = { "Продукты", "Кино", "Развлечения" };
        ICommand replenishCommand;
        ICommand withdrawCommand;
        public OperationsViewModel()
        {
            IncomeSum = "0";
            ExpenseSum = "0";
        }
        public string IncomeSum { get; set; }
        public string ExpenseSum { get; set; }
        public WalletsModel WalletsModel
        {
            get
            {
                return walletsModel;
            }
            set
            {
                walletsModel = value;
            }
        }

        public OperationsModel OperationsModel
        {
            get
            {
                return operationsModel;
            }
        }

        public string[] Category
        {
            get
            {
                return categories;
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

        public int SelectedCategoryIndex
        {
            get
            {
                return selectedCategoryIndex;
            }
            set
            {
                if (value != selectedCategoryIndex)
                {
                    selectedCategoryIndex = value;
                    OnPropertyChanged("SelectedCategoryIndex");
                }
            }
        }

        Regex sumRegEx = new Regex(@"(^0|^[1-9][0-9]*)(\.(0[1-9]|[1-9][0-9]?))?$");
        public ICommand ReplenishCommand
        {
            get
            {
                if (replenishCommand == null)
                {
                    replenishCommand = new DelegateCommand(param => Replenish(),
                                                     param => (SelectedWalletIndex > -1
                                                            && sumRegEx.IsMatch(IncomeSum)));
                }
                return replenishCommand;
            }
        }
        void Replenish()
        {
            walletsModel.Wallets[SelectedWalletIndex].Replenish(double.Parse(IncomeSum));
            IncomeSum = "0";
            OnPropertyChanged("IncomeSum");
        }

        public ICommand WithdrawCommand
        {
            get
            {
                if (withdrawCommand == null)
                {
                    withdrawCommand = new DelegateCommand(param => Withdraw(),
                                                        param => (SelectedWalletIndex > -1
                                                               && sumRegEx.IsMatch(ExpenseSum)
                                                               && ((WalletModel)walletsModel.Wallets[selectedWalletIndex]).Balance - double.Parse(ExpenseSum) >= 0));
                }
                return withdrawCommand;
            }
        }
        void Withdraw()
        {
            walletsModel.Wallets[selectedWalletIndex].Withdraw(double.Parse(ExpenseSum));
            ExpenseSum = "0";
            OnPropertyChanged("ExpenseSum");
        }
    }
}