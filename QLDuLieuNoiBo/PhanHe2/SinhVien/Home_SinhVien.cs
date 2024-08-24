using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDuLieuNoiBo.PhanHe2.SinhVien
{
    public partial class Home_SinhVien : Form
    {
        string id;
        public Home_SinhVien(string _id)
        {
            

            InitializeComponent();
            this.id = _id;
            DataTable info = DataProvider.Instance.ExecuteQueryOracle
                ("select * from ad.SinhVien");
            textBox4.Text = info.Rows[0][0].ToString();
            textBox3.Text = info.Rows[0][1].ToString();
            textBox5.Text = info.Rows[0][2].ToString();
            textBox6.Text = ((DateTime)info.Rows[0][3]).ToShortDateString();
            textBox7.Text = info.Rows[0][6].ToString();
            textBox1.Text = info.Rows[0][5].ToString();
            textBox2.Text = info.Rows[0][4].ToString();
            textBox38.Text = info.Rows[0][7].ToString();
            textBox39.Text = info.Rows[0][8].ToString();
            textBox40.Text = info.Rows[0][9].ToString();
            dataGridView2.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.HocPhan");
            dataGridView3.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.khmo");
            dataGridView6.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.dangky where masv = '" + id + "'");
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Form dangKyHocPhan = new GiaoVu.DangKyHocPhan(this.id);
            dangKyHocPhan.Show();
        }

        private void Home_SinhVien_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void label42_Click(object sender, EventArgs e)
        {

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

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView6.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView6.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView6.Rows[rowId];
            textBox9.Text = row.Cells[0].Value.ToString();
            textBox10.Text = row.Cells[2].Value.ToString();
            textBox8.Text = row.Cells[3].Value.ToString();
            textBox11.Text = row.Cells[4].Value.ToString();
            textBox12.Text = row.Cells[5].Value.ToString();
            textBox13.Text = row.Cells[6].Value.ToString();
            textBox14.Text = row.Cells[7].Value.ToString();
            textBox15.Text = row.Cells[8].Value.ToString();
            textBox16.Text = row.Cells[9].Value.ToString();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            dataGridView6.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.dangky where masv = '" + id + "' and nam = 2024 and mahp like '%" + guna2TextBox6.Text + "%'");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int i = DataProvider.Instance.ExecuteNonQueryOracle("update ad.SinhVien " +
                                                                "set dchi = N'" + textBox2.Text + 
                                                                "', dt = '" + textBox1.Text + 
                                                                "' where masv = '" + textBox4.Text + "'");
            if (i == 1)
                MessageBox.Show("Cập nhật thành công:\n - Địa chỉ: " + textBox2.Text + "\n - Số điện thoại: " + textBox1.Text);
            else MessageBox.Show("Cập nhật không thành công");
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.HocPhan where tenhp like N'%"+ guna2TextBox2.Text + "%'");
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.khmo where mahp like '%" + guna2TextBox3.Text + "%'");
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox8.Text != Const.Instance.hk || textBox11.Text != Const.Instance.nam)
                {
                    MessageBox.Show("Không thể xóa");
                    return;
                }
                int i = DataProvider.Instance.ExecuteNonQueryOracle
                    ("delete from ad.DangKy where masv = '" + textBox9.Text +
                    "' and mahp = '" + textBox10.Text + "' and hk = '" + textBox8.Text + "' and nam = " + textBox11.Text + " and mact = '" + textBox12.Text + "'");
                if(i == 1)
                {
                    MessageBox.Show("Xóa thành công!!!");
                    dataGridView6.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.dangky where masv = '" + id + "' and nam = 2024 and mahp like '%" + guna2TextBox6.Text + "%'");
                }
                else MessageBox.Show("Xóa không thành công!!!");
                
            }
            catch 
            {
                MessageBox.Show("Chọn học phần cần xóa");
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {

            this.Close();
            DataProvider.Instance.changeLogin("ad", "ad");
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            try
            {
                DataProvider.Instance.changeLogin("SINHVIEN_OLS", "SV");
                Form thongBao = new ThongBao();
                thongBao.Show();
            }
            catch
            {
                MessageBox.Show("Không có thông báo");
            }
        }
    }
}
