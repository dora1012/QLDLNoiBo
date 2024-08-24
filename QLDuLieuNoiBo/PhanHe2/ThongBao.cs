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
    public partial class ThongBao : Form
    {
        public ThongBao()
        {
            InitializeComponent();
            string query = "SELECT * FROM ad_ols.THONGBAO";
            DataTable data = DataProvider.Instance.ExecuteQueryOracle(query);
            dataGridView1.DataSource = data;
        }
    }
}
