using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace ASODotNetTrainingBatch1.Shared
{
    public class DapperService
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".\\SQL2022Express",
            InitialCatalog = "DotNetTrainingBatch1",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public DapperService(SqlConnectionStringBuilder connectionStringBuilder)
        {
            _sqlConnectionStringBuilder = connectionStringBuilder;
        }
        public List<ASO> Query<ASO>(string query, object? parameters = null)
        {
            using IDbConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            if (connection.State == ConnectionState.Open)
                connection.Close();
            connection.Open();
            var lst = connection.Query<ASO>(query, parameters).ToList();

            //SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.Parameters.AddRange(parameters.ToArray());
            //DataTable dt = new DataTable();
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            //sqlDataAdapter.Fill(dt);

            //connection.Close();

            return lst;
        }

        //public List Query(string query, object? parameters = null)
        //{
        //    using IDbConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        //    if (connection.State == ConnectionState.Open)
        //        connection.Close();
        //    connection.Open();
        //    var lst = connection.Query(query, parameters).ToList();

        //    //SqlCommand cmd = new SqlCommand(query, connection);
        //    //cmd.Parameters.AddRange(parameters.ToArray());
        //    //DataTable dt = new DataTable();
        //    //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
        //    //sqlDataAdapter.Fill(dt);

        //    //connection.Close();

        //    return lst;
        //}

        public int Execute(string query, object? parameters = null)
        {
            using IDbConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            if (connection.State == ConnectionState.Open)
                connection.Close();
            connection.Open();
            var result = connection.Execute(query, parameters);
            //SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.Parameters.AddRange(parameters);
            //int result = cmd.ExecuteNonQuery();
            //connection.Close();  

            return result;
        }
    }
}
