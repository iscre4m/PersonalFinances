using System.Collections.ObjectModel;
using System.IO;

namespace PersonalFinances
{
    internal class CategoriesModel
    {
        static CategoriesModel instance;
        const string PATH = "../../../Data/categories.wal";

        public static CategoriesModel GetInstance()
        {
            if (instance == null)
            {
                instance = new();
            }
            return instance;
        }

        private CategoriesModel() {}

        public ObservableCollection<string> Categories { get; } = new();

        public void Save()
        {
            FileStream saveStream = new(PATH, FileMode.OpenOrCreate);
            BinaryWriter writer = new(saveStream);
            writer.Write(Categories.Count);
            foreach (string category in Categories)
            {
                writer.Write(category);
            }
            writer.Close();
            saveStream.Close();
        }

        public void Load()
        {
            if (File.Exists(PATH))
            {
                FileStream downloadStream = new(PATH, FileMode.Open);
                BinaryReader reader = new(downloadStream);
                downloadStream.Position = 0;
                int count = reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    Categories.Add(reader.ReadString());
                }
                reader.Close();
                downloadStream.Close();
            }
        }
    }
}