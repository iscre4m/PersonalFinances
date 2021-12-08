using System.Windows.Input;
using System.Text.RegularExpressions;
using System;

namespace PersonalFinances
{
    class OperationsViewModel : Notifier
    {
        WalletsModel walletsModel;
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

        OperationsModel operationsModel;
        public OperationsModel OperationsModel
        {
            get
            {
                return operationsModel;
            }
            set
            {
                operationsModel = value;
            }
        }

        CategoriesModel categoriesModel;
        public CategoriesModel CategoriesModel
        {
            get
            {
                return categoriesModel;
            }
            set
            {
                categoriesModel = value;
            }
        }

        Regex sumRegEx = new Regex(@"^[1-9][0-9]*(\.(0[1-9]|[1-9][0-9]?))?$");
        ICommand replenishCommand;
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
            operationsModel.Operations.Add(new IncomeModel(DateTime.Now,
                ((WalletModel)walletsModel.Wallets[selectedReplenishWalletIndex]).Title,
                double.Parse(IncomeSum),
                ((WalletModel)WalletsModel.Wallets[selectedReplenishWalletIndex]).Currency));
            IncomeSum = "0";
            SelectedReplenishWalletIndex = -1;
        }

        int selectedReplenishWalletIndex = -1;
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

        string incomeSum = "0";
        public string IncomeSum
        {
            get
            {
                return incomeSum;
            }
            set
            {
                if (value != incomeSum)
                {
                    incomeSum = value;
                    OnPropertyChanged("IncomeSum");
                }
            }
        }

        ICommand withdrawCommand;
        public ICommand WithdrawCommand
        {
            get
            {
                if (withdrawCommand == null)
                {
                    withdrawCommand = new DelegateCommand(param => Withdraw(),
                                                        param => (SelectedWithdrawWalletIndex > -1
                                                               && sumRegEx.IsMatch(ExpenseSum)
                                                               && ((WalletModel)walletsModel.Wallets[selectedWithdrawWalletIndex]).Balance - double.Parse(ExpenseSum) >= 0)
                                                               && SelectedCategoryIndex > -1);
                }
                return withdrawCommand;
            }
        }
        void Withdraw()
        {
            walletsModel.Wallets[selectedWithdrawWalletIndex].Withdraw(double.Parse(ExpenseSum));
            operationsModel.Operations.Add(new ExpenseModel(DateTime.Now,
                                           ((WalletModel)walletsModel.Wallets[selectedWithdrawWalletIndex]).Title,
                                           double.Parse(ExpenseSum),
                                           ((WalletModel)WalletsModel.Wallets[selectedWithdrawWalletIndex]).Currency,
                                           categoriesModel.Categories[selectedCategoryIndex]));
            ExpenseSum = "0";
            SelectedWithdrawWalletIndex = -1;
            SelectedCategoryIndex = -1;
        }

        int selectedWithdrawWalletIndex = -1;
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

        string expenseSum = "0";
        public string ExpenseSum
        {
            get
            {
                return expenseSum;
            }
            set
            {
                if (value != expenseSum)
                {
                    expenseSum = value;
                    OnPropertyChanged("ExpenseSum");
                }
            }
        }

        int selectedCategoryIndex = -1;
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
    }
}