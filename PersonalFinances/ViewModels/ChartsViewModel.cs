using System.Collections.Generic;

namespace PersonalFinances
{
    internal class ChartsViewModel : Notifier
    {
        OperationsModel operationsModel;
        public OperationsModel OperationsModel
        {
            get
            {
                return operationsModel;
            }
            set
            {
                operationsModel = value;
            }
        }
        public List<Str> strs { get; set; }
        public ChartsViewModel()
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