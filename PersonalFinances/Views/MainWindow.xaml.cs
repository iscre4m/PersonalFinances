using System.Windows;
using System;

namespace PersonalFinances
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetTheme();
        }

        void SetTheme()
        {
            //Uri ur;
            //ur = new Uri("Stylies/Light.xaml", UriKind.Relative);

            //ResourceDictionary resourceDict = Application.LoadComponent(ur) as ResourceDictionary;

            //Application.Current.Resources.Clear();

            //Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }
}