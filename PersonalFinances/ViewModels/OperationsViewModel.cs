using System.Windows.Input;
using System.Text.RegularExpressions;
using System;

namespace PersonalFinances
{
    class OperationsViewModel : Notifier
    {
        public WalletsModel WalletsModel { get; } = WalletsModel.GetInstance();

        public OperationsList OperationsList { get; } = OperationsList.GetInstance();

        ChartsViewModel chartsViewModel;
        public ChartsViewModel ChartsViewModel
        {
            get => chartsViewModel;
            set => chartsViewModel = value;
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

        readonly Regex sumRegEx = new(@"^[1-9][0-9]*(\.(0[1-9]|[1-9][0-9]?))?$");
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
            Income income = new(DateTime.Now,
                                selectedReplenishWallet.Title,
                                double.Parse(ReplenishSum),
                                selectedReplenishWallet.Currency);
            OperationsList.Operations.Add(income);
            selectedReplenishWallet.WalletOperationsModel.Operations.Add(income);
            chartsViewModel.UpdateChart();
            ReplenishSum = "0";
            SelectedReplenishWallet = null;
        }
        #endregion

        #region Снятие
        public CategoriesModel CategoriesModel { get; } = CategoriesModel.GetInstance();

        int selectedCategoryIndex = -1;
        public int SelectedCategoryIndex
        {
            get => selectedCategoryIndex;
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
            get => withdrawSum;
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
            Expense expense = new(DateTime.Now,
                                  selectedWithdrawWallet.Title,
                                  double.Parse(WithdrawSum),
                                  selectedWithdrawWallet.Currency,
                                  CategoriesModel.Categories[selectedCategoryIndex]);
            OperationsList.Operations.Add(expense);
            selectedWithdrawWallet.WalletOperationsModel.Operations.Add(expense);
            chartsViewModel.UpdateChart();
            WithdrawSum = "0";
            SelectedCategoryIndex = -1;
            SelectedWithdrawWallet = null;
        }
        #endregion
    }
}