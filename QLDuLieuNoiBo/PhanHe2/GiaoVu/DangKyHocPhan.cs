using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDuLieuNoiBo.PhanHe2.GiaoVu
{
    public partial class DangKyHocPhan : Form
    {
        string id = "";
        public DangKyHocPhan(string _id)
        {
            InitializeComponent();
            this.id = _id;
            
                textBox47.Text = id;
                textBox47.ReadOnly = true;
                guna2Button1.Visible = false;
            
        }
        void LoadData()
        {
            
                dataGridView1.DataSource = DataProvider.Instance.ExecuteQueryOracle("select mahp, hk, nam, mact from ad.khmo where nam = " + Const.Instance.nam + " and hk = '" + Const.Instance.hk + "' except select mahp, hk, nam, mact from ad.DangKy where masv = '" + id + "'");
        }
        private void DangKyHocPhan_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView1.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView1.Rows[rowId];
            textBox45.Text = row.Cells[0].Value.ToString();
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            textBox3.Text = row.Cells[3].Value.ToString();
        }
        
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.id = textBox47.Text;
            LoadData();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable findGV = DataProvider.Instance.ExecuteQueryOracle
                ("select magv from ad.Phancong where mahp = '" + textBox45.Text + "' and hk = '" + textBox1.Text + "' and nam = " + textBox2.Text + " and mact = '" + textBox3.Text + "'");
                if(findGV.Rows.Count == 0)
                {
                    MessageBox.Show("Học phần chưa được phân công");
                    return;
                }
                string magv = findGV.Rows[0][0].ToString();
                int i = DataProvider.Instance.ExecuteNonQueryOracle("insert into ad.DangKy(magv, masv, mahp, nam, hk, mact) " +
                    "values('" + magv + "', '" + textBox47.Text + "', '" + textBox45.Text + "', " + textBox2.Text + ", '" + textBox1.Text + "', '" + textBox3.Text + "')");
                if (i == 1)
                {
                    MessageBox.Show("Thêm thành công");
                    LoadData();
                }
                else MessageBox.Show("Thêm không thành công!!!");
            }
            catch
            {
                MessageBox.Show("Chưa thể đăng ký");
            }
        }
    }
}
