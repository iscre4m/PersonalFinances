﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances
{
    internal class ChartViewModel : Notifier
    {
        public List<Str> strs { get; set; }
        public ChartViewModel()
        {
            strs = new List<Str>()
            {
                new Str("Покушть", "12"),
                new Str("Попть", "22"),
                new Str("Посмотрть", "32"),
                new Str("Послшть", "42"),
            };
        }
    }
    class Str
    {
        public Str(string X, string Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public string X { get; set; }
        public string Y { get; set; }

    }
}
