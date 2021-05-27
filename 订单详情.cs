using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace i_car1
{
    public partial class 订单详情 : Form
    {
        public SqlConnection conn;
        public 订单详情()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            string constr = @"Server=.\sqlexpress;Database=2021040614;Integrated security=True;";
            conn = new SqlConnection(constr);
        }

        private void 订单详情_Load(object sender, EventArgs e)
        {
            uiLabel2.Text = Class1.姓名 + "先生/女生";
            string sql1 = @"select 汽车名称,颜色,总价 from order1 where 订单编号=@订单编号";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            cmd1.Parameters.Add("@订单编号", SqlDbType.NVarChar, 255).Value = Class1.订单号;
            conn.Open();
            SqlDataReader rd = cmd1.ExecuteReader();
            if(rd.Read())
            {
                uiLabel4.Text = rd[0].ToString();
                uiLabel6.Text = rd[1].ToString();
                uiLabel8.Text = rd[2].ToString() + "元";
                uiLabel10.Text = Class1.订单号;
            }
            rd.Close();
            conn.Close();
            string sqlm = @"select 零件种类,零件名称,价格 from components,orderparts
                           where components.零件编号=orderparts.零件编号
                           and 订单编号=@订单编号";
            SqlCommand cmdm = new SqlCommand(sqlm, conn);
            cmdm.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
            SqlDataAdapter ad = new SqlDataAdapter(cmdm);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            uiDataGridView1.DataSource = dt;//查看订单详情并填充
        }

        private void uiLabel6_Click(object sender, EventArgs e)
        {

        }
    }
}
