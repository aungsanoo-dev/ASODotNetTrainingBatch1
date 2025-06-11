using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace ASODotNetTrainingBatch1.Shared;

// Data Access Layer (DAL) using ADO.NET
public class AdoDotNetService
{
    private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

    //private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    //{
    //    DataSource = ".\\SQL2022Express",
    //    InitialCatalog = "DotNetTrainingBatch1",
    //    UserID = "sa",
    //    Password = "sasa@123",
    //    TrustServerCertificate = true
    //};

    public AdoDotNetService(SqlConnectionStringBuilder connectionStringBuilder)
    {
        _sqlConnectionStringBuilder = connectionStringBuilder;
    }
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

    public DataTable Query(string query, params SqlParameter[] parameters)
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

    public List<T> QueryV2<T>(string query, params SqlParameter[] parameters)
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

        string jsonStr = JsonConvert.SerializeObject(dt);
        var lst = JsonConvert.DeserializeObject<List<T>>(jsonStr);
        return lst;
    }
}
