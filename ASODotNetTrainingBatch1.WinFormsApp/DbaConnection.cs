using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASODotNetTrainingBatch1.WinFormsApp
{
    internal class DbaConnection
    {
        private SqlConnection? con;

        public void DataBaseConn()
        {

            try
            {
                SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
                {
                    DataSource = ".\\SQL2022Express",
                    InitialCatalog = "DotNetTrainingBatch1",
                    UserID = "sa",
                    Password = "sasa@123",
                    TrustServerCertificate = true
                };

                //con = new SqlConnection(F21Party.Properties.Settings.Default.F21PartyCon);
                con = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error In DataBaseConn");
            }
        }
    }
}
