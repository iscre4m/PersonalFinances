using System;
using System.IO;

namespace PersonalFinances
{
    class Expense : Operation
    { 
        public string Category { get; set; }

        public Expense(DateTime dateOfIssue,
                       string walletModel,
                       double sum,
                       string walletCurrency,
                       string category) : base(dateOfIssue,
                                               walletModel,
                                               sum,
                                               walletCurrency)
        {
            Category = category;
        }

        public override void Save(BinaryWriter write)
        {
            write.Write(base.DateOfIssue.ToString());
            write.Write(base.WalletTitle);
            write.Write(base.WalletCurrency);
            write.Write(base.Sum);
            write.Write(Category);
        }

        public override void Download(BinaryReader read)
        {
            base.DateOfIssue = Convert.ToDateTime(read.ReadString());
            base.WalletTitle = read.ReadString();
            base.WalletCurrency = read.ReadString();
            base.Sum = read.ReadDouble();
            Category = read.ReadString();
        }

        public override string ToString() => base.ToString() + " - "
                                           + Category + " - Снятие";
    }
}