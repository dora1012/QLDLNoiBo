using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDuLieuNoiBo.PhanHe2.TruongKhoa
{
    public partial class Home_TruongKhoa : Form
    {
        string id = "NV001";
        public Home_TruongKhoa(string _id)
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
            dataGridView7.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.NhanSu");
            dataGridView6.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.DangKy");
            dataGridView5.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.DonVi");
            dataGridView4.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.PhanCong");
            dataGridView3.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.KHMO");
            dataGridView2.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.HocPhan");
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.SinhVien");
            comboBox4.DataSource = DataProvider.Instance.ExecuteQueryOracle("select madv, tendv from ad.DonVi");
            comboBox4.DisplayMember = "tendv";
            comboBox4.ValueMember = "madv";
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            if(textBox37.Text == "")
            {
                MessageBox.Show("Chọn phân công!!!");
                return;
            }
            DataTable info1 = DataProvider.Instance.ExecuteQueryOracle
                ("select * from ad.UV_CS5_5_2_THEMXOASUADULIEUBANGPHANCONG where mahp = '" + textBox37.Text + "' and magv = '" + textBox36.Text + "' and hk = '" + textBox35.Text + "' and nam = " + textBox48.Text + " and mact = '" + textBox49.Text + "'");
            if (info1.Rows.Count == 0)
            {
                MessageBox.Show("Học phần không thuộc Văn phòng khoa");
                return;
            }
            DataTable info = DataProvider.Instance.ExecuteQueryOracle
                ("select * from ad.DangKy where mahp = '" + textBox37.Text + "' and magv = '" + textBox36.Text + "' and hk = '" + textBox35.Text + "' and nam = " + textBox48.Text + " and mact = '" + textBox49.Text + "'");
            if(info.Rows.Count > 0)
            {
                MessageBox.Show("Đã được đăng ký");
                return;
            }
            Form suaPhanCong = new SuaPhanCong(textBox37.Text, textBox36.Text, textBox35.Text, textBox48.Text, textBox49.Text);
            suaPhanCong.Show();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            Form themPhanCong = new ThemPhanCong();
            themPhanCong.Show();
        }

        private void Home_TruongKhoa_Load(object sender, EventArgs e)
        {

        }

        private void tabPage9_Click(object sender, EventArgs e)
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
            textBox27.Text = row.Cells[3].Value.ToString();
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
            textBox37.Text = row.Cells[1].Value.ToString();
            textBox36.Text = row.Cells[0].Value.ToString();
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
            textBox38.Text = row.Cells[1].Value.ToString();
            textBox10.Text = row.Cells[2].Value.ToString();
            textBox8.Text = row.Cells[3].Value.ToString();
            textBox11.Text = row.Cells[4].Value.ToString();
            textBox12.Text = row.Cells[5].Value.ToString();
            textBox13.Text = row.Cells[6].Value.ToString();
            textBox15.Text = row.Cells[7].Value.ToString();
            textBox14.Text = row.Cells[8].Value.ToString();
            textBox16.Text = row.Cells[9].Value.ToString();
        }

        private void label57_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView7.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView7.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView7.Rows[rowId];
            textBox56.Text = row.Cells[0].Value.ToString();
            textBox55.Text = row.Cells[1].Value.ToString();
            comboBox2.Text = row.Cells[2].Value.ToString();
            textBox53.Text = ((DateTime)row.Cells[3].Value).ToShortDateString();
            textBox52.Text = row.Cells[4].Value.ToString();
            textBox51.Text = row.Cells[5].Value.ToString();
            comboBox4.SelectedValue = row.Cells[7].Value.ToString();
            comboBox3.Text = row.Cells[6].Value.ToString();
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int i = DataProvider.Instance.ExecuteNonQueryOracle("update ad.UV_CS1_1_XEMDULIEUCHINHMINH set dt = '" + textBox1.Text + "' where manv = '" + id + "'");
            if (i == 1) MessageBox.Show("Cập nhật số điện thoại: " + textBox1.Text);
            else MessageBox.Show("Cập nhật số điện thoại không thành công!!!");
        }

        private void textBox49_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            try
            {
                int i = DataProvider.Instance.ExecuteNonQueryOracle("update ad.NhanSu set " +
                    "hoten = N'" + textBox55.Text +
                    "', phai = N'" + comboBox2.Text +
                    "', ngsinh = '" + Convert.ToDateTime(textBox53.Text).ToString("dd/MMM/yyyy") +
                    "', phucap = " + textBox52.Text +
                    ", dt = " + textBox51.Text +
                    ", madv = '" + comboBox4.SelectedValue.ToString() +
                    "', vaitro = N'" + comboBox3.Text +
                    "' where manv = '" + textBox56.Text + "'");
                if (i == 1)
                {
                    MessageBox.Show("Cập nhật thành công");
                    dataGridView7.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.NhanSu");

                }
                else MessageBox.Show("Cập nhật không thành công");
            }
            catch 
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            try
            {
                int i = DataProvider.Instance.ExecuteNonQueryOracle("delete from ad.NhanSu where manv = '" + textBox56.Text + "'");
                if (i == 1)
                {
                    MessageBox.Show("Xóa thành công");
                    dataGridView7.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.NhanSu");

                }
                else MessageBox.Show("Xóa không thành công");
            }
            catch
            {
                MessageBox.Show("Không thể xóa");
            }
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            try
            {
                int i = DataProvider.Instance.ExecuteNonQueryOracle("insert into ad.NhanSu(hoten, phai, ngsinh, phucap, dt, madv, vaitro, manv) values(" +
                    "N'" + textBox55.Text +
                    "',  N'" + comboBox2.Text +
                    "', '" + Convert.ToDateTime(textBox53.Text).ToString("dd/MMM/yyyy") +
                    "', " + textBox52.Text +
                    ", " + textBox51.Text +
                    ", '" + comboBox4.SelectedValue.ToString() +
                    "', N'" + comboBox3.Text +
                    "', '" + textBox56.Text + "')");
                if (i == 1)
                {
                    MessageBox.Show("Thêm thành công");
                    dataGridView7.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.NhanSu");

                }
                else MessageBox.Show("Thêm không thành công");
            }
            catch
            {
                MessageBox.Show("Trùng mã nhân viên");
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {

            this.Close();
            DataProvider.Instance.changeLogin("ad", "ad");
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.UV_CS5_5_2_THEMXOASUADULIEUBANGPHANCONG where mahp like '%" + guna2TextBox4.Text + "%'");
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            dataGridView7.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.NhanSu where hoten like '%" + guna2TextBox7.Text + "%'");
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            if (textBox37.Text == "")
            {
                MessageBox.Show("Chọn phân công!!!");
                return;
            }
            DataTable info1 = DataProvider.Instance.ExecuteQueryOracle
                ("select * from ad.UV_CS5_5_2_THEMXOASUADULIEUBANGPHANCONG where mahp = '" + textBox37.Text + "' and magv = '" + textBox36.Text + "' and hk = '" + textBox35.Text + "' and nam = " + textBox48.Text + " and mact = '" + textBox49.Text + "'");
            if (info1.Rows.Count == 0)
            {
                MessageBox.Show("Học phần không thuộc Văn phòng khoa");
                return;
            }
            DataTable info = DataProvider.Instance.ExecuteQueryOracle
                ("select * from ad.DangKy where mahp = '" + textBox37.Text + "' and magv = '" + textBox36.Text + "' and hk = '" + textBox35.Text + "' and nam = " + textBox48.Text + " and mact = '" + textBox49.Text + "'");
            if (info.Rows.Count > 0)
            {
                MessageBox.Show("Đã được đăng ký");
                return;
            }

            try
            {
                int i = DataProvider.Instance.ExecuteNonQueryOracle("delete from ad.UV_CS5_5_2_THEMXOASUADULIEUBANGPHANCONG where mahp = '" + textBox37.Text + "' and magv = '" + textBox36.Text + "' and hk = '" + textBox35.Text + "' and nam = " + textBox48.Text + " and mact = '" + textBox49.Text + "'");
                if (i == 1)
                {
                    MessageBox.Show("Xóa thành công");
                    dataGridView4.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.PhanCong");
                    return;
                }
                else
                {
                    MessageBox.Show("Không thành công");
                }
            }
            catch
            {
                MessageBox.Show("Không thể chọn");
            }
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
                                                                "' and magv = '" + textBox38.Text + "'");

            
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

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            dataGridView6.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.Dangky where mahp like N'%" + guna2TextBox6.Text + "%'");

        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            try
            {
                DataProvider.Instance.changeLogin("TRUONGKHOA_OLS", "TK");
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
