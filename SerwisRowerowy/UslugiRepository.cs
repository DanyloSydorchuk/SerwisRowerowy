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

        public List<Uslugi> GetUslugiRepo()
        {
            List<Uslugi> listaUslug = new List<Uslugi>();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SerwisRowerowyDBConnectionString))
            {
                if (connection == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in SerwisRowerowyCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("select Nazwa,Cena from Uslugi", connection);
                connection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                //DataTable dataTable = new DataTable();
                //sqlDataAdapter.Fill(dataTable);
                //foreach (DataRow row in dataTable.Rows)
                //{
                //    Uslugi uslugi = new Uslugi();
                //    uslugi.Nazwa = row["Nazwa"].ToString();
                //    uslugi.cena = (decimal)row["Cena"];
                //    listaUslug.Add(uslugi);
                //}
                //return listaUslug;
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                int id = 0;
                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    id++;
                    listaUslug.Add(new Uslugi
                    {
                        id=id.ToString(),
                        Nazwa = dataRow["Nazwa"].ToString(),
                        cena = (decimal)dataRow["Cena"]
                    });
                }
                return listaUslug;
            }
            
        }

        public void AddUslugiRepo(string nazwa, string akronim, decimal cena)
        {
            //List<Uslugi> listaUslug = new List<Uslugi>();
            //uslugiRepository.Add(new Uslugi { id = akronim,
            //    Nazwa = nazwa,
            //    cena = cena });
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SerwisRowerowyDBConnectionString))
            {
                if (connection == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in SerwisRowerowyCatalog->Properties-?Settings.settings");
                }
                SqlCommand query = new SqlCommand();
                query.Connection = connection;
                connection.Open();
                query.CommandText = "INSERT INTO Uslugi VALUES(@akronim, @nazwa, @cena)";
                query.Prepare();
                query.Parameters.AddWithValue("@akronim", akronim);
                query.Parameters.AddWithValue("@nazwa", nazwa);
                query.Parameters.AddWithValue("@cena", cena);
                query.ExecuteNonQuery();
            }
        }

        public void EditUsluge()
        {

        }
    }
}
