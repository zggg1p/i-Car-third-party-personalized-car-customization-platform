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
    public partial class 厂商注册 : Form
    {
        public SqlConnection conn;
        public 厂商注册()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            string constr = @"Server=.\sqlexpress;Database=2021040614;Integrated security=True;";
            conn = new SqlConnection(constr);
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            string sql = @"insert into changshang(厂商,登陆密码,法人姓名,法人手机号,邮箱,详细地址) values(@厂商,@登陆密码,@法人姓名,@法人手机号,@邮箱,@详细地址)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@厂商", SqlDbType.NVarChar, 50).Value =uiTextBox1.Text;
            cmd.Parameters.Add("@登陆密码", SqlDbType.NVarChar, 20).Value =uiTextBox2.Text;
            cmd.Parameters.Add("@法人姓名", SqlDbType.NVarChar, 50).Value =uiTextBox3.Text;
            cmd.Parameters.Add("@法人手机号", SqlDbType.NVarChar, 11).Value =uiTextBox8.Text;
            cmd.Parameters.Add("@邮箱", SqlDbType.NVarChar, 30).Value =uiTextBox7.Text;
            cmd.Parameters.Add("@详细地址", SqlDbType.NVarChar, 255).Value =uiTextBox6.Text;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "失败");
            }
            finally
            {
                conn.Close();
                MessageBox.Show("注册成功，请等待审核!");
                this.Close();
            }//厂商注册
        }

        private void uiLabel4_Click(object sender, EventArgs e)
        {

        }
    }
}
