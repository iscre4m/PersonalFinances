using System.Collections.ObjectModel;

namespace PersonalFinances
{
    internal class IncomeSourcesModel
    {
        readonly ObservableCollection<string> incomeSources = new();
        public ObservableCollection<string> IncomeSources
        {
            get => incomeSources;
        }
    }
}