using System;
using LiveCharts;

namespace PersonalFinances
{
    internal class ChartsViewModel : Notifier
    {
        WalletsModel walletsModel;
        public WalletsModel WalletsModel
        {
            get => walletsModel;
            set => walletsModel = value;
        }

        CategoriesModel categoriesModel;
        public CategoriesModel CategoriesModel
        {
            get => categoriesModel;
            set => categoriesModel = value;
        }

        OperationsCapacitor operationsCapacitor;
        public OperationsCapacitor OperationsCapacitor
        {
            get => operationsCapacitor;
            set => operationsCapacitor = value;
        }

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
                }
            }
        }

        DateTime fromDate;
        public DateTime FromDate
        {
            get => fromDate;
            set
            {
                if (value != fromDate)
                {
                    fromDate = value;
                    OnPropertyChanged("FromDate");
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
                }
            }
        }
    }
}