using System.Collections.ObjectModel;

namespace PersonalFinances
{
    internal class CategoriesModel
    {
        static CategoriesModel instance;

        public static CategoriesModel GetInstance()
        {
            if (instance == null)
            {
                instance = new CategoriesModel();
            }
            return instance;
        }

        readonly ObservableCollection<string> categories = new();
        public ObservableCollection<string> Categories
        {
            get => categories;
        }

        private CategoriesModel()
        {
            categories.Add("Кино");
            categories.Add("Продукты");
            categories.Add("Развлечения");
            categories.Add("Прочее");
        }
    }
}