using LiveCharts;

namespace PersonalFinances
{
    internal class OperationsCapacitor : Notifier
    {
        readonly CategoriesModel categoriesModel = CategoriesModel.GetInstance();

        public ChartValues<double> Expenses { get; set; } = new ChartValues<double> { 0, 0, 0, 0 };

        public double ExpensesSum { get ; set; } = 0;

        double rawIncome = 0;
        public double RawIncome
        {
            get => rawIncome;
            set
            {
                if (value != rawIncome)
                {
                    rawIncome = value;
                    OnPropertyChanged("RawIncome");
                    RealIncome = rawIncome - ExpensesSum;
                }
            }
        }

        double realIncome = 0;
        public double RealIncome
        {
            get => realIncome;
            private set
            {
                if (value != realIncome)
                {
                    realIncome = value;
                    OnPropertyChanged("RealIncome");
                }
            }
        }

        public void AddExpense(double sum, string category)
        {
            Expenses[categoriesModel.Categories.IndexOf(category)] += sum;
            ExpensesSum += sum;
            RealIncome = rawIncome - ExpensesSum;
        }
    }
}