using System.Collections.ObjectModel;

namespace PersonalFinances
{
    internal class IncomeSourcesModel
    {
        ObservableCollection<string> incomeSources = new ObservableCollection<string>();
        public ObservableCollection<string> IncomeSources
        {
            get
            {
                return incomeSources;
            }
        }
    }
}