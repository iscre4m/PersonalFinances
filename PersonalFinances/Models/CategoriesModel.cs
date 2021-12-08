using System.Collections.ObjectModel;

namespace PersonalFinances
{
    internal class CategoriesModel
    {
        readonly ObservableCollection<string> categories = new();
        public ObservableCollection<string> Categories
        {
            get
            {
                return categories;
            }
        }

        public CategoriesModel()
        {
            categories.Add("Кино");
            categories.Add("Продукты");
            categories.Add("Развлечения");
        }
    }
}