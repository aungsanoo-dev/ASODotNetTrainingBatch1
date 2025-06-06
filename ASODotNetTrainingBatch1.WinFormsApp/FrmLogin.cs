using Microsoft.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace ASODotNetTrainingBatch1.WinFormsApp
{
    public partial class FrmLogin : Form
    {
        private readonly SqlService _sqlService;
        public FrmLogin()
        {
            InitializeComponent();
            _sqlService = new SqlService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                string query = $"SELECT * FROM Tbl_User WHERE Username=@UserName AND Password=@Password";
                //SqlParameter parameter1 = new SqlParameter("@UserName", username);
                //SqlParameter parameter2 = new SqlParameter("@Password", password);

                //List<SqlParameter> parameters = new List<SqlParameter>
                //{
                //    new SqlParameter("@UserName", username),
                //    new SqlParameter("@Password", password)
                //};

                //DataTable dt = _sqlService.Query(query, parameters);

                DataTable dt = _sqlService.Query(query,
                    new SqlParameter("@UserName", username),
                    new SqlParameter("@Password", password));


                //SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
                //{
                //    DataSource = ".\\SQL2022Express",
                //    InitialCatalog = "DotNetTrainingBatch1",
                //    UserID = "sa",
                //    Password = "sasa@123",
                //    TrustServerCertificate = true
                //};

                ////con = new SqlConnection(F21Party.Properties.Settings.Default.F21PartyCon);
                //SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
                //if (connection.State == ConnectionState.Open)
                //    connection.Close();
                //connection.Open();

                //SqlCommand cmd = new SqlCommand(query, connection);
                //cmd.Parameters.AddWithValue("@Username", username);
                //cmd.Parameters.AddWithValue("@Password", password);
                //DataTable dt = new DataTable();
                //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                //sqlDataAdapter.Fill(dt);

                //connection.Close();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("User does not exist");
                    return;
                }

                MessageBox.Show("Login Successful.");

                AppSetting.CurrentUser = Convert.ToInt32(dt.Rows[0]["Id"]);

                txtUsername.Clear();
                txtPassword.Clear();

                this.Hide();

                FrmMenu frm = new FrmMenu();
                //frm.Show();
                frm.ShowDialog();

                this.Show();

                txtUsername.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error In DataBaseConn");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            
            if(e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
                
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
