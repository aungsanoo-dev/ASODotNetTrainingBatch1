using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASODotNetTrainingBatch1.WinFormsApp
{
    public class SqlService
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".\\SQL2022Express",
            InitialCatalog = "DotNetTrainingBatch1",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public DataTable Query(string query, List<SqlParameter> parameters)
        {
            //con = new SqlConnection(F21Party.Properties.Settings.Default.F21PartyCon);
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            if (connection.State == ConnectionState.Open)
                connection.Close();
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddRange(parameters.ToArray());
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dt);

            connection.Close();

            return dt;
        }

        public DataTable Query(string query,params SqlParameter[] parameters)
        {
            //con = new SqlConnection(F21Party.Properties.Settings.Default.F21PartyCon);
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            if (connection.State == ConnectionState.Open)
                connection.Close();
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddRange(parameters);
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dt);

            connection.Close();

            return dt;
        }
        public int Execute(string query, params SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            if (connection.State == ConnectionState.Open)
                connection.Close();
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddRange(parameters);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
 
            return result;
        }
    }
}
