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
    public partial class CreateRole : Form
    {
        public CreateRole()
        {
            InitializeComponent();
        }

        private void CreateRole_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "") return;
            try
            {
                DataProvider.Instance.TrueSession();
                DataProvider.Instance.ExecuteRunOracle("create role " + guna2TextBox1.Text);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("ORA-01920"))
                {
                    MessageBox.Show("Lỗi trùng tên Role", "Error!");
                }
            }
            //.Instance.ExecuteRunOracle("grant connect to " + guna2TextBox1.Text);
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
