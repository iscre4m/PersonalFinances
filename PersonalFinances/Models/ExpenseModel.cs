using System;

namespace PersonalFinances
{
    class ExpenseModel : OperationModel
    { 
        public string Category { get; set; }

        public ExpenseModel(DateTime date, string walletModel, double sum, string category)
             : base(date, walletModel, sum)
        {
            Category = category;
        }

        public override string ToString()
        {
            return "Снятие " + base.ToString() + " - " + Category;
        }
    }
}