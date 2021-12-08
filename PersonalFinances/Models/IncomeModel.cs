using System;

namespace PersonalFinances
{
    class IncomeModel : OperationModel
    {
        public IncomeModel(DateTime date, string walletModel, double sum)
            : base(date, walletModel, sum)
        {
        }

        public override string ToString()
        {
            return base.ToString() + " - Пополнение";
        }
    }
}