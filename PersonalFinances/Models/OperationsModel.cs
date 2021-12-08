using System.Collections.ObjectModel;

namespace PersonalFinances
{
    internal class OperationsModel
    {
        readonly ObservableCollection<OperationModel> operations = new();
        public ObservableCollection<OperationModel> Operations
        {
            get
            {
                return operations;
            }
        }
    }
}