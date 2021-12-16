using System.Collections.ObjectModel;
using System.IO;

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
            //categories.Add("Кино");
            //categories.Add("Продукты");
            //categories.Add("Развлечения");
            //categories.Add("Прочее");
        }

        public void Save()
        {
            FileStream saveCategory = new FileStream("Data/category.wal", FileMode.OpenOrCreate);
            BinaryWriter write = new(saveCategory);
            write.Write(categories.Count);
            foreach(string str in categories)
            {
                write.Write(str);
            }
            saveCategory.Close();
        }
        public void Download()
        {
            if(File.Exists("Data/category.wal"))
            {
                FileStream downloadCategory = new FileStream("Data/category.wal", FileMode.Open);
                BinaryReader read = new(downloadCategory);
                downloadCategory.Position = 0;
                int count = read.ReadInt32();
                for(int i=0;i<count;i++)
                {
                  
                    Categories.Add(read.ReadString());
                }
                downloadCategory.Close();
            }
            else
            {
                return;
            }
        }
    }
}