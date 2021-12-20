using System.Windows.Input;

namespace PersonalFinances
{
    internal class DataSaveLoader : Notifier
    {
        static DataSaveLoader instance;

        public static DataSaveLoader GetInstance()
        {
            if (instance == null)
            {
                instance = new();
            }
            return instance;
        }

        private DataSaveLoader() { }

        public CategoriesModel CategoriesModel { get; } = CategoriesModel.GetInstance();

        public IncomeSourcesModel IncomeSourcesModel { get; } = IncomeSourcesModel.GetInstance();

        public WalletsModel WalletsModel { get; } = WalletsModel.GetInstance();

        public OperationsList OperationsList { get; } = OperationsList.GetInstance();

        ICommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new DelegateCommand(param => Save(),
                                                      param => true);
                }
                return saveCommand;
            }
        }
        public void Save()
        {
            CategoriesModel.Save();
            IncomeSourcesModel.Save();
            WalletsModel.Save();
        }

        public bool IsNotLoaded { get; set; } = true;

        ICommand loadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (loadCommand == null)
                {
                    loadCommand = new DelegateCommand(param => Load(),
                                                      param => IsNotLoaded);
                }
                return loadCommand;
            }
        }
        public void Load()
        {
            IsNotLoaded = false;
            OnPropertyChanged("IsNotLoaded");
            CategoriesModel.Load();
            IncomeSourcesModel.Load();
            WalletsModel.Load();
        }
    }
}