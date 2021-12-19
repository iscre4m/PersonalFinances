using System.Windows;
using System;
using System.Windows.Input;

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
                Application.Current.Resources.MergedDictionaries.Add(lightTheme);
                isDarkTheme = false;
                return;
            }
            Application.Current.Resources.MergedDictionaries.Add(darkTheme);
            isDarkTheme = true;
        }
    }
}