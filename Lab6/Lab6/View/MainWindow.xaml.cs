
using Lab6.ViewModels;

using System.Windows;


namespace Lab6.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            MyViewModel vm = new MyViewModel();
            DataContext = vm;
            
        }


    }
}
