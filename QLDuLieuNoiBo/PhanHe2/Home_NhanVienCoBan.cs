using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDuLieuNoiBo.PhanHe2
{
    public partial class Home_NhanVienCoBan : Form
    {
        string id = "NV008";
        public Home_NhanVienCoBan(string _id)
        {
            InitializeComponent();
            id = _id;
            DataTable info = DataProvider.Instance.ExecuteQueryOracle
                ("select * from ad.UV_CS1_1_XEMDULIEUCHINHMINH");
            textBox4.Text = info.Rows[0][0].ToString();
            textBox3.Text = info.Rows[0][1].ToString();
            textBox5.Text = info.Rows[0][2].ToString();
            textBox6.Text = ((DateTime)info.Rows[0][3]).ToShortDateString();
            textBox7.Text = info.Rows[0][4].ToString();
            textBox1.Text = info.Rows[0][5].ToString();
            textBox2.Text = info.Rows[0][7].ToString();
            dataGridView5.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.donvi");
            dataGridView3.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.khmo");
            dataGridView2.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.Hocphan");
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.SinhVien");
        }

        private void Home_NhanVienCoBan_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView1.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView1.Rows[rowId];
            textBox17.Text = row.Cells[0].Value.ToString();
            textBox18.Text = row.Cells[1].Value.ToString();
            textBox19.Text = row.Cells[2].Value.ToString();
            textBox20.Text = ((DateTime)row.Cells[3].Value).ToShortDateString();
            textBox21.Text = row.Cells[4].Value.ToString();
            textBox22.Text = row.Cells[5].Value.ToString();
            textBox23.Text = row.Cells[6].Value.ToString();
            textBox24.Text = row.Cells[7].Value.ToString();
            textBox25.Text = row.Cells[8].Value.ToString();
            textBox26.Text = row.Cells[9].Value.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView2.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView2.Rows[rowId];
            textBox30.Text = row.Cells[0].Value.ToString();
            textBox29.Text = row.Cells[1].Value.ToString();
            textBox28.Text = row.Cells[2].Value.ToString();
            textBox41.Text = row.Cells[3].Value.ToString();
            textBox42.Text = row.Cells[4].Value.ToString();
            textBox43.Text = row.Cells[5].Value.ToString();
            textBox44.Text = row.Cells[6].Value.ToString();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView3.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView3.Rows[rowId];
            textBox34.Text = row.Cells[0].Value.ToString();
            textBox33.Text = row.Cells[1].Value.ToString();
            textBox32.Text = row.Cells[2].Value.ToString();
            textBox31.Text = row.Cells[3].Value.ToString();
            
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView5.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView5.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView5.Rows[rowId];
            textBox47.Text = row.Cells[0].Value.ToString();
            textBox46.Text = row.Cells[1].Value.ToString();
            textBox45.Text = row.Cells[2].Value.ToString();
        }

        private void textBox42_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int i = DataProvider.Instance.ExecuteNonQueryOracle("update ad.UV_CS1_1_XEMDULIEUCHINHMINH set dt = '" + textBox1.Text + "' where manv = '" + id + "'");
            if (i == 1) MessageBox.Show("Cập nhật số điện thoại: " + textBox1.Text);
            else MessageBox.Show("Cập nhật số điện thoại không thành công!!!");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.SinhVien where hoten like N'%" + guna2TextBox1.Text + "%'");
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.Hocphan where tenhp like N'%" + guna2TextBox2.Text + "%'");
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.KHMO where mahp like '%" + guna2TextBox3.Text + "%'");
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            dataGridView5.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.DonVI where tendv like N'%" + guna2TextBox5.Text + "%'");
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {

            this.Close();
            DataProvider.Instance.changeLogin("ad", "ad");
        }
    }
}
