using Oracle.ManagedDataAccess.Client;
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
    public partial class Home_NVPhongTaiChinh : Form
    {
        string id;
        public Home_NVPhongTaiChinh(string _id)
        {
            InitializeComponent();
            this.id = _id;
        }

        private void Home_NVPhongTaiChinh_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            decimal totalSalary = DataProvider.Instance.GetTotalSalary();
            textBox1.Text = totalSalary.ToString("N0");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                int year = int.Parse(textBox4.Text);
                string semester = comboBox1.SelectedItem.ToString();
                string courseId = textBox3.Text;

                decimal revenue = DataProvider.Instance.getRevenue(year, semester, courseId);
                textBox2.Text = revenue.ToString("N0"); 
            }
            catch (FormatException)
            {
                MessageBox.Show("Nhập đúng thông tin: Năm phải là số.");
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Lỗi Oracle: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            this.Close();
            DataProvider.Instance.changeLogin("ad", "ad");
        }
    }
}
