using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class CreateUser : Form
    {
        public CreateUser()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataProvider.Instance.ExecuteRunOracle("ALTER SESSION SET" + '"' + "_ORACLE_SCRIPT" + '"' + "= TRUE");
                DataProvider.Instance.ExecuteRunOracle($"CREATE USER {guna2TextBox1.Text} IDENTIFIED BY {guna2TextBox2.Text}");
                //DataProvider.Instance.ExecuteRunOracle("grant connect to " + guna2TextBox1.Text);
                DataProvider.Instance.ExecuteRunOracle("ALTER SESSION SET" + '"' + "_ORACLE_SCRIPT" + '"' + "= FALSE");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("ORA-01920"))
                MessageBox.Show("Lỗi trùng tên User", "Error!");
            }
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {

        }
    }
}
