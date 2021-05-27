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
    public partial class 反馈 : Form
    {
        public SqlConnection conn;
        public 反馈()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            string constr = @"Server=.\sqlexpress;Database=2021040614;Integrated security=True;";
            conn = new SqlConnection(constr);
        }

        private void 反馈_Load(object sender, EventArgs e)
        {
            string sql1 = @"select baoxiu.反馈编号,类型 反馈类型,反馈时间,反馈详情 from baoxiu,huifu
                          where baoxiu.反馈编号=huifu.反馈编号
                          and baoxiu.反馈编号=@反馈编号";
            SqlCommand cmd = new SqlCommand(sql1, conn);
            cmd.Parameters.Add("@反馈编号", SqlDbType.NVarChar, 255).Value = Class1.反馈编号;
            conn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if(rd.Read())
            {
                uiLabel2.Text = rd[0].ToString();
                uiLabel4.Text = rd[1].ToString();
                uiLabel6.Text = rd[2].ToString();
                uiRichTextBox1.Text = rd[3].ToString();
            }
            rd.Close();
            conn.Close();//查看反馈详情并填充
        }
    }
}
