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

namespace QLDuLieuNoiBo.PhanHe1
{
    public partial class OLS_Admin : Form
    {
        public OLS_Admin()
        {
            InitializeComponent();
            DataProvider.Instance.changeLogin("AD_OLS", "AD_OLS");
            string query = "SELECT * FROM THONGBAO";
            DataTable data = DataProvider.Instance.ExecuteQueryOracle(query);
            dataGridView1.DataSource = data;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataProvider.Instance.ExecuteNonQueryOracle
                   ("INSERT INTO THONGBAO(NOIDUNG) VALUES('" + textBox1.Text + "')");
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataProvider.Instance.ExecuteNonQueryOracle
                   ("Commit");
            string query = "SELECT * FROM THONGBAO";
            DataTable data = DataProvider.Instance.ExecuteQueryOracle(query);
            dataGridView1.DataSource = data;
        }
    }
}
