using System.Windows.Input;
using System.Text.RegularExpressions;
using System;

namespace PersonalFinances
{
    class OperationsViewModel : Notifier
    {
        public OperationsViewModel()
        {
            categoriesModel = CategoriesModel.GetInstance();
        }

        WalletsModel walletsModel;
        public WalletsModel WalletsModel
        {
            get => walletsModel;
            set => walletsModel = value;
        }

        OperationsModel operationsModel;
        public OperationsModel OperationsModel
        {
            get => operationsModel;
            set => operationsModel = value;
        }

        #region Пополнение
        Wallet selectedReplenishWallet;
        public Wallet SelectedReplenishWallet
        {
            get => selectedReplenishWallet;
            set
            {
                if (value != selectedReplenishWallet)
                {
                    selectedReplenishWallet = value;
                    OnPropertyChanged("SelectedReplenishWallet");
                }
            }
        }

        string replenishSum = "0";
        public string ReplenishSum
        {
            get => replenishSum;
            set
            {
                if (value != replenishSum)
                {
                    replenishSum = value;
                    OnPropertyChanged("ReplenishSum");
                }
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
                                                           param => selectedReplenishWallet != null
                                                                 && sumRegEx.IsMatch(ReplenishSum));
                }
                return replenishCommand;
            }
        }
        void Replenish()
        {
            selectedReplenishWallet.Replenish(double.Parse(ReplenishSum));
            operationsModel.Operations.Add(new Income(DateTime.Now,
                                                      selectedReplenishWallet.Title,
                                                      double.Parse(ReplenishSum),
                                                      selectedReplenishWallet.Currency));
            selectedReplenishWallet.OperationsCapacitor.RawIncome += double.Parse(ReplenishSum);
            ReplenishSum = "0";
            SelectedReplenishWallet = null;
        }
        #endregion

        #region Снятие
        CategoriesModel categoriesModel;
        public CategoriesModel CategoriesModel
        {
            get => categoriesModel;
            set => categoriesModel = value;
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

        string withdrawSum = "0";
        public string WithdrawSum
        {
            get
            {
                return withdrawSum;
            }
            set
            {
                if (value != withdrawSum)
                {
                    withdrawSum = value;
                    OnPropertyChanged("WithdrawSum");
                }
            }
        }

        Wallet selectedWithdrawWallet;
        public Wallet SelectedWithdrawWallet
        {
            get => selectedWithdrawWallet;
            set
            {
                if (value != selectedWithdrawWallet)
                {
                    selectedWithdrawWallet = value;
                    OnPropertyChanged("SelectedWithdrawWallet");
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
                                                        param => (SelectedWithdrawWallet != null
                                                               && sumRegEx.IsMatch(WithdrawSum)
                                                               && double.Parse(selectedWithdrawWallet.Balance) - double.Parse(WithdrawSum) >= 0)
                                                               && SelectedCategoryIndex > -1);
                }
                return withdrawCommand;
            }
        }
        void Withdraw()
        {
            selectedWithdrawWallet.Withdraw(double.Parse(WithdrawSum));
            operationsModel.Operations.Add(new Expense(DateTime.Now,
                                                       selectedWithdrawWallet.Title,
                                                       double.Parse(WithdrawSum),
                                                       selectedWithdrawWallet.Currency,
                                                       categoriesModel.Categories[selectedCategoryIndex]));
            selectedWithdrawWallet.OperationsCapacitor.AddExpense(double.Parse(WithdrawSum),
                                                                  categoriesModel.Categories[selectedCategoryIndex]);
            WithdrawSum = "0";
            SelectedCategoryIndex = -1;
            SelectedWithdrawWallet = null;
        }
        #endregion
    }
}