using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDuLieuNoiBo
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DataProvider.Instance.changeLogin("ad", "ad");
                DataTable info = new DataTable();
                if (comboBox1.SelectedIndex == 0)
                    info = DataProvider.Instance.ExecuteQueryOracle
                        ("select * from ad.NhanSu where manv = '" + guna2TextBox1.Text + "'");
                else if (comboBox1.SelectedIndex == 2)
                {
                    info = DataProvider.Instance.ExecuteQueryOracle
                       ("select * from DBA_USERS where username = '" + guna2TextBox1.Text.ToUpper() + "'");
                }
                else if (comboBox1.SelectedIndex == 3)

                {
                    info = DataProvider.Instance.ExecuteQueryOracle
                        ("select * from DBA_USERS where username = '" + guna2TextBox1.Text.ToUpper() + "'");
                }
                else if (comboBox1.SelectedIndex == 4)

                {
                    DataProvider.Instance.changeLogin("AD_OLS", guna2TextBox2.Text);
                    info = DataProvider.Instance.ExecuteQueryOracle
                    ("select * from DBA_USERS where username = 'AD_OLS'");
                }
                else
                {
                    DataProvider.Instance.changeLogin("NV001", "0123456789");
                    info = DataProvider.Instance.ExecuteQueryOracle
                        ("select * from ad.SinhVien where masv = '" + guna2TextBox1.Text + "'");
                }
                if (info.Rows.Count == 0 && comboBox1.SelectedIndex != 4)
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
                    return;
                }
                DataProvider.Instance.changeLogin(guna2TextBox1.Text, guna2TextBox2.Text);
                if (comboBox1.SelectedIndex == 1)
                {
                    Form sinhvien = new PhanHe2.SinhVien.Home_SinhVien(guna2TextBox1.Text);
                    sinhvien.Show();
                    return;
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    Form admin = new PhanHe1.Home();
                    admin.Show();
                    return;
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    Form nhanVienTaiChinh = new PhanHe2.Home_NVPhongTaiChinh(guna2TextBox1.Text);
                    nhanVienTaiChinh.Show();
                    return;
                }
                else if (comboBox1.SelectedIndex == 4)
                {
                    // Mở form dành cho ad_ols nếu cần
                    Form OLS_admin = new PhanHe1.OLS_Admin();
                    OLS_admin.Show();
                    // Mở form hoặc chức năng dành cho ad_ols ở đây
                    return;
                }
                string vaitro = info.Rows[0]["vaitro"].ToString();
                Form form1 = new Form();
                if (vaitro == "Nhân viên cơ bản") form1 = new PhanHe2.Home_NhanVienCoBan(guna2TextBox1.Text);
                if (vaitro == "Giảng viên") form1 = new PhanHe2.GiangVien.Home_GiangVien(guna2TextBox1.Text);
                if (vaitro == "Trưởng  khoa") form1 = new PhanHe2.TruongKhoa.Home_TruongKhoa(guna2TextBox1.Text);
                if (vaitro == "Trưởng  đơn vị") form1 = new PhanHe2.TruongDonVi.Home_TruongDonVi(guna2TextBox1.Text);
                if (vaitro == "Giáo vụ") form1 = new PhanHe2.GiaoVu.Home_GiaoVu(guna2TextBox1.Text);
                form1.Show();
            }
            catch
            {
                MessageBox.Show("Mật khẩu hoặc tên đăng nhập không đúng");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
