using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Xml.Linq;

namespace QLDuLieuNoiBo.PhanHe1
{
    public partial class ColumnPermission : Form
    {
        bool isRole = false;
        private string roleOrUser = "";
        private List<string> tempList = new List<string>();
        
        public ColumnPermission(string roleOrUser, string table, bool isRole)
        {
            InitializeComponent();
            this.roleOrUser = roleOrUser;
            guna2TextBox2.Text = table;
            LoadColumns();
            LoadListView();
            LoadColumn();
            LoadColumnAdd();
            if (isRole)
            {
                checkBox1.Visible = false;
                checkBox2.Visible = false;
            }
        }
        void LoadColumns()
        {
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQueryOracle
                ("select COLUMN_NAME from ALL_TAB_COLS WHERE OWNER = 'AD' AND TABLE_NAME = '" + guna2TextBox2.Text + "'");
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void LoadColumnAdd()
        {
            dataGridView4.DataSource = DataProvider.Instance.ExecuteQueryOracle
                ($"select column_name from all_tab_cols where owner = 'AD' and table_name = '{guna2TextBox2.Text}' and column_name not in " +
                $"(select column_name from dba_col_privs  where grantee = '{this.roleOrUser}')");
        }
        void LoadColumn()
        {
            dataGridView3.DataSource = DataProvider.Instance.ExecuteQueryOracle
                ($"select column_name from dba_col_privs  where grantee = '{this.roleOrUser}' and owner = 'AD' and table_name = '{guna2TextBox2.Text}'");
        }
        private void ColumnPermission_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView1.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView1.Rows[rowId];
            string add = row.Cells[0].Value.ToString();
            if (this.tempList.Contains(add)) return;
            this.tempList.Add(add);
            textBox1.Text = string.Join("\r\n", tempList);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            this.tempList = new List<string> ();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        void LoadListView()
        {
            dataGridView2.DataSource = DataProvider.Instance.ExecuteQueryOracle
                ($"SELECT table_name FROM dba_tab_privs WHERE grantee = '{roleOrUser}' AND privilege = 'SELECT' and type = 'VIEW' and table_name in" 
                 + $"(select name from dba_dependencies d where d.referenced_owner = 'AD' AND d.referenced_name = '{guna2TextBox2.Text}' and type = 'VIEW')");
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || textBox1.Text == "") return;
            
            DataProvider.Instance.ExecuteRunOracle($"CREATE OR REPLACE VIEW AD.{guna2TextBox1.Text} AS SELECT {string.Join(", ", this.tempList)} FROM AD." + guna2TextBox2.Text);
            if(checkBox2.Checked == false)
                DataProvider.Instance.ExecuteRunOracle($"grant select on AD.{guna2TextBox1.Text} to " + this.roleOrUser);
            else
                DataProvider.Instance.ExecuteRunOracle($"grant select on AD.{guna2TextBox1.Text} to " + this.roleOrUser + " with grant option");
                LoadListView();
            textBox1.Text = "";
            this.tempList = new List<string>();
            guna2TextBox1.Text = "";
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView2.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView2.Rows[rowId];
            string add = row.Cells[0].Value.ToString();
            guna2TextBox3.Text = add;

            dataGridView5.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad." + guna2TextBox3.Text);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox3.Text == "") return;
            DataProvider.Instance.ExecuteRunOracle($"REVOKE SELECT ON AD.{guna2TextBox3.Text} from " + this.roleOrUser);
            DataProvider.Instance.ExecuteRunOracle("drop view AD." + guna2TextBox3.Text);
            LoadListView();
            guna2TextBox3.Text = "";
            dataGridView5.DataSource = null;
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView4.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView4.Rows[rowId];
            guna2TextBox4.Text = row.Cells[0].Value.ToString();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView3.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView3.Rows[rowId];
            guna2TextBox5.Text = row.Cells[0].Value.ToString();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked == false)
                DataProvider.Instance.ExecuteRunOracle($"GRANT UPDATE({guna2TextBox4.Text}) ON AD.{guna2TextBox2.Text} TO " + this.roleOrUser);
            else
                DataProvider.Instance.ExecuteRunOracle($"GRANT UPDATE({guna2TextBox4.Text}) ON AD.{guna2TextBox2.Text} TO " + this.roleOrUser + " with grant option");
            guna2TextBox4.Text = "";
            LoadColumn();
            LoadColumnAdd();

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            DataProvider.Instance.ExecuteRunOracle($"REVOKE UPDATE ON AD.{guna2TextBox2.Text} FROM {this.roleOrUser}");
            guna2TextBox5.Text = "";
            LoadColumn();
            LoadColumnAdd();
        }
    }
}
