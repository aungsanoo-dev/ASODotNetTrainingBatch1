using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;

namespace ASODotNetTrainingBatch1.Shared
{
    // Data Access Layer (DAL) using Dapper ORM
    public class Dapper2Service : IDbV2Service
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;
        public Dapper2Service(IConfiguration configuration)
        {
            _sqlConnectionStringBuilder = new SqlConnectionStringBuilder(configuration.GetConnectionString("DbConnection"));

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
