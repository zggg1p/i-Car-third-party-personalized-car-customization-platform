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
    public partial class 报修 : Form
    {
        public SqlConnection conn;
        public 报修()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            string constr = @"Server=.\sqlexpress;Database=2021040614;Integrated security=True;";
            conn = new SqlConnection(constr);
        }

        private void 报修_Load(object sender, EventArgs e)
        {
            uiLabel2.Text = Class1.订单号;
            Class1.反馈编号=Class1.用户名+ DateTime.Now.ToFileTimeUtc().ToString();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            string sql报修 = @"insert into baoxiu values(@反馈编号,@类型,@内容,@时间,@订单编号,@反馈情况)";
            SqlCommand cmd报修 = new SqlCommand(sql报修, conn);
            cmd报修.Parameters.Add("@反馈编号", SqlDbType.NVarChar, 255).Value = Class1.反馈编号;
            cmd报修.Parameters.Add("@类型", SqlDbType.NVarChar, 50).Value = comboBox1.Text;
            cmd报修.Parameters.Add("@内容", SqlDbType.Text).Value = uiRichTextBox1.Text;
            cmd报修.Parameters.Add("@时间",SqlDbType.Date).Value= DateTime.Now.ToString();
            cmd报修.Parameters.Add("@订单编号", SqlDbType.NVarChar, 255).Value = Class1.订单号;
            cmd报修.Parameters.Add("@反馈情况", SqlDbType.NVarChar, 50).Value = "否";
            try
            {
                conn.Open();
                cmd报修.ExecuteNonQuery();
                MessageBox.Show("上报成功！");
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "失败");
            }
            finally
            {
                conn.Close();
            }//报修
        }
    }
}
