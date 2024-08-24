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

namespace QLDuLieuNoiBo.PhanHe2.TruongDonVi
{
    public partial class Home_TruongDonVi : Form
    {
        string id = "NV002";
        public Home_TruongDonVi(string _id)
        {
            InitializeComponent();
            id = _id;
        }
        private void Home_TruongDonVi_Load(object sender, EventArgs e)
        {
            comboBox3.SelectedIndex = 2;
            comboBox1.SelectedIndex = 2;
            DataTable info = DataProvider.Instance.ExecuteQueryOracle
                ("select * from ad.UV_CS1_1_XEMDULIEUCHINHMINH where manv = '" + id + "'");
            textBox4.Text = info.Rows[0][0].ToString();
            textBox3.Text = info.Rows[0][1].ToString();
            textBox5.Text = info.Rows[0][2].ToString();
            textBox6.Text = ((DateTime)info.Rows[0][3]).ToShortDateString();
            textBox7.Text = info.Rows[0][4].ToString();
            textBox1.Text = info.Rows[0][5].ToString();
            textBox2.Text = info.Rows[0][7].ToString();
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.SinhVien");
            dataGridView2.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.Hocphan");
            dataGridView3.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.KHMO");
            dataGridView4.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.UV_CS4_4_2_XEMPHANCONGTHUOCDONVI");
            dataGridView6.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.DangKy");
            dataGridView5.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.DonVI");
            dataGridView7.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.UV_CS4_4_1_SUADULIEUBANGPHANCONG");
            dataGridView8.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.UV_CS2_2_PHANCONGGIANGVIEN");
        }

        private void tabPage8_Click(object sender, EventArgs e)
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

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView4.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView4.Rows[rowId];
            textBox37.Text = row.Cells[0].Value.ToString();
            textBox36.Text = row.Cells[1].Value.ToString();
            textBox35.Text = row.Cells[2].Value.ToString();
            textBox48.Text = row.Cells[3].Value.ToString();
            textBox49.Text = row.Cells[4].Value.ToString();
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

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView6.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView6.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView6.Rows[rowId];
            textBox9.Text = row.Cells[0].Value.ToString();
            textBox61.Text = row.Cells[1].Value.ToString();
            textBox10.Text = row.Cells[2].Value.ToString();
            textBox8.Text = row.Cells[3].Value.ToString();
            textBox11.Text = row.Cells[4].Value.ToString();
            textBox12.Text = row.Cells[5].Value.ToString();
            textBox13.Text = row.Cells[6].Value.ToString();
            textBox15.Text = row.Cells[7].Value.ToString();
            textBox14.Text = row.Cells[8].Value.ToString();
            textBox16.Text = row.Cells[9].Value.ToString();
        }

        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView7.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView7.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView7.Rows[rowId];
            textBox55.Text = row.Cells[1].Value.ToString();
            textBox54.Text = row.Cells[0].Value.ToString();
            textBox53.Text = row.Cells[2].Value.ToString();
            textBox52.Text = row.Cells[3].Value.ToString();
            textBox51.Text = row.Cells[4].Value.ToString();
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

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            dataGridView6.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.DangKy where masv like '%" + guna2TextBox6.Text + "%'");
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        { 
            string hk = comboBox3.SelectedItem.ToString();
            if (hk == "Tất cả") hk = "";
            dataGridView4.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.UV_CS4_4_2_XEMPHANCONGTHUOCDONVI pc" +
                                                                                " where pc.mahp like '%" + textBox39.Text + "%' and pc.magv like '%" + textBox40.Text + "%' and pc.hk like '%" + hk + "%' ");
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            string hk = comboBox1.SelectedItem.ToString();
            if (hk == "Tất cả") hk = "";
            dataGridView7.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.UV_CS4_4_1_SUADULIEUBANGPHANCONG pc" +
                                                                                " where pc.mahp like '%" + textBox38.Text + "%' and pc.magv like '%" + textBox27.Text + "%' and pc.hk like '%" + hk + "%' ");
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            try
            {
                int i = DataProvider.Instance.ExecuteNonQueryOracle
                    ("insert into ad.UV_CS4_4_1_SUADULIEUBANGPHANCONG(magv, mahp, hk, nam, mact) values('" + textBox54.Text + "', '" + textBox55.Text + "', '" + textBox53.Text + "', " + textBox52.Text + ", '" + textBox51.Text + "')");
                if (i == 1)
                {
                    MessageBox.Show("Thêm thành công");
                    dataGridView7.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.UV_CS4_4_1_SUADULIEUBANGPHANCONG");
                    return;
                }
                else MessageBox.Show("Thêm không thành công");
            }
            catch
            {
                MessageBox.Show("Nhập đúng thông tin");
            }
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            try
            {

                int i = DataProvider.Instance.ExecuteNonQueryOracle("update ad.UV_CS4_4_1_SUADULIEUBANGPHANCONG set magv = '" + textBox50.Text + "' where mahp = '" + textBox55.Text + "' and hk = '" + textBox53.Text + "' and nam = " + textBox52.Text + " and mact = '" + textBox51.Text + "' and magv = '" + textBox54.Text + "'");
                if (i == 1)
                {
                    MessageBox.Show("Cập nhật thành công");
                    dataGridView7.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.UV_CS4_4_1_SUADULIEUBANGPHANCONG");
                    //DataProvider.Instance.ExecuteRunOracle("commit");
                    return;
                }
                else MessageBox.Show("Cập nhật không thành công");
            }
            catch
            {
                MessageBox.Show("Phân công đã được đăng ký");
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            try
            {
                int i = DataProvider.Instance.ExecuteNonQueryOracle("delete ad.UV_CS4_4_1_SUADULIEUBANGPHANCONG where magv = '" + textBox54.Text + "' and mahp = '" + textBox55.Text + "' and hk = '" + textBox53.Text + "' and nam = " + textBox52.Text + " and mact = '" + textBox51.Text + "'");
                if (i == 1)
                {
                    MessageBox.Show("Xóa thành công");
                    dataGridView7.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.UV_CS4_4_1_SUADULIEUBANGPHANCONG");
                    return;
                }
                else MessageBox.Show("Xóa không thành công");
            }
            catch
            {
                MessageBox.Show("Xóa đã được đăng ký");
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            this.Close();
            DataProvider.Instance.changeLogin("ad", "ad");

        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            double diemth = Convert.ToDouble(textBox13.Text);
            double diemqt = Convert.ToDouble(textBox15.Text);
            double diemck = Convert.ToDouble(textBox14.Text);
            double diemtk = diemth * 0.3 + diemqt * 0.2 + diemck * 0.5;
            diemtk = Math.Round(diemtk, 1);
            int i = DataProvider.Instance.ExecuteNonQueryOracle("update ad.Dangky " +
                                                                " set diemth = " + textBox13.Text +
                                                                ", diemqt = " + textBox15.Text +
                                                                ", diemck = " + textBox14.Text +
                                                                ", diemtk = " + diemtk.ToString() +
                                                                " where masv = '" + textBox9.Text +
                                                                "' and mahp = '" + textBox10.Text +
                                                                "' and nam = " + textBox11.Text +
                                                                " and hk = '" + textBox8.Text +
                                                                "' and magv = '" + textBox61.Text + "'");


            if (i == 1)
            {
                textBox16.Text = diemtk.ToString();
                MessageBox.Show("Cập nhật thành công: \n" +
                    " - Điểm thực hành: " + textBox13.Text + "\n" +
                    " - Điểm quá trình: " + textBox15.Text + "\n" +
                    " - Điểm cuối kỳ: " + textBox14.Text + "\n" +
                    " - Điểm tổng kết: " + diemtk.ToString() + "\n");
                dataGridView6.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.DangKy");

            }
            else MessageBox.Show("Cập nhật không thành công!!!");
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            try
            {
                DataProvider.Instance.changeLogin("TRUONGBOMON1_OLS", "TBM1");
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
