using System.Collections.ObjectModel;
using System.IO;

namespace PersonalFinances
{
    internal class IncomeSourcesModel
    {
        static IncomeSourcesModel instance;
        const string PATH = "../../../Data/income sources.wal";

        public static IncomeSourcesModel GetInstance()
        {
            if (instance == null)
            {
                instance = new();
            }
            return instance;
        }

        private IncomeSourcesModel() { }

        public ObservableCollection<string> IncomeSources { get; } = new();

        public void Save()
        {
            FileStream saveStream = new(PATH, FileMode.OpenOrCreate);
            BinaryWriter writer = new(saveStream);
            writer.Write(IncomeSources.Count);
            foreach (string incomeSource in IncomeSources)
            {
                writer.Write(incomeSource);
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
                    IncomeSources.Add(reader.ReadString());
                }
                reader.Close();
                downloadStream.Close();
            }
        }
    }
}