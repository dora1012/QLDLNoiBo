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
    public partial class Privileges : Form
    {
        public Privileges()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQueryOracle("SELECT * FROM dba_sys_privs");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQueryOracle("SELECT * FROM DBA_ROLE_PRIVS");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQueryOracle("SELECT * FROM DBA_TAB_PRIVS WHERE OWNER = 'AD'");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQueryOracle("SELECT * FROM DBA_COL_PRIVS WHERE OWNER = 'AD'");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = DataProvider.Instance.ExecuteQueryOracle("SELECT * FROM ROLE_SYS_PRIVS");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = DataProvider.Instance.ExecuteQueryOracle("SELECT * FROM ROLE_ROLE_PRIVS");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = DataProvider.Instance.ExecuteQueryOracle("SELECT * FROM ROLE_TAB_PRIVS");
        }
    }
}
