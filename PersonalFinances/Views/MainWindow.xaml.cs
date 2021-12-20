using System.Windows;
using System;
using System.Windows.Input;
using System.Windows.Media;

namespace PersonalFinances
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isDarkTheme;
        readonly ResourceDictionary? lightTheme = Application.LoadComponent(new Uri("../../../Styles/Light.xaml",
                                                                           UriKind.Relative)) as ResourceDictionary;
        readonly ResourceDictionary? darkTheme = Application.LoadComponent(new Uri("../../../Styles/Dark.xaml",
                                                                          UriKind.Relative)) as ResourceDictionary;

        public MainWindow()
        {
            InitializeComponent();
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(lightTheme);
            DataContext = this;
            saveButton.DataContext = DataSaveLoader.GetInstance();
            loadButton.DataContext = DataSaveLoader.GetInstance();
        }   

        ICommand changeThemeCommand;
        public ICommand ChangeThemeCommand
        {
            get
            {
                if (changeThemeCommand == null)
                {
                    changeThemeCommand = new DelegateCommand(param => ChangeTheme(),
                                                             param => true);
                }
                return changeThemeCommand;
            }
        }
        void ChangeTheme()
        {
            Application.Current.Resources.Clear();
            if (isDarkTheme)
            {
                Theme.Background = Brushes.Black;
                Application.Current.Resources.MergedDictionaries.Add(lightTheme);
                isDarkTheme = false;
                return;
            }
            Theme.Background = Brushes.White;
            Application.Current.Resources.MergedDictionaries.Add(darkTheme);
            isDarkTheme = true;
        }
    }
}