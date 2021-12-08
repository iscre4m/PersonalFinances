using System;

namespace PersonalFinances
{
    abstract class OperationModel
    {
        public DateTime Date { get; set; }
        public string WalletName { get; set; }
        public double Sum { get; set; }
        public string WalletCurrency { get; set; }

        public OperationModel(DateTime date, string walletName, double sum, string walletCurrency)
        {
            Date = date;
            WalletName = walletName;
            Sum = sum;
            WalletCurrency = walletCurrency;
        }

        public override string ToString()
        {
            return Date.ToShortDateString() + ' ' + Date.ToLongTimeString() + " - " + WalletName + " - " + Sum.ToString() + ' ' + WalletCurrency;
        }
    }
}