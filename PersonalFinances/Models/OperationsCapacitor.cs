using LiveCharts;

namespace PersonalFinances
{
    internal class OperationsCapacitor
    {
        CategoriesModel categoriesModel;
        public CategoriesModel CategoriesModel
        {
            get => categoriesModel;
            set => categoriesModel = value;
        }

        public ChartValues<double> Sums { get; set; } = new ChartValues<double> { 0, 0, 0, 0 };

        public void AddOperation(string category, double sum)
        {
            Sums[categoriesModel.Categories.IndexOf(category)] += sum;
        }
    }
}