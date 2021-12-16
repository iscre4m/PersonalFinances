using System.Collections.ObjectModel;
using System.IO;
using System;

namespace PersonalFinances
{
    internal class WalletsModel
    {
        public ObservableCollection<Wallet> Wallets { get; set; } = new();

        public void Save()
        {
            FileStream save = new FileStream("Data/wallets.wal", FileMode.OpenOrCreate);
            BinaryWriter write = new(save);
            write.Write(Wallets.Count);
            for (int i = 0; i < Wallets.Count; i++)
            {
                Wallets[i].Save(write);
            }
            save.Close();
        }

        public void Download()
        {
            if(File.Exists("Data/wallets.wal"))
            {
                FileStream download= new FileStream("Data/wallets.wal", FileMode.OpenOrCreate);
                BinaryReader read = new(download);
                int count = read.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    Wallets.Add(new Wallet());
                    Wallets[i].Download(read);
                }
                read.Close();
            }
            else
            {
                return;
            }
        }
    }
}