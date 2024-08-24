using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDuLieuNoiBo.PhanHe2.GiaoVu
{
    public partial class Home_GiaoVu : Form
    {
        string id = "NV025";
        public Home_GiaoVu(string _id)
        {
            InitializeComponent();
            id = _id;
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
            dataGridView4.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.UV_CS3_3_1_XEMDULIEUTOANBOPHANCONG");
            dataGridView5.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.DonVI");
            dataGridView6.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.DangKy");

            DataTable dt = DataProvider.Instance.ExecuteQueryOracle("select mahp from ad.Hocphan");

            comboBox4.DataSource = dt;
            comboBox4.DisplayMember = "mahp";
            comboBox4.ValueMember = "mahp";

            comboBox6.DataSource = DataProvider.Instance.ExecuteQueryOracle("select madv from ad.donvi");
            comboBox6.ValueMember = "madv";
            comboBox6.DisplayMember = "madv";

            comboBox1.SelectedIndex = 3;

            comboBox7.DataSource = DataProvider.Instance.ExecuteQueryOracle("select madv from ad.donvi");
            comboBox7.ValueMember = "madv";
            comboBox7.DisplayMember = "madv";

            comboBox3.DataSource = DataProvider.Instance.ExecuteQueryOracle("select mahp from ad.HocPhan");
            comboBox3.ValueMember = "mahp";
            comboBox3.DisplayMember = "mahp";

            

            comboBox9.SelectedIndex = 3;
        }
        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            try
            {
                int i = DataProvider.Instance.ExecuteNonQueryOracle("insert into ad.SinhVien(masv, hoten, phai, ngsinh, dchi, dt, mact, manganh, sotctl, dtbtl) values('" + textBox17.Text + "', N'" + textBox18.Text + "', N'" + comboBox2.Text + "', '" + Convert.ToDateTime(textBox20.Text).ToString("dd/MMM/yyyy") + "', N'" + textBox21.Text + "', " + textBox22.Text + ", '" + comboBox5.Text + "', '" + comboBox6.Text + "', " + textBox25.Text + ", " + textBox26.Text + ")");
                if (i == 1)
                {
                    MessageBox.Show("Thêm thành công");
                    dataGridView1.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.SinhVien");
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
                int i = DataProvider.Instance.ExecuteNonQueryOracle("update ad.SinhVien set hoten = N'" + textBox18.Text + "', phai = N'" + comboBox2.Text + "', ngsinh = '" + Convert.ToDateTime(textBox20.Text).ToString("dd/MMM/yyyy") + "', dchi = N'" + textBox21.Text + "', dt = " + textBox22.Text + ", mact = '" + comboBox5.Text + "', manganh = '" + comboBox6.Text + "', sotctl = " + textBox25.Text + ", dtbtl = " + textBox26.Text + "where masv = '" + textBox17.Text + "'");
                if (i == 1)
                {
                    MessageBox.Show("Sửa thành công");
                    dataGridView1.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.SinhVien");
                }
                else MessageBox.Show("Sửa không thành công");
            }
            catch
            {
                MessageBox.Show("Nhập đúng thông tin");
            }
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            try
            {
                int i = DataProvider.Instance.ExecuteNonQueryOracle("update ad.hocphan set tenhp = N'" + textBox29.Text + "', sotc = " + textBox28.Text + ", stlt = " + textBox27.Text 
                    + ", stth = " + textBox42.Text + ", sosvtd = " + textBox43.Text + ", madv = '" + comboBox7.Text + "' where mahp = '" + textBox30.Text + "'");
                if (i == 1)
                {
                    MessageBox.Show("Cập nhật thành công");
                    dataGridView2.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.Hocphan");
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công");
                }
            }
            catch
            {
                MessageBox.Show("Nhập đúng thông tin");
            }
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            try
            {
                int i = DataProvider.Instance.ExecuteNonQueryOracle("insert into ad.hocphan(mahp, tenhp, sotc, stlt, stth, sosvtd, madv) " +
                    "values('" + textBox30.Text + "', N'" + textBox29.Text + "', " + textBox28.Text + ", " + textBox27.Text + ", " + textBox42.Text + ", " + textBox43.Text + ", '" + comboBox7.Text + "')");
                if(i == 1)
                {
                    MessageBox.Show("Thêm thành công");
                    dataGridView2.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.Hocphan");
                }else
                {
                    MessageBox.Show("Thêm không thành công");
                }
            }
            catch
            {
                MessageBox.Show("Nhập đúng thông tin");
            }
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {

            if(Convert.ToInt32(textBox32.Text) < Convert.ToInt32(Const.Instance.nam)) {
                MessageBox.Show("Chọn lại thời gian");
                return;
            }
            if (Convert.ToInt32(textBox32.Text[2]) < Convert.ToInt32(Const.Instance.hk[2]))
            {
                MessageBox.Show("Chọn lại thời gian");
                return;
            }
            try
            {
                int i = DataProvider.Instance.ExecuteNonQueryOracle
                    ("insert into ad.khmo(mahp, hk, nam, mact, madv) " +
                    "values('" + textBox34.Text + "', '" + textBox33.Text + "', " + textBox32.Text + ", '" + comboBox8.Text + "',(select madv from ad.HocPhan where mahp = '" + textBox34.Text + "'))"); 
                if (i == 1)
                {
                    MessageBox.Show("Thêm thành công");
                    dataGridView3.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.khmo");
                }
                else
                {
                    MessageBox.Show("Thêm không thành công");
                }
            }
            catch
            {
                MessageBox.Show("Nhập đúng thông tin");
            }
        }

        

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            try
            {
                int i = DataProvider.Instance.ExecuteNonQueryOracle("insert into ad.donvi values ('" + textBox37.Text + "', N'" + textBox36.Text + "', '" + textBox11.Text + "')");
                if (i == 1)
                {
                    MessageBox.Show("Thêm thành công");
                    dataGridView5.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.DonVI");
                }
                else MessageBox.Show("Thêm không thành công");
            }
            catch
            {
                MessageBox.Show("Nhập đúng thông tin");
            }
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            try
            {
                int i = DataProvider.Instance.ExecuteNonQueryOracle("update ad.donvi set madv = '" + textBox37.Text + "', tendv = N'" + textBox36.Text + "', trgdv = '" + textBox11.Text + "' where madv = '" + textBox37.Text + "'");
                if (i == 1)
                {
                    MessageBox.Show("Sửa thành công");
                    dataGridView5.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.DonVI");
                }
                else MessageBox.Show("Sửa không thành công");
            }
            catch
            {
                MessageBox.Show("Nhập đúng thông tin");
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (textBox17.Text == "")
            {
                MessageBox.Show("Chọn sinh viên");
                return;
            }
            Form dangKyHocPhan = new DangKyHocPhan(textBox17.Text);
            dangKyHocPhan.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int i = DataProvider.Instance.ExecuteNonQueryOracle("update ad.UV_CS1_1_XEMDULIEUCHINHMINH set dt = '" + textBox1.Text + "' where manv = '" + id + "'");
            if (i == 1) MessageBox.Show("Cập nhật số điện thoại: " + textBox1.Text);
            else MessageBox.Show("Cập nhật số điện thoại không thành công!!!");
        }

        private void Home_GiaoVu_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.SinhVien where hoten like N'%" + guna2TextBox1.Text + "%'");
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.Hocphan where tenhp like N'%" + guna2TextBox2.Text + "%'");
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            string hk = comboBox1.Text;
            if (comboBox1.Text == "Tất cả") hk = "";
            dataGridView3.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.khmo where mahp like '%" + comboBox4.Text + "%' and hk like '%" + hk + "%' and nam like '%" + textBox8.Text + "%'");
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
            comboBox8.Text = row.Cells[3].Value.ToString();
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
            comboBox2.Text = row.Cells[2].Value.ToString();
            textBox20.Text = ((DateTime)row.Cells[3].Value).ToShortDateString();
            textBox21.Text = row.Cells[4].Value.ToString();
            textBox22.Text = row.Cells[5].Value.ToString();
            comboBox5.Text = row.Cells[6].Value.ToString();
            comboBox6.Text = row.Cells[7].Value.ToString();
            textBox25.Text = row.Cells[8].Value.ToString();
            textBox26.Text = row.Cells[9].Value.ToString();
        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            DataProvider.Instance.changeLogin("GIAOVU_OLS", "GV");
            Form thongBao = new ThongBao();
            thongBao.Show();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
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
            textBox27.Text = row.Cells[3].Value.ToString();
            textBox42.Text = row.Cells[4].Value.ToString();
            textBox43.Text = row.Cells[5].Value.ToString();
            comboBox7.Text = row.Cells[6].Value.ToString();
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            try
            {
                int i = DataProvider.Instance.ExecuteNonQueryOracle("delete from ad.Hocphan where mahp = '" + textBox30.Text + "'");
                if (i == 1)
                {
                    MessageBox.Show("Xóa thành công");
                    dataGridView2.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.Hocphan");
                }
                else MessageBox.Show("Xóa không thành công");
            }
            catch
            {
                MessageBox.Show("Không thể xóa");
            }
        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {

            try
            {
                int i = DataProvider.Instance.ExecuteNonQueryOracle("delete from ad.khmo where mahp = '" + textBox34.Text + "' and nam = " + textBox32.Text + " and hk = '" + textBox33.Text + "' and mact = '" + comboBox8.Text + "'");
                if (i == 1)
                {
                    MessageBox.Show("Xóa thành công");
                    dataGridView3.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.khmo");
                }
                else MessageBox.Show("Xóa không thành công");
            }
            catch
            {
                MessageBox.Show("Không thể xóa");
            }
        }
        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button12_Click_1(object sender, EventArgs e)
        {
            string hk = comboBox9.Text;
            if (hk == "Tất cả") hk = "";
            dataGridView4.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.UV_CS3_3_1_XEMDULIEUTOANBOPHANCONG where mahp like '%" + comboBox3.Text + "%' and hk like '%" + hk + "%' and nam like '%" + textBox9.Text + "%'");

        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView4.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView4.Rows[rowId];
            textBox45.Text = row.Cells[1].Value.ToString();
            textBox46.Text = row.Cells[0].Value.ToString();
            textBox47.Text = row.Cells[2].Value.ToString();
            textBox48.Text = row.Cells[3].Value.ToString();
            textBox49.Text = row.Cells[4].Value.ToString();

            
        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                
                int i = DataProvider.Instance.ExecuteNonQueryOracle("update ad.UV_CS3_3_2_SUADULIEUBANGPHANCONG set magv = '" + textBox10.Text + "' where mahp = '" + textBox45.Text + "' and magv = '" + textBox46.Text + "' and hk = '" + textBox47.Text + "' and nam = " + textBox48.Text + " and mact = '" + textBox49.Text + "'");
                if (i == 1)
                {
                    MessageBox.Show("Sửa thành công");
                    dataGridView4.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.UV_CS3_3_1_XEMDULIEUTOANBOPHANCONG");
                }
                else MessageBox.Show("Sửa không thành công");
            }
            catch 
            {
                MessageBox.Show("Phân công này đã được đăng ký");
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            dataGridView5.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.DonVI where tendv like N'%" + guna2TextBox5.Text + "%'");
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView5.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView5.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView5.Rows[rowId];
            textBox37.Text = row.Cells[0].Value.ToString();
            textBox36.Text = row.Cells[1].Value.ToString();
            textBox11.Text = row.Cells[2].Value.ToString();
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {

            this.Close();
            DataProvider.Instance.changeLogin("ad", "ad");
        }

        private void guna2Button7_Click_1(object sender, EventArgs e)
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
                                                                " where masv = '" + textBox31.Text +
                                                                "' and mahp = '" + textBox24.Text +
                                                                "' and nam = " + textBox19.Text +
                                                                " and hk = '" + textBox23.Text + "'");

            dataGridView6.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.DangKy where magv = '" + this.id + "'");
            textBox16.Text = diemtk.ToString();
            if (i == 1)
            {
                MessageBox.Show("Cập nhật thành công: \n" +
                    " - Điểm thực hành: " + textBox13.Text + "\n" +
                    " - Điểm quá trình: " + textBox15.Text + "\n" +
                    " - Điểm cuối kỳ: " + textBox14.Text + "\n" +
                    " - Điểm tổng kết: " + diemtk.ToString() + "\n");

            }
            else MessageBox.Show("Cập nhật không thành công!!!");
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView6.RowCount <= 1) return;
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId > dataGridView6.RowCount - 2) rowId = rowId - 1;
            DataGridViewRow row = dataGridView6.Rows[rowId];
            textBox31.Text = row.Cells[0].Value.ToString();
            textBox24.Text = row.Cells[2].Value.ToString();
            textBox23.Text = row.Cells[3].Value.ToString();
            textBox19.Text = row.Cells[4].Value.ToString();
            textBox12.Text = row.Cells[5].Value.ToString();
            textBox13.Text = row.Cells[6].Value.ToString();
            textBox15.Text = row.Cells[7].Value.ToString();
            textBox14.Text = row.Cells[8].Value.ToString();
            textBox16.Text = row.Cells[9].Value.ToString();
        }

        private void guna2Button21_Click(object sender, EventArgs e)
        {
            int i = DataProvider.Instance.ExecuteNonQueryOracle("delete from ad.DangKy where masv = '" + textBox31.Text + "' and mahp = '" +  textBox24.Text + "' and hk = '" + textBox23.Text + "' and nam = " + textBox19.Text + " and mact = '" + textBox12.Text + "'");
            if (i == 1)
            {
                MessageBox.Show("Xóa thành công");
                dataGridView6.DataSource = DataProvider.Instance.ExecuteQueryOracle("select * from ad.DangKy");
            }
            else MessageBox.Show("Xóa không thành công");
        }
    }
}
