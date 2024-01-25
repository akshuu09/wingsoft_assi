using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DotNetDatabaseExample
{
    public partial class MainForm : Form
    {
        private SqlConnection sqlConnection;
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;

        public MainForm()
        {
            InitializeComponent();

            
            string connectionString = "Your_Connection_String";
            sqlConnection = new SqlConnection(connectionString);

           
            dataAdapter = new SqlDataAdapter();
            dataSet = new DataSet();

            
            ConfigureDataAdapter();

           
            LoadData();
        }

        private void ConfigureDataAdapter()
        {
            
            dataAdapter.SelectCommand = new SqlCommand("GetAllEmployees", sqlConnection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            dataAdapter.InsertCommand = new SqlCommand("InsertEmployee", sqlConnection);
            dataAdapter.InsertCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.InsertCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50, "FirstName");
            dataAdapter.InsertCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 50, "LastName");
            dataAdapter.InsertCommand.Parameters.Add("@Salary", SqlDbType.Decimal, 18, "Salary");

            dataAdapter.UpdateCommand = new SqlCommand("UpdateEmployee", sqlConnection);
            dataAdapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.UpdateCommand.Parameters.Add("@EmployeeID", SqlDbType.Int, 4, "EmployeeID");
            dataAdapter.UpdateCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50, "FirstName");
            dataAdapter.UpdateCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 50, "LastName");
            dataAdapter.UpdateCommand.Parameters.Add("@Salary", SqlDbType.Decimal, 18, "Salary");

            dataAdapter.DeleteCommand = new SqlCommand("DeleteEmployee", sqlConnection);
            dataAdapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.DeleteCommand.Parameters.Add("@EmployeeID", SqlDbType.Int, 4, "EmployeeID");
        }

        private void LoadData()
        {
            
            dataAdapter.Fill(dataSet, "Employee");

           
            dataGridView.DataSource = dataSet.Tables["Employee"];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            dataAdapter.Update(dataSet, "Employee");
            LoadData();
        }
    }
}
