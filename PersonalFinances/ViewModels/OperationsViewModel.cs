using System.Windows.Input;

namespace PersonalFinances
{
    class OperationsViewModel:Notifier
    {
        WalletsModel walletsModel;
        int selectedWalletIndex = -1;
        ICommand replenishCommand;
        ICommand withdrawCommand;
        public OperationsViewModel()
        {
            Title = "";
            Currency = "";
            Balance = "0";
        }

        public string Title { get; set; }
        public string Currency { get; set; }
        public string Balance { get; set; }
        public WalletsModel WalletsModel
        {
            get
            {
                return walletsModel;
            }
        }
    }
}