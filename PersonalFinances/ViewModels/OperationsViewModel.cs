using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System;

namespace PersonalFinances
{
    class OperationsViewModel:Notifier
    {
        WalletsModel walletsModel;
        ObservableCollection<Operation> operations = new ObservableCollection<Operation>();
        int selectedWalletIndex = -1;
        int selectedCategoryIndex = -1;
        int selectedOperationIndex = -1;
        string[] category = { "Продукты", "Кино", "Развлечения" };
        ICommand replenishCommand;
        ICommand withdrawCommand;
        ICommand addCommand;
        public OperationsViewModel()
        {
            IncomeBalance = "0";
            ExpenseBalance = "0";
        }
        public string IncomeBalance { get; set; }
        public string ExpenseBalance { get; set; }
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

        public ObservableCollection<Operation> Operations
        {
            get
            {
                return operations;
            }
        }

        public string[] Category
        {
            get
            {
                return category;
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
        public int SelectedOperationIndex
        {
            get
            {
                return selectedOperationIndex;
            }
            set
            {
                if (value != selectedOperationIndex)
                {
                    selectedOperationIndex = value;
                    OnPropertyChanged("SelectedOperation");
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
                    OnPropertyChanged("SelectedCategory");
                }
            }
        }
        Regex balanceRegEx = new Regex(@"(^0|^[1-9][0-9]*)(\.(0[1-9]|[1-9][0-9]?))?$");
        public ICommand ReplenishCommand
        {
            get
            {
                if (replenishCommand == null)
                {
                    replenishCommand = new DelegateCommand(param => Replenish(),
                                                     param => (SelectedWalletIndex != -1
                                                                 && balanceRegEx.IsMatch(IncomeBalance)));
                }
                return replenishCommand;
            }
        }
        void Replenish()
        {
            walletsModel.Wallets[SelectedWalletIndex].Replenish(Double.Parse(IncomeBalance));
        }

        void AddOperation()
        {
            //operations.Add(new Operation())
        }
        public ICommand ExpenseCommand
        {
            get
            {
                if (withdrawCommand == null)
                {
                    withdrawCommand = new DelegateCommand(param => Withdraw(),
                                                        param => (SelectedWalletIndex != -1
                                                                 && balanceRegEx.IsMatch(IncomeBalance)));
                }
                return withdrawCommand;
            }
        }

        void Withdraw()
        {
            walletsModel.Wallets[selectedWalletIndex].Withdraw(Double.Parse(ExpenseBalance));
        }
    }
}