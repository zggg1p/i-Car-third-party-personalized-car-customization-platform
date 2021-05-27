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
    public partial class 厂商登录 : Form
    {
        ValidCode validCode = new ValidCode(5, ValidCode.CodeType.Numbers);
        public SqlConnection conn;
        public 厂商登录()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            string constr = @"Server=.\sqlexpress;Database=2021040614;Integrated security=True;";
            conn = new SqlConnection(constr);
        }

        private void Form22_Load(object sender, EventArgs e)
        {
            picValidCode.Image = Bitmap.FromStream(validCode.CreateCheckCodeImage());
        }

        private void picValidCode_Click(object sender, EventArgs e)
        {
            picValidCode.Image = Bitmap.FromStream(validCode.CreateCheckCodeImage());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a, b, c;
            a = "";
            b = "";
            c = "";
            string sql = "select * from changshang where 厂商=@_username";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@_username", SqlDbType.NVarChar, 50);
            cmd.Parameters["@_username"].Value = uiTextBox1.Text;
            conn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                a = rd[0].ToString();
                b = rd[1].ToString();
                c = rd[6].ToString();
            }
            rd.Close();
            conn.Close();
            if (!this.uiTextBox3.Text.Equals(validCode.CheckCode))
            {
                MessageBox.Show("请输入正确的验证码！", "提示");
                this.uiTextBox3.Focus();
                this.uiTextBox3.Text = "";
                picValidCode.Image = Bitmap.FromStream(validCode.CreateCheckCodeImage());
                return;
            }
            else if (uiTextBox1.Text == "" || uiTextBox2.Text == ""
                || uiTextBox3.Text == "")
            {
                MessageBox.Show("请将信息填完整");
            }
            else if (uiTextBox2.Text == b)
            {
                if (c == "是")
                {
                    MessageBox.Show("登陆成功", "提示");
                    Class1.厂商 = a;
                    后台数据 f = new 后台数据();
                    f.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("未授权，请等待！");
                }
            }
            else if (uiTextBox2.Text != b)
            {
                MessageBox.Show("密码错误，请重新输入");
                uiTextBox2.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }//厂商登录
}
