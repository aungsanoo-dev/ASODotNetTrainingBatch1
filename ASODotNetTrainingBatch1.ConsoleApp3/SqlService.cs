﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ASODotNetTrainingBatch1.ConsoleApp3
{
    internal class SqlService
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".\\SQL2022Express",
            InitialCatalog = "DotNetTrainingBatch1",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };
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
