using System.Windows.Input;

namespace PersonalFinances
{
    internal class OtherViewModel : Notifier
    {
        IncomeSourcesModel incomeSourcesModel;
        public IncomeSourcesModel IncomeSourcesModel
        {
            get
            {
                return incomeSourcesModel;
            }
            set
            {
                incomeSourcesModel = value;
            }
        }

        ICommand addIncomeSourceCommand;
        public ICommand AddIncomeSourceCommand
        {
            get
            {
                if (addIncomeSourceCommand == null)
                {
                    addIncomeSourceCommand = new DelegateCommand(param => AddIncomeSource(),
                                                                 param => (IncomeSourceTitle != ""));
                }
                return addIncomeSourceCommand;
            }
        }
        void AddIncomeSource()
        {
            IncomeSourcesModel.IncomeSources.Add(IncomeSourceTitle);
            IncomeSourceTitle = "";
        }

        ICommand removeIncomeSourceCommand;
        public ICommand RemoveIncomeSourceCommand
        {
            get
            {
                if (removeIncomeSourceCommand == null)
                {
                    removeIncomeSourceCommand = new DelegateCommand(param => RemoveIncomeSource(),
                                                                    param => (selectedIncomeSourceIndex > -1));
                }
                return removeIncomeSourceCommand;
            }
        }
        void RemoveIncomeSource()
        {
            IncomeSourcesModel.IncomeSources.RemoveAt(selectedIncomeSourceIndex);
        }

        string incomeSourceTitle = "";
        public string IncomeSourceTitle
        {
            get
            {
                return incomeSourceTitle;
            }
            set
            {
                if (value != incomeSourceTitle)
                {
                    incomeSourceTitle = value;
                    OnPropertyChanged("IncomeSourceTitle");
                }
            }
        }

        int selectedIncomeSourceIndex = -1;
        public int SelectedIncomeSourceIndex
        {
            get
            {
                return selectedIncomeSourceIndex;
            }
            set
            {
                if (value != selectedIncomeSourceIndex)
                {
                    selectedIncomeSourceIndex = value;
                    OnPropertyChanged("SelectedIncomeSourceIndex");
                }
            }
        }

        CategoriesModel categoriesModel;
        public CategoriesModel CategoriesModel
        {
            get
            {
                return categoriesModel;
            }
            set
            {
                categoriesModel = value;
            }
        }

        ICommand addCategoryCommand;
        public ICommand AddCategoryCommand
        {
            get
            {
                if (addCategoryCommand == null)
                {
                    addCategoryCommand = new DelegateCommand(param => AddCategory(),
                                                             param => (CategoryTitle != ""));
                }
                return addCategoryCommand;
            }
        }
        void AddCategory()
        {
            CategoriesModel.Categories.Add(CategoryTitle);
            CategoryTitle = "";
            OnPropertyChanged("CategoryTitle");
        }

        ICommand removeCategoryCommand;
        public ICommand RemoveCategoryCommand
        {
            get
            {
                if (removeCategoryCommand == null)
                {
                    removeCategoryCommand = new DelegateCommand(param => RemoveCategory(),
                                                                param => (selectedCategoryIndex > -1));
                }
                return removeCategoryCommand;
            }
        }
        void RemoveCategory()
        {
            CategoriesModel.Categories.RemoveAt(selectedCategoryIndex);
        }

        string categoryTitle = "";
        public string CategoryTitle
        {
            get
            {
                return categoryTitle;
            }
            set
            {
                if (value != categoryTitle)
                {
                    categoryTitle = value;
                    OnPropertyChanged("CategoryTitle");
                }
            }
        }

        int selectedCategoryIndex = -1;
        public int SelectedCategoryIndex
        {
            get
            {
                return selectedCategoryIndex;
            }
            set
            {
                if (value != selectedCategoryIndex)
                {
                    selectedCategoryIndex = value;
                    OnPropertyChanged("SelectedCategoryIndex");
                }
            }
        }
    }
}