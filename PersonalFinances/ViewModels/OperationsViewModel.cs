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

        ChartsModel chartsModel;

        public ChartsModel ChartsModel
        {
            get
            {
                return chartsModel;
            }
            set
            {
                chartsModel = value;
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
                walletsModel.Wallets[selectedReplenishWalletIndex].Title,
                double.Parse(IncomeSum),
                WalletsModel.Wallets[selectedReplenishWalletIndex].Currency));
            IncomeSum = "0";
            SelectedReplenishWalletIndex = -1;
        }

        string selectedReplenishWalletBalance = "0";
        public string SelectedReplenishWalletBalance
        {
            get
            {
                return selectedReplenishWalletBalance;
            }
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
                    if (selectedReplenishWalletIndex == -1)
                    {
                        selectedReplenishWalletBalance = "0";
                        OnPropertyChanged("SelectedReplenishWalletBalance");
                        return;
                    }
                    selectedReplenishWalletBalance = walletsModel.Wallets[selectedReplenishWalletIndex].Balance.ToString();
                    OnPropertyChanged("SelectedReplenishWalletBalance");
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
                                                               && walletsModel.Wallets[selectedWithdrawWalletIndex].Balance - double.Parse(ExpenseSum) >= 0)
                                                               && SelectedCategoryIndex > -1);
                }
                return withdrawCommand;
            }
        }
        void Withdraw()
        {
            walletsModel.Wallets[selectedWithdrawWalletIndex].Withdraw(double.Parse(ExpenseSum));
            operationsModel.Operations.Add(new ExpenseModel(DateTime.Now,
                                           walletsModel.Wallets[selectedWithdrawWalletIndex].Title,
                                           double.Parse(ExpenseSum),
                                           WalletsModel.Wallets[selectedWithdrawWalletIndex].Currency,
                                           categoriesModel.Categories[selectedCategoryIndex]));
            AddToCapacitor();
            ExpenseSum = "0";
            SelectedWithdrawWalletIndex = -1;
            SelectedCategoryIndex = -1;
        }

        void AddToCapacitor()
        {
            if(chartsModel.Capacitor.Count==0)
            {
            chartsModel.Capacitor.Add(new ExpenseCapacitor(categoriesModel.Categories[selectedCategoryIndex], double.Parse(ExpenseSum)));
            }
            else
            {
                int count = 0;
                for (int i = 0; i < chartsModel.Capacitor.Count; i++)
                {
                    if(chartsModel.Capacitor[i].Category==categoriesModel.Categories[selectedCategoryIndex])
                    {
                        chartsModel.Capacitor[i].AddSum(double.Parse(ExpenseSum));
                        OnPropertyChanged("ChartsModel");
                        count++;
                    }
                }
                if(count==0)
                {
                    chartsModel.Capacitor.Add(new ExpenseCapacitor(categoriesModel.Categories[selectedCategoryIndex], double.Parse(ExpenseSum)));
                }
            }
        }

        string selectedWithdrawWalletBalance = "0";
        public string SelectedWithdrawWalletBalance
        {
            get
            {
                return selectedWithdrawWalletBalance;
            }
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
                    if (selectedWithdrawWalletIndex == -1)
                    {
                        selectedWithdrawWalletBalance = "0";
                        OnPropertyChanged("SelectedWithdrawWalletBalance");
                        return;
                    }
                    selectedWithdrawWalletBalance = walletsModel.Wallets[selectedWithdrawWalletIndex].Balance.ToString();
                    OnPropertyChanged("SelectedWithdrawWalletBalance");
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