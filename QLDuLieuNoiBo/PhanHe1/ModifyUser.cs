using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.HtmlRenderer.Adapters.RGraphicsPath;

namespace QLDuLieuNoiBo.PhanHe1
{
    public partial class ModifyUser : Form
    {
        private string username;
        private string curAddRole = "";
        private string curRole = "";
        private string curAddTable = "";
        private string curTable = "";
        private string privilege = "";
        public ModifyUser(string username)
        {
            InitializeComponent();
            this.username = username;
            guna2TextBox1.Text = username;
            LoadRoleAdd();
            LoadRole();
            LoadTable();
            LoadTableAdd();
            string[] itemsArray = { "SELECT", "INSERT", "UPDATE", "DELETE"};
            comboBox1.Items.AddRange(itemsArray);
            comboBox1.SelectedIndex = 0;
        }
        void LoadRoleAdd()
        {
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQueryOracle
                ("SELECT role FROM dba_roles WHERE role NOT IN (SELECT granted_role FROM dba_role_privs WHERE grantee = '" + this.username + "')");
        }
        void LoadRole()
        {
            dataGridView2.DataSource = DataProvider.Instance.ExecuteQueryOracle
                ("SELECT granted_role, admin_option FROM dba_role_privs WHERE grantee = '" + this.username + "'");
        }
        void LoadTableAdd()
        {
            dataGridView4.DataSource = DataProvider.Instance.ExecuteQueryOracle
                ("SELECT TABLE_NAME FROM DBA_tables WHERE OWNER = 'AD'");
        }
        void LoadTable()
        {
            dataGridView3.DataSource = DataProvider.Instance.ExecuteQueryOracle
                ($"SELECT TABLE_Name, privilege, grantable FROM USER_TAB_PRIVS WHERE GRANTEE = '{this.username}' and owner = 'AD'"); ;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if(guna2TextBox5.Text == "")
            {
                MessageBox.Show("Chọn bảng");
                return;
            }
            Form columnPermission = new ColumnPermission(this.username, guna2TextBox5.Text, false);
            columnPermission.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModifyUser_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox2.Text == "") return;
            DataProvider.Instance.TrueSession();
            DataProvider.Instance.ExecuteRunOracle($"alter user {this.username} identified by {guna2TextBox2.Text}");
            MessageBox.Show("Mật khẩu mới: " + guna2TextBox2.Text);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if(curAddRole == "")
            {
                MessageBox.Show("Chọn Role");
                return;
            }
            string addRole = $"grant {curAddRole} to " + this.username;
            if (checkBox1.Checked == true) addRole += " WITH ADMIN OPTION";
            DataProvider.Instance.ExecuteRunOracle(addRole);
            LoadRoleAdd();
            LoadRole();
            guna2TextBox3.Text = "";
            this.curAddRole = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView1.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView1.Rows[rowId];
            this.curAddRole = row.Cells[0].Value.ToString();
            guna2TextBox3.Text = this.curAddRole;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView2.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView2.Rows[rowId];
            this.curRole = row.Cells[0].Value.ToString();
            guna2TextBox4.Text = this.curRole;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if(curRole == "")
            {
                MessageBox.Show("Chọn role cần thu hồi");
                return;
            }
            DataProvider.Instance.ExecuteRunOracle($"REVOKE {curRole} FROM " + this.username);
            LoadRoleAdd();
            LoadRole();
            guna2TextBox4.Text = "";
            this.curRole = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView4.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView4.Rows[rowId];
            this.curAddTable = row.Cells[0].Value.ToString();
            guna2TextBox5.Text = this.curAddTable;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView3.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView3.Rows[rowId];
            this.curTable = row.Cells[0].Value.ToString();
            this.privilege = row.Cells[1].Value.ToString();
            guna2TextBox6.Text = this.curTable;
            guna2TextBox7.Text = this.privilege;   
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (curAddTable == "")
            {
                MessageBox.Show("Chọn table");
                return;
            }
            string addRole = $"grant {comboBox1.Text} on ad.{this.curAddTable} to " + this.username;
            if (checkBox2.Checked == true) addRole += " WITH GRANT OPTION";
            DataProvider.Instance.ExecuteRunOracle(addRole);
            LoadTableAdd();
            LoadTable();
            guna2TextBox5.Text = "";
            this.curAddTable = "";
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (curTable == "")
            {
                MessageBox.Show("Chọn table cần thu hồi");
                return;
            }
            DataProvider.Instance.ExecuteRunOracle($"REVOKE {this.privilege} on ad.{this.curTable} FROM " + this.username);
            LoadTableAdd();
            LoadTable();
            guna2TextBox6.Text = "";
            guna2TextBox7.Text = "";
            this.privilege = "";
            this.curTable = "";
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
