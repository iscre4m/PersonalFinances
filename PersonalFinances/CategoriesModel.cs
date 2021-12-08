using System.Collections.ObjectModel;

namespace PersonalFinances
{
    internal class CategoriesModel
    {
        ObservableCollection<string> categories = new ObservableCollection<string>();
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