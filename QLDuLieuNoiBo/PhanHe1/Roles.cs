using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDuLieuNoiBo.PhanHe1
{
    public partial class Roles : Form
    {
        string curRole = "";
        public Roles()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form createRole = new CreateRole();
            createRole.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if(curRole == "")
            {
                MessageBox.Show("Chọn role cần chỉnh");
                return;
            }
            Form modifyRole = new ModifyRole(curRole);
            modifyRole.Show();
        }
        void LoadAllRoles()
        {
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQueryOracle("SELECT * FROM DBA_ROLES");
        }
        private void Roles_Load(object sender, EventArgs e)
        {
            LoadAllRoles(); 
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (this.curRole == "") return;
            DataProvider.Instance.TrueSession();
            DataProvider.Instance.ExecuteRunOracle("drop role " + this.curRole);
            LoadAllRoles();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView1.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView1.Rows[rowId];
            this.curRole = row.Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
