using System;

namespace PersonalFinances
{
    class IncomeModel : OperationModel
    {
        public IncomeModel(DateTime date, string walletModel, double sum, string walletCurrency)
            : base(date, walletModel, sum, walletCurrency)
        {
        }

        public override string ToString()
        {
            return base.ToString() + " - Пополнение";
        }
    }
}