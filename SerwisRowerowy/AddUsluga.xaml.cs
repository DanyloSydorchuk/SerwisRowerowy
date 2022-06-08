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
using System.Windows.Shapes;

namespace SerwisRowerowy
{
    /// <summary>
    /// Interaction logic for AddUsluga.xaml
    /// </summary>
    public partial class AddUsluga : Window
    {
        public AddUsluga()
        {
            InitializeComponent();
        }

        private void btnAddUsluga_Click(object sender, RoutedEventArgs e)
        {
            UslugiRepository uslugiRepository = new UslugiRepository();
            if (dcCena.Value is null)
            {
                dcCena.Value = 10;
            }
            decimal cena = (decimal)dcCena.Value;
            if(cena >=0 && tbNazwa.Text != "" && tbAkronim.Text != "")
            {
                if (tbAkronim.Text.Length == 5)
                {
                    uslugiRepository.AddUslugiRepo(tbNazwa.Text, tbAkronim.Text, cena);
                    Close();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Main.Content = new UslugiPage();
                }
                else
                {
                    MessageBox.Show("Akronim musi mieć długość 5 znaków");
                }
            }
            else
            {
                MessageBox.Show("Niepoprawne dane!");
            }   
        }     
    }
}
