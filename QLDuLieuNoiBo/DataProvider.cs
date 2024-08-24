using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
namespace QLDuLieuNoiBo
{
    using CustomOracleConnection = Oracle.ManagedDataAccess.Client.OracleConnection;
    public class DataProvider
    {
        private string username;
        private string password;
        private string connectString;
        public static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set { DataProvider.instance = value; }
        }
        private DataProvider() { }


        public DataTable ExecuteQueryOracle(string query)
        {
            //MessageBox.Show(query);
            DataTable dt = new DataTable();
            CustomOracleConnection connection = new CustomOracleConnection(connectString);
            connection.Open();
            OracleCommand cmd = new OracleCommand(query, connection);
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }
        public void changeLogin(string _username, string _password)
        {
            string dataSource;
            this.username = _username;
            this.password = _password;

            // Xác định cơ sở dữ liệu dựa trên tên người dùng
            if (username.IndexOf("OLS", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                dataSource = "localhost:1521/QLDLNBOLS"; 
            }
            else
            {
                dataSource = "localhost:1521/xe"; 
            }

            connectString = $"User Id={username};Password={password};Data Source={dataSource}";
        }
        public int ExecuteNonQueryOracle(string query)
        {
            //MessageBox.Show(query);
            int res = 0;
            CustomOracleConnection connection = new CustomOracleConnection(connectString);
            connection.Open();
            OracleCommand cmd = new OracleCommand(query, connection);
            res = cmd.ExecuteNonQuery();
            connection.Close();
            return res;
        }
        public void ExecuteRunOracle(string query)
        {
            //MessageBox.Show(query);
            CustomOracleConnection connection = new CustomOracleConnection(connectString);
            connection.Open();
            OracleCommand cmd = new OracleCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public object ExecuteScalarOracle(string query)
        {
            object res = null;
            CustomOracleConnection connection = new CustomOracleConnection(connectString);
            connection.Open();
            OracleCommand cmd = new OracleCommand(query, connection);
            res = cmd.ExecuteScalar();
            connection.Close();
            return res;
        }
        public void TrueSession()
        {
            DataProvider.Instance.ExecuteRunOracle("ALTER SESSION SET" + '"' + "_ORACLE_SCRIPT" + '"' + "= TRUE");
        }
        public void FalseSession()
        {
            DataProvider.Instance.ExecuteRunOracle("ALTER SESSION SET" + '"' + "_ORACLE_SCRIPT" + '"' + "= FALSE");
        }

        public decimal GetTotalSalary()
        {
            using (CustomOracleConnection connection = new CustomOracleConnection(connectString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("ad.CS7_1_TINH_TONG_LUONG", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add the OUT parameter
                    OracleParameter outParam = new OracleParameter("total_salary", OracleDbType.Decimal);
                    outParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outParam);

                    command.ExecuteNonQuery();

                    // Cast OracleDecimal to decimal
                    Oracle.ManagedDataAccess.Types.OracleDecimal oracleDecimal = (Oracle.ManagedDataAccess.Types.OracleDecimal)command.Parameters["total_salary"].Value;
                    return oracleDecimal.Value;
                }
            }
        }

        public decimal getRevenue(int year, string semester, string courseId)
        {
            using (CustomOracleConnection connection = new CustomOracleConnection(connectString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("ad.CS_7_2_TINH_DOANH_THU_HOC_PHAN", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add input parameters
                    command.Parameters.Add("p_year", OracleDbType.Int32).Value = year;
                    command.Parameters.Add("p_semester", OracleDbType.Varchar2).Value = semester;
                    command.Parameters.Add("p_course_id", OracleDbType.Varchar2).Value = courseId;

                    // Add the OUT parameter
                    OracleParameter outParam = new OracleParameter("p_revenue", OracleDbType.Decimal);
                    outParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outParam);

                    command.ExecuteNonQuery();

                    // Cast OracleDecimal to decimal
                    Oracle.ManagedDataAccess.Types.OracleDecimal oracleDecimal = (Oracle.ManagedDataAccess.Types.OracleDecimal)command.Parameters["p_revenue"].Value;
                    return oracleDecimal.Value;
                }
            }

        }
        public string ExecuteStringTypeQueryOracle(string query)
        {
            DataTable dt = new DataTable();
            CustomOracleConnection connection = new CustomOracleConnection(connectString);
            connection.Open();
            OracleCommand cmd = new OracleCommand(query, connection);
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            adapter.Fill(dt);
            connection.Close();

            if (dt.Rows.Count > 0 && dt.Columns.Count > 0)
            {
                // Assuming you want the value from the first row and first column
                return dt.Rows[0][0].ToString();
            }

            return null; // or an appropriate default value
        }
    }
}
