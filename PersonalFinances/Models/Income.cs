using System;

namespace PersonalFinances
{
    class Income : Operation
    {
        public Income(DateTime dateOfIssue,
                             string walletModel,
                             double sum,
                             string walletCurrency)
            : base(dateOfIssue, walletModel, sum, walletCurrency)
        {
        }

        public override string ToString() => base.ToString()
                                          + " - Пополнение";
    }
}