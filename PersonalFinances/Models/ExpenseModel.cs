﻿using System;

namespace PersonalFinances
{
    class Expense: Operation
    { 

        public DateTime Date { get; set; }
        public string WalletName { get; set; }
        public string Category { get; set; }
        public string Sum { get; set; }
        public string Comment { get; set; }

        public Expense(string walletName, string category,string sum,DateTime date,string comment)
        {
            WalletName = walletName;
            Category = category;
            Sum = sum;
            Date = date;
            Comment = comment;
        }

        public override string ToString()
        {
            return WalletName + "\t" + Sum +Category+"\t" +"\t" + Date.Day.ToString() + "." + Date.Month.ToString()
                + Date.Year.ToString() + "\t" + Comment;
        }
    }
}