using System.Collections.ObjectModel;

namespace PersonalFinances
{
    internal class OperationsModel
    {
        public ObservableCollection<Operation> Operations { get; } = new();
    }
}