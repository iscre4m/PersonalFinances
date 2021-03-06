using System;
using System.IO;

namespace PersonalFinances
{
    abstract class Operation
    {
        public DateTime DateOfIssue { get; set; }
        public string WalletTitle { get; set; }
        public string WalletCurrency { get; set; }
        public double Sum { get; set; }

        public Operation(DateTime dateOfIssue,
                           string walletName,
                           double sum,
                           string walletCurrency)
        {
            DateOfIssue = dateOfIssue;
            WalletTitle = walletName;
            WalletCurrency = walletCurrency;
            Sum = sum;
        }

        abstract public void Save(BinaryWriter write);

        abstract public void Download(BinaryReader read);

        public override string ToString() => DateOfIssue.ToShortDateString() + ' '
                                           + DateOfIssue.ToLongTimeString() + " - "
                                           + WalletTitle + " - "
                                           + Sum.ToString() + ' '
                                           + WalletCurrency;
    }
}