using System.Windows.Input;
using System.Text.RegularExpressions;
using System;

namespace PersonalFinances
{
    class OperationsViewModel : Notifier
    {
        WalletsModel walletsModel;
        OperationsModel operationsModel;
        int selectedReplenishWalletIndex = -1;
        int selectedWithdrawWalletIndex = -1;
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
            set
            {
                operationsModel = value;            }
        }

        public string[] Category
        {
            get
            {
                return categories;
            }
        }
        public int SelectedReplenishWalletIndex
        {
            get
            {
                return selectedReplenishWalletIndex;
            }
            set
            {
                if (value != selectedReplenishWalletIndex)
                {
                    selectedReplenishWalletIndex = value;
                    OnPropertyChanged("SelectedReplenishWalletIndex");
                }
            }
        }

        public int SelectedWithdrawWalletIndex
        {
            get
            {
                return selectedWithdrawWalletIndex;
            }
            set
            {
                if (value != selectedWithdrawWalletIndex)
                {
                    selectedWithdrawWalletIndex = value;
                    OnPropertyChanged("SelectedWithdrawWalletIndex");
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
                                                     param => (SelectedReplenishWalletIndex > -1
                                                            && sumRegEx.IsMatch(IncomeSum)));
                }
                return replenishCommand;
            }
        }
        void Replenish()
        {
            walletsModel.Wallets[SelectedReplenishWalletIndex].Replenish(double.Parse(IncomeSum));
            operationsModel.Operations.Add(new IncomeModel(DateTime.Now, ((WalletModel)walletsModel.Wallets[selectedReplenishWalletIndex]).Title, double.Parse(IncomeSum)));
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
                                                        param => (SelectedWithdrawWalletIndex > -1
                                                               && sumRegEx.IsMatch(ExpenseSum)
                                                               && ((WalletModel)walletsModel.Wallets[selectedWithdrawWalletIndex]).Balance - double.Parse(ExpenseSum) >= 0));
                }
                return withdrawCommand;
            }
        }
        void Withdraw()
        {
            walletsModel.Wallets[selectedWithdrawWalletIndex].Withdraw(double.Parse(ExpenseSum));
            operationsModel.Operations.Add(new ExpenseModel(DateTime.Now, ((WalletModel)walletsModel.Wallets[selectedWithdrawWalletIndex]).Title, double.Parse(ExpenseSum), categories[selectedCategoryIndex]));
            ExpenseSum = "0";
            OnPropertyChanged("ExpenseSum");
        }
    }
}