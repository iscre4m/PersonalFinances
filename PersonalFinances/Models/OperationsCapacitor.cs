using LiveCharts;

namespace PersonalFinances
{
    internal class OperationsCapacitor : Notifier
    {
        CategoriesModel categoriesModel = CategoriesModel.GetInstance();

        public ChartValues<double> Expenses { get; set; } = new ChartValues<double> { 0, 0, 0, 0 };
        double expensesSum = 0;

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
                    RealIncome = rawIncome - expensesSum;
                }
            }
        }

        double realIncome = 0;
        public double RealIncome
        {
            get => realIncome;
            set
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
            expensesSum += sum;
            RealIncome = rawIncome - expensesSum;
        }
    }
}