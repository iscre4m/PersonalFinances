using System;

namespace PersonalFinances
{
    class ExpenseModel : OperationModel
    { 
        public string Category { get; set; }

        public ExpenseModel(DateTime date, string walletModel, double sum, string walletCurrency, string category)
             : base(date, walletModel, sum, walletCurrency)
        {
            Category = category;
        }

        public override string ToString()
        {
            return base.ToString() + " - "
                 + Category + " - Снятие";
        }
    }
}