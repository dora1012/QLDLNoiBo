using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QLDuLieuNoiBo.PhanHe1
{
    public partial class ModifyRole : Form
    {
        private string curRole;
        public ModifyRole(string curRole)
        {
            InitializeComponent();
            
            this.curRole = curRole;
            guna2TextBox1.Text = curRole;
            LoadUserAdd();
            LoadUser();
            LoadTableAdd();
            LoadTable();
            LoadSystemPrivilege();
            LoadPrivilegeAdd();
            string[] itemsArray = { "SELECT", "INSERT", "UPDATE", "DELETE" };
            comboBox1.Items.AddRange(itemsArray);
            comboBox1.SelectedIndex = 0;
        }
        void LoadUserAdd()
        {
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQueryOracle
                ("SELECT username FROM dba_users WHERE created >= TO_DATE('04-APR-2024', 'DD-MON-YYYY') and username NOT IN(SELECT grantee FROM dba_role_privs WHERE granted_role = '" + this.curRole + "')");
        }
        void LoadUser()
        {
            dataGridView2.DataSource = DataProvider.Instance.ExecuteQueryOracle
                ("SELECT grantee, admin_option FROM dba_role_privs WHERE granted_role = '" + this.curRole + "'");
        }
        void LoadTableAdd()
        {
            dataGridView4.DataSource = DataProvider.Instance.ExecuteQueryOracle
                ("SELECT TABLE_NAME FROM DBA_tables WHERE OWNER = 'AD'");
        }
        void LoadTable()
        {
            dataGridView3.DataSource = DataProvider.Instance.ExecuteQueryOracle
                ($"SELECT TABLE_Name, privilege FROM DBA_TAB_PRIVS WHERE GRANTEE = '{this.curRole}' and owner = 'AD'"); ;
        }
        void LoadSystemPrivilege()
        {
            dataGridView6.DataSource = DataProvider.Instance.ExecuteQueryOracle
                ($"SELECT privilege FROM DBA_SYS_PRIVS");
        }

        void LoadPrivilegeAdd()
        {
            dataGridView5.DataSource = DataProvider.Instance.ExecuteQueryOracle
                ($"SELECT privilege, admin_option FROM DBA_SYS_PRIVS WHERE grantee = '" + this.curRole + "'");
        }
        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if(guna2TextBox2.Text == "")
            {
                MessageBox.Show("Chọn bảng");
                return;
            }
            Form columnPermission = new ColumnPermission(this.curRole, guna2TextBox2.Text, true);
            columnPermission.Show();
        }

        private void ModifyRole_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView1.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView1.Rows[rowId];
            guna2TextBox3.Text = row.Cells[0].Value.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView2.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView2.Rows[rowId];
            guna2TextBox4.Text = row.Cells[0].Value.ToString();
        }


        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (guna2TextBox3.Text == "")
            {
                MessageBox.Show("Chọn User");
                return;
            }
            string addRole = $"grant {this.curRole} to " + guna2TextBox3.Text;
            if (checkBox1.Checked == true) addRole += " WITH ADMIN OPTION";
            DataProvider.Instance.ExecuteRunOracle(addRole);
            LoadUserAdd();
            LoadUser();
            guna2TextBox3.Text = "";
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (guna2TextBox4.Text == "")
            {
                MessageBox.Show("Chọn user cần thu hồi");
                return;
            }
            DataProvider.Instance.ExecuteRunOracle($"REVOKE {this.curRole} FROM " + guna2TextBox4.Text);
            LoadUserAdd();
            LoadUser();
            guna2TextBox4.Text = "";
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView4.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView4.Rows[rowId];
            guna2TextBox2.Text = row.Cells[0].Value.ToString();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView3.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView3.Rows[rowId];
            guna2TextBox5.Text = row.Cells[0].Value.ToString();
            guna2TextBox6.Text = row.Cells[1].Value.ToString();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (guna2TextBox2.Text == "")
            {
                MessageBox.Show("Chọn table");
                return;
            }
            string addRole = $"grant {comboBox1.Text} on ad.{guna2TextBox2.Text} to " + this.curRole;
            DataProvider.Instance.ExecuteRunOracle(addRole);
            LoadTableAdd();
            LoadTable();
            guna2TextBox2.Text = "";
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (guna2TextBox5.Text == "")
            {
                MessageBox.Show("Chọn table cần thu hồi");
                return;
            }
            DataProvider.Instance.ExecuteRunOracle($"REVOKE {guna2TextBox6.Text} on ad.{guna2TextBox5.Text} FROM " + this.curRole);
            LoadTableAdd();
            LoadTable();
            guna2TextBox6.Text = "";
            guna2TextBox5.Text = "";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView5.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView6.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView5.Rows[rowId];
            guna2TextBox7.Text = row.Cells[0].Value.ToString();
        }
        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView6.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView6.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView6.Rows[rowId];
            guna2TextBox8.Text = row.Cells[0].Value.ToString();
        }
        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (guna2TextBox8.Text == "")
            {
                MessageBox.Show("Chọn quyền để gán");
                return;
            }
            string addPrivilege = $"grant {guna2TextBox8.Text} to " +  this.curRole;
            if (checkBox1.Checked == true) addPrivilege += " WITH ADMIN OPTION";
            DataProvider.Instance.ExecuteRunOracle(addPrivilege);
            LoadPrivilegeAdd();
            LoadSystemPrivilege();
            guna2TextBox8.Text = "";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox7.Text == "")
            {
                MessageBox.Show("Chọn quyền cần thu hồi");
                return;
            }
            DataProvider.Instance.ExecuteRunOracle($"REVOKE {guna2TextBox7.Text} FROM " + this.curRole);
            LoadPrivilegeAdd();
            LoadSystemPrivilege();
            guna2TextBox7.Text = "";
        }
    }
}
