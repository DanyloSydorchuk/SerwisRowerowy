using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace SerwisRowerowy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new MainPage();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow dashboard = new MainWindow();
            dashboard.Show();
            Close();
        }

        private void btnUslugi_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new UslugiPage();
        }

        private void btnZlecenia_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnUstawienia_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnWyloguj_Click(object sender, RoutedEventArgs e)
        {
            LoginScreen dashboard = new LoginScreen();
            dashboard.Show();
            Close();
        }
        
    }
}
