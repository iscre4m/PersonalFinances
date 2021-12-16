using System.Collections.ObjectModel;
using System.IO;

namespace PersonalFinances
{
    internal class OperationsList
    {
        public ObservableCollection<Operation> Operations { get; } = new();

        public void Save()
        {
            FileStream save = new("Data/operations.wal", FileMode.OpenOrCreate);
            BinaryWriter write = new(save);
            write.Write(Operations.Count);
            for (int i = 0; i < Operations.Count; i++)
            {
                Operations[i].Save(write);
            }
        }
        //public void Download()
        //{
        //    if(File.Exists("Data/operations.wal"))
        //    {
        //        FileStream download = new("Data/operations.wal", FileMode.OpenOrCreate);
        //        BinaryReader read = new(download);
        //        int count = read.ReadInt32();
        //        for (int i = 0; i < count; i++)
        //        {
        //            Operations.Add(new Operation());
        //        }
        //    }
        //}
    }
}