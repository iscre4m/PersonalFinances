using System;

namespace PersonalFinances
{
    class Expense : Operation
    { 
        public string Category { get; set; }

        public Expense(DateTime dateOfIssue,
                              string walletModel,
                              double sum,
                              string walletCurrency,
                              string category)
             : base(dateOfIssue, walletModel, sum, walletCurrency)
        {
            Category = category;
        }

        public override string ToString() => base.ToString() + " - "
                                           + Category + " - Снятие";
    }
}