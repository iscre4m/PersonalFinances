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
                                                           param => selectedReplenishWalletIndex > -1
                                                                 && sumRegEx.IsMatch(ReplenishSum));
                }
                return replenishCommand;
            }
        }
        void Replenish()
        {
            walletsModel.Wallets[selectedReplenishWalletIndex].Replenish(double.Parse(ReplenishSum));
            operationsModel.Operations.Add(new Income(DateTime.Now,
                                                      walletsModel.Wallets[selectedReplenishWalletIndex].Title,
                                                      double.Parse(ReplenishSum),
                                                      WalletsModel.Wallets[selectedReplenishWalletIndex].Currency));
            ReplenishSum = "0";
            SelectedReplenishWalletIndex = -1;
        }

        string selectedReplenishWalletBalance = "0";
        public string SelectedReplenishWalletBalance
        {
            get => selectedReplenishWalletBalance;
            set
            {
                selectedReplenishWalletBalance = value;
                OnPropertyChanged("SelectedReplenishWalletBalance");
            }
        }

        int selectedReplenishWalletIndex = -1;
        public int SelectedReplenishWalletIndex
        {
            get => selectedReplenishWalletIndex;
            set
            {
                if (value != selectedReplenishWalletIndex)
                {
                    selectedReplenishWalletIndex = value;
                    OnPropertyChanged("SelectedReplenishWalletIndex");
                    if (selectedReplenishWalletIndex == -1)
                    {
                        SelectedReplenishWalletBalance = "0";
                        return;
                    }
                    SelectedReplenishWalletBalance = walletsModel.Wallets[selectedReplenishWalletIndex].Balance.ToString();
                }
            }
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
                        SelectedWithdrawWalletBalance = "0";
                        return;
                    }
                    SelectedWithdrawWalletBalance = walletsModel.Wallets[selectedWithdrawWalletIndex].Balance.ToString();
                }
            }
        }

        string selectedWithdrawWalletBalance = "0";
        public string SelectedWithdrawWalletBalance
        {
            get => selectedWithdrawWalletBalance;
            set
            {
                selectedWithdrawWalletBalance = value;
                OnPropertyChanged("SelectedWithdrawWalletBalance");
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
                                                               && sumRegEx.IsMatch(WithdrawSum)
                                                               && walletsModel.Wallets[selectedWithdrawWalletIndex].Balance - double.Parse(WithdrawSum) >= 0)
                                                               && SelectedCategoryIndex > -1);
                }
                return withdrawCommand;
            }
        }
        void Withdraw()
        {
            walletsModel.Wallets[selectedWithdrawWalletIndex].Withdraw(double.Parse(WithdrawSum));
            operationsModel.Operations.Add(new Expense(DateTime.Now,
                                           walletsModel.Wallets[selectedWithdrawWalletIndex].Title,
                                           double.Parse(WithdrawSum),
                                           WalletsModel.Wallets[selectedWithdrawWalletIndex].Currency,
                                           categoriesModel.Categories[selectedCategoryIndex]));
            WithdrawSum = "0";
            SelectedWithdrawWalletIndex = -1;
            SelectedCategoryIndex = -1;
        }
        #endregion
    }
}