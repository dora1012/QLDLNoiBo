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
    public partial class ThemPhanCong : Form
    {
        public ThemPhanCong()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DataTable info = DataProvider.Instance.ExecuteQueryOracle
                ("select * from ad.KHMO where mahp = '" + comboBox1.SelectedValue.ToString() + "' and hk = '" + Const.Instance.hk + "' and nam = " + Const.Instance.nam + " and mact = '" + comboBox4.SelectedItem + "'");
            if(info.Rows.Count == 0)
            {
                MessageBox.Show("Học phần chưa được mở");
                return;
            }
            DataTable info2 = DataProvider.Instance.ExecuteQueryOracle
                ("select * from ad.PhanCong where mahp = '" + comboBox1.SelectedValue.ToString() + "' and magv = '" + comboBox2.SelectedValue.ToString() + "' and hk = '" + Const.Instance.hk + "' and nam = " + Const.Instance.nam + " and mact = '" + comboBox4.SelectedItem + "'");
            if(info2.Rows.Count == 1)
            {
                MessageBox.Show("Học phần đã được phân công cho giáo viên này");
                return;
            }
            int i = DataProvider.Instance.ExecuteNonQueryOracle("insert into ad.UV_CS5_5_2_THEMXOASUADULIEUBANGPHANCONG(mahp, magv, nam, hk, mact) values('" + comboBox1.SelectedValue + "', '" + comboBox2.SelectedValue + "', " + Const.Instance.nam + ", '" + Const.Instance.hk + "', '" + comboBox4.SelectedItem.ToString() + "')");
            if(i == 1)
            {
                MessageBox.Show("Thêm thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm không thành công");
            }
        }

        private void ThemPhanCong_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = DataProvider.Instance.ExecuteQueryOracle("select mahp, tenhp from ad.HocPhan where madv = 'DV001' order by tenhp");
            comboBox1.DisplayMember = "tenhp";
            comboBox1.ValueMember = "mahp";

            comboBox2.DataSource = DataProvider.Instance.ExecuteQueryOracle("select manv, hoten from ad.NhanSu where vaitro = N'Giảng viên'");
            comboBox2.DisplayMember = "manv";
            comboBox2.ValueMember = "manv";

            textBox1.Text = Const.Instance.hk;
            textBox2.Text = Const.Instance.nam;

            comboBox4.SelectedIndex = 0;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
