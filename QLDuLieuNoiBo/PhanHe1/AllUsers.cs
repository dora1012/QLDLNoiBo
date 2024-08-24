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
    public partial class AllUsers : Form
    {
        string curUsername = "";
        public AllUsers()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form createUser = new CreateUser();
            createUser.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if(this.curUsername == "")
            {
                MessageBox.Show("Chọn user");
                return;
            }
            Form modifyUser = new ModifyUser(this.curUsername);
            modifyUser.Show();
        }

        private void AllUsers_Load(object sender, EventArgs e)
        {
            LoadAllUser();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView1.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView1.Rows[rowId];
            this.curUsername = row.Cells[0].Value.ToString();
        }
        void LoadAllUser()
        {
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from all_users WHERE created >= TO_DATE('04-APR-2024', 'DD-MON-YYYY')");
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (this.curUsername == "") return;
            DataProvider.Instance.TrueSession();
            DataProvider.Instance.ExecuteRunOracle("drop user " + this.curUsername);
            LoadAllUser();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
