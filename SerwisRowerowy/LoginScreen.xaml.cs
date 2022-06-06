using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        SerwisRowerowyDBEntities dataContext = new SerwisRowerowyDBEntities();
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Users user = dataContext.Users.Where(u => u.Username == tbUsername.Text && u.Password == tbPassword.Password).FirstOrDefault();
            if (user!=null)
            {
                MainWindow dashboard = new MainWindow();
                dashboard.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect.");
            }
            
            
                
                
        }

    }
    
}
