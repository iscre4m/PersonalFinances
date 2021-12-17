using System.Collections.ObjectModel;
using System.IO;

namespace PersonalFinances
{
    internal class WalletsModel
    {
        const string PATH = "../../../Data/wallets.wal";

        public ObservableCollection<Wallet> Wallets { get; set; } = new();

        public void Save()
        {
            FileStream saveStream = new(PATH, FileMode.OpenOrCreate);
            BinaryWriter writer = new(saveStream);
            writer.Write(Wallets.Count);
            foreach (Wallet wallet in Wallets)
            {
                wallet.Save(writer);
            }
            writer.Close();
            saveStream.Close();
        }

        public void Download()
        {
            if (File.Exists(PATH))
            {
                FileStream downloadStream = new(PATH, FileMode.OpenOrCreate);
                BinaryReader reader = new(downloadStream);
                int count = reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    Wallets.Add(new());
                    Wallets[i].Download(reader);
                }
                reader.Close();
                downloadStream.Close();
            }
        }
    }
}