using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerwisRowerowy
{
    public class UslugiRepository
    {
        public List<Uslugi> uslugiRepository { get; set; }

        public UslugiRepository()
        {
            uslugiRepository = GetUslugiRepo();
        }

        private List<Uslugi> GetUslugiRepo()
        {
            List<Uslugi> listaUslug = new List<Uslugi>();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SerwisRowerowyDBConnectionString))
            {
                if (connection == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in MovieCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("select Nazwa,Cena from Uslugi", connection);
                connection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    Uslugi uslugi = new Uslugi();
                    uslugi.Nazwa = row["Nazwa"].ToString();
                    uslugi.cena = (decimal)row["Cena"];
                    listaUslug.Add(uslugi);
                }
                return listaUslug;
            }
            
        }
    }
}
