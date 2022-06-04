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
            //SqlConnection sqlCon = new SqlConnection(@"Data Source=localhost; Initial Catalog=SerwisRowerowyDB; Integrated Security=True;"); 
            //try
            //{
            //    if (sqlCon.State == ConnectionState.Closed)
            //        sqlCon.Open();
            //    string query = "Select count(1) from Users where Username=@Username and Password=@Password";
            //    SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
            //    sqlCommand.CommandType = CommandType.Text;
            //    sqlCommand.Parameters.AddWithValue("@Username",tbUsername.Text);
            //    sqlCommand.Parameters.AddWithValue("@Password", tbPassword.Password);
            //    int count = Convert.ToInt32(sqlCommand.ExecuteScalar());

            //    if(count == 1)
            //    {
            //        MainWindow dashboard = new MainWindow();
            //        dashboard.Show();
            //        this.Close();
            //    }
            //    else
            //    {

            //        MessageBox.Show("Username or passwprd is incorrect.");
            //    }
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    sqlCon.Close();
            //}
            
                //string query = "Select count(1) from Users where Username=@Username and Password=@Password";
                //sqlCommand.Parameters.AddWithValue("@Username", tbUsername.Text);
                //sqlCommand.Parameters.AddWithValue("@Password", tbPassword.Password);
                //List<UserLogin> lista = dataContext.UserLogins.ToList();
                var user = dataContext.Users.Where(u => u.Username == tbUsername.Text && u.Password == tbPassword.Password).FirstOrDefault();
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
