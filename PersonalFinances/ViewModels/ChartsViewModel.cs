using System.Collections.Generic;

namespace PersonalFinances
{
    internal class ChartsViewModel : Notifier
    {
        ChartsModel chartsModel;

        public ChartsModel ChartsModel
        {
            get
            {
                return chartsModel;
            }
            set
            {
                chartsModel = value;
                OnPropertyChanged("ChartsModel");
            }
        }
        public ChartsViewModel()
        {
          
        }
    }
}