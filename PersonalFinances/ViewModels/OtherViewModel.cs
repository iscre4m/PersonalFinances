﻿using System.Windows.Input;

namespace PersonalFinances
{
    internal class OtherViewModel : Notifier
    {
        #region Источники дохода
        IncomeSourcesModel incomeSourcesModel;
        public IncomeSourcesModel IncomeSourcesModel
        {
            get => incomeSourcesModel;
            set => incomeSourcesModel = value;
        }

        string incomeSourceTitle = "";
        public string IncomeSourceTitle
        {
            get => incomeSourceTitle;
            set
            {
                if (value != incomeSourceTitle)
                {
                    incomeSourceTitle = value;
                    OnPropertyChanged("IncomeSourceTitle");
                }
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
                                                                 param => IncomeSourceTitle != "");
                }
                return addIncomeSourceCommand;
            }
        }
        void AddIncomeSource()
        {
            IncomeSourcesModel.IncomeSources.Add(IncomeSourceTitle);
            IncomeSourceTitle = "";
        }

        int selectedIncomeSourceIndex = -1;
        public int SelectedIncomeSourceIndex
        {
            get => selectedIncomeSourceIndex;
            set
            {
                if (value != selectedIncomeSourceIndex)
                {
                    selectedIncomeSourceIndex = value;
                    OnPropertyChanged("SelectedIncomeSourceIndex");
                }
            }
        }

        ICommand removeIncomeSourceCommand;
        public ICommand RemoveIncomeSourceCommand
        {
            get
            {
                if (removeIncomeSourceCommand == null)
                {
                    removeIncomeSourceCommand = new DelegateCommand(param => RemoveIncomeSource(),
                                                                    param => selectedIncomeSourceIndex > -1);
                }
                return removeIncomeSourceCommand;
            }
        }
        void RemoveIncomeSource()
        {
            IncomeSourcesModel.IncomeSources.RemoveAt(selectedIncomeSourceIndex);
        }
        #endregion

        #region Категории
        CategoriesModel categoriesModel;
        public CategoriesModel CategoriesModel
        {
            get => categoriesModel;
            set => categoriesModel = value;
        }

        OperationsCapacitor operationsCapacitor;
        public OperationsCapacitor OperationsCapacitor
        {
            get => operationsCapacitor;
            set => operationsCapacitor = value;
        }

        string categoryTitle = "";
        public string CategoryTitle
        {
            get => categoryTitle;
            set
            {
                if (value != categoryTitle)
                {
                    categoryTitle = value;
                    OnPropertyChanged("CategoryTitle");
                }
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
                                                             param => CategoryTitle != "");
                }
                return addCategoryCommand;
            }
        }
        void AddCategory()
        {
            CategoriesModel.Categories.Add(CategoryTitle);
            operationsCapacitor.Sums.Add(0);
            CategoryTitle = "";
        }

        int selectedCategoryIndex = -1;
        public int SelectedCategoryIndex
        {
            get => selectedCategoryIndex;
            set
            {
                if (value != selectedCategoryIndex)
                {
                    selectedCategoryIndex = value;
                    OnPropertyChanged("SelectedCategoryIndex");
                }
            }
        }

        ICommand removeCategoryCommand;
        public ICommand RemoveCategoryCommand
        {
            get
            {
                if (removeCategoryCommand == null)
                {
                    removeCategoryCommand = new DelegateCommand(param => RemoveCategory(),
                                                                param => selectedCategoryIndex > -1);
                }
                return removeCategoryCommand;
            }
        }
        void RemoveCategory()
        {
            CategoriesModel.Categories.RemoveAt(selectedCategoryIndex);
        }
        #endregion
    }
}