using System;

namespace PersonalFinances
{
    abstract class OperationModel
    {
        public DateTime Date { get; set; }
        public string WalletName { get; set; }
        public double Sum { get; set; }

        public OperationModel(DateTime date, string walletName, double sum)
        {
            Date = date;
            WalletName = walletName;
            Sum = sum;
        }

        public override string ToString()
        {
            return Date.ToShortDateString() + " - " + WalletName + " - " + Sum.ToString();
        }
    }
}