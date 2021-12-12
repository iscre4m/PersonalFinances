using System.Collections.ObjectModel;

namespace PersonalFinances
{
    internal class OperationsModel
    {
        readonly ObservableCollection<Operation> operations = new();
        public ObservableCollection<Operation> Operations
        {
            get => operations;
        }
    }
}