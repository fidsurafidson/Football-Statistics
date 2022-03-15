using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PariFoot
{
    public class Connexion
    {
        public SqlConnection ConnectToSql()
        {
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            conn.ConnectionString = "Data Source=LAPTOP-JUN5CKIO;Initial Catalog=Foot;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                conn.Open();
                //MessageBox.Show("Mande mamaaaaaaaaaaaaaaaa!!!");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Erreur de connexion mec!!!");
            }
            try
            {
                return conn;
            }
            finally
            {
                conn.Close();
            }
        }
        public Connexion()
        {
        }
    }
}