using System.Collections.ObjectModel;

namespace PersonalFinances
{
    internal class OperationsModel
    {
        ObservableCollection<OperationModel> operations = new ObservableCollection<OperationModel>();
        public ObservableCollection<OperationModel> Operations
        {
            get
            {
                return operations;
            }
        }
    }
}