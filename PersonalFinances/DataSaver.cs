using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace PersonalFinances
{
    internal class DataSaver:Notifier
    {



        CategoriesModel categoriesModel=CategoriesModel.GetInstance();

        public CategoriesModel CategoriesModel
        {
            get=>categoriesModel;
            set=>categoriesModel = value;
        }

        WalletsModel walletsModel;

        public WalletsModel WalletsModel
        {
            get => walletsModel;
            set => walletsModel = value;
        }

        OperationsList operationsModel;

        public OperationsList OperationsModel
        {
            get => operationsModel;
            set => operationsModel = value;
        }

        public void Save()
        {
            categoriesModel.Save();
            walletsModel.Save();
            //operationsModel.Save();
        }

        public void Download()
        {
            categoriesModel.Download();
            walletsModel.Download();
        }


        ICommand saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new DelegateCommand(param => Save(),
                                                           param => WalletsModel.Wallets != null
                                                                 && OperationsModel.Operations!=null
                                                                 && CategoriesModel.Categories!=null);
                }
                return saveCommand;
            }

        }

        ICommand downloadCommand;

        public ICommand DownloadCommand
        {
            get
            {
                if (downloadCommand == null)
                {
                    downloadCommand = new DelegateCommand(param => Download(),
                                                           param => CategoriesModel!=null);
                }
                return downloadCommand;
            }

        }


    }
}
