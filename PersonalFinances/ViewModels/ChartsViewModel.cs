using System;

namespace PersonalFinances
{
    internal class ChartsViewModel : Notifier
    {
        public WalletsModel WalletsModel { get; } = WalletsModel.GetInstance();

        public CategoriesModel CategoriesModel { get; } = CategoriesModel.GetInstance();

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
                    UpdateChart();
                }
            }
        }

        DateTime fromDate = DateTime.Now;
        public DateTime FromDate
        {
            get => fromDate;
            set
            {
                if (value != fromDate)
                {
                    fromDate = value;
                    OnPropertyChanged("FromDate");
                    UpdateChart();
                }
            }
        }

        DateTime toDate = DateTime.Now;
        public DateTime ToDate
        {
            get => toDate;
            set
            {
                if (value != toDate)
                {
                    toDate = value;
                    OnPropertyChanged("ToDate");
                    UpdateChart();
                }
            }
        }

        public void UpdateChart()
        {
            if (SelectedWallet == null)
            {
                return;
            }
            int length = selectedWallet.OperationsCapacitor.Expenses.Count;
            for (int i = 0; i < length; i++)
            {
                selectedWallet.OperationsCapacitor.Expenses[i] = 0;
            }
            selectedWallet.OperationsCapacitor.ExpensesSum = 0;
            selectedWallet.OperationsCapacitor.RawIncome = 0;
            foreach (Operation operation in selectedWallet.WalletOperationsModel.Operations)
            {
                if (operation.DateOfIssue.Date >= fromDate.Date && operation.DateOfIssue.Date <= toDate.Date)
                {
                    if (operation is Income)
                    {
                        selectedWallet.OperationsCapacitor.RawIncome += operation.Sum;
                        continue;
                    }
                    selectedWallet.OperationsCapacitor.AddExpense(operation.Sum, ((Expense)operation).Category);
                }
            }
        }
    }
}