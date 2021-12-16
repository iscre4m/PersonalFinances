using System;
using System.IO;

namespace PersonalFinances
{
    class Income : Operation
    {
        public Income(DateTime dateOfIssue,
                      string walletModel,
                      double sum,
                      string walletCurrency) : base(dateOfIssue,
                                                    walletModel,
                                                    sum,
                                                    walletCurrency)
        {
        }
        public Income()
        {

        }

        public override void Save(BinaryWriter write)
        {
            write.Write(base.DateOfIssue.ToString());
            write.Write(base.WalletTitle);
            write.Write(base.WalletCurrency);
            write.Write(base.Sum);
        }

        public override void Download(BinaryReader read)
        {
            base.DateOfIssue = Convert.ToDateTime(read.ReadString());
            base.WalletTitle = read.ReadString();
            base.WalletCurrency = read.ReadString();
            base.Sum = read.ReadDouble();
        }
        public override string ToString() => base.ToString()
                                          + " - Пополнение";
    }
}