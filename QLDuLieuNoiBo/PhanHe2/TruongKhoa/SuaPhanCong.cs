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
    public partial class SuaPhanCong : Form
    {
        string mahp;
        string magv;
        string hk;
        string nam;
        string mact;
        public SuaPhanCong(string mahp, string magv, string hk, string nam, string mact)
        {
            InitializeComponent();
            this.mahp = mahp;
            this.magv = magv;
            this.hk = hk;
            this.nam = nam;
            this.mact = mact;
            comboBox1.DataSource = DataProvider.Instance.ExecuteQueryOracle("select ns.manv from ad.NhanSu ns where ns.vaitro = N'Giảng viên' and ns.manv not in (select magv from ad.PhanCong where mahp = '" + mahp + "' and nam = " + nam + " and hk = '" + hk + "' and mact = '" + mact + "')");
            comboBox1.DisplayMember = "manv";
            comboBox1.ValueMember = "manv";
            textBox4.Text = mahp;
            textBox1.Text = hk;
            textBox2.Text = nam;
            textBox3 .Text = mact;
        }

        private void SuaPhanCong_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                int del, ins;
                del = DataProvider.Instance.ExecuteNonQueryOracle("delete from ad.UV_CS5_5_2_THEMXOASUADULIEUBANGPHANCONG where mahp = '" + mahp + "' and nam = " + nam + " and hk = '" + hk + "' and mact = '" + mact + "' and magv = '" + magv + "'");
                ins = DataProvider.Instance.ExecuteNonQueryOracle("insert into ad.UV_CS5_5_2_THEMXOASUADULIEUBANGPHANCONG(mahp, magv, nam, hk, mact) values('" + mahp + "', '" + comboBox1.Text + "', " + Const.Instance.nam + ", '" + Const.Instance.hk + "', '" + mact + "')");

                if (del == 1 && ins == 1)
                {
                    DataProvider.Instance.ExecuteRunOracle("commit");
                    MessageBox.Show("Cập nhật thành công: \n - Mã học phần: " + mahp + "\n - Mã giáo viên: " + comboBox1.SelectedValue.ToString() + "\n - Năm: " + nam + "\n - Học kỳ: " + hk + "\n - Mã chương trình: " + mact);
                    this.Close();
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
    }
}
