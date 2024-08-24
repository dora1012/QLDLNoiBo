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
    public partial class Audit : Form
    {
        public Audit()
        {
            DataProvider.Instance.changeLogin("ad", "ad");
            InitializeComponent();
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQueryOracle("select username, owner, obj_name, action_name, extended_timestamp from dba_audit_trail");
            dataGridView2.DataSource = DataProvider.Instance.ExecuteQueryOracle("SELECT DB_USER, OBJECT_NAME, OBJECT_SCHEMA, SQL_TEXT, EXTENDED_TIMESTAMP,POLICY_NAME from dba_fga_audit_trail WHERE object_schema = 'AD'");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
