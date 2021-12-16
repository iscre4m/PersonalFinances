using System.Collections.ObjectModel;

namespace PersonalFinances
{
    internal class OperationsList
    {
        public ObservableCollection<Operation> Operations { get; } = new();
    }
}