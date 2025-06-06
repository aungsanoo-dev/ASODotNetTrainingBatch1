using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASODotNetTrainingBatch1.ConsoleApp2
{
    internal class HomeworkService
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".\\SQL2022Express",
            InitialCatalog = "DotNetTrainingBatch1",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public void Read()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = "SELECT * FROM Tbl_Homework";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                Console.WriteLine(dr["No"]);
                Console.WriteLine(dr["Name"]);
                Console.WriteLine(dr["GitHubUserName"]);
                Console.WriteLine("-----------------------------");
            }
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["No"]);
                Console.WriteLine(dr["Name"]);
                Console.WriteLine(dr["GitHubUserName"]);
                Console.WriteLine("-----------------------------");
            }
        }

        public void Detail(int no)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = "SELECT * FROM Tbl_Homework";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No record found.");
                return;
            }
            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["No"]);
            Console.WriteLine(dr["Name"]);
            Console.WriteLine(dr["GitHubUserName"]);
            Console.WriteLine("-----------------------------");
            
        }

        public void Create()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine()!;

            Console.WriteLine("Enter GitHub UserName: ");
            string gitHubUserName = Console.ReadLine()!;

            Console.WriteLine("Enter GitHubRepoLink: ");
            string gitHubRepoLink = Console.ReadLine()!;

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = $@"INSERT INTO Tbl_Homework 
            (Name, GitHubUserName, GitHubRepoLink) VALUES 
            ('{name}', '{gitHubUserName}', '{gitHubRepoLink}')";
            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Update()
        {
            Console.Write("Enter Id: ");
            string id = Console.ReadLine()!;

            Console.Write("Enter Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Enter GitHub UserName: ");
            string gitHubUserName = Console.ReadLine()!;

            Console.Write("Enter GitHubRepoLink: ");
            string gitHubRepoLink = Console.ReadLine()!;

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = $@"
            UPDATE [dbo].[Tbl_Homework]
            SET [Name] = @Name
            ,[GitHubUserName] = @GitHubUserName
            ,[GitHubRepoLink] = @GitHubRepoLink
            WHERE No = @Id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@GitHubUserName", gitHubUserName);
            cmd.Parameters.AddWithValue("@GitHubRepoLink", gitHubRepoLink);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Login()
        {
            Console.Write("Enter UserName: ");
            string userName = Console.ReadLine()!;

            Console.Write("Enter Password: ");
            string password = Console.ReadLine()!;

            string query = @$"SELECT * FROM Tbl_User WHERE 
            UserName = '@UserName' AND 
            Password = '@Password'";
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserName", userName);
            cmd.Parameters.AddWithValue("@Password", password);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();
        }

        public void LoginWithStoredProcedure()
        {
            Console.Write("Enter UserName: ");
            string userName = Console.ReadLine()!;

            Console.Write("Enter Password: ");
            string password = Console.ReadLine()!;

            string query = @$"Sp_Login";
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", userName);
            cmd.Parameters.AddWithValue("@Password", password);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();
        }
    }
}
