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
using System.Security.Cryptography;

namespace i_car1
{
    public partial class 登录 : Form
    {
        ValidCode validCode = new ValidCode(5, ValidCode.CodeType.Numbers);
        public SqlConnection conn;
        public 登录()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            string constr = @"Server=.\sqlexpress;Database=2021040614;Integrated security=True";
            conn = new SqlConnection(constr);
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            picValidCode.Image = Bitmap.FromStream(validCode.CreateCheckCodeImage());
        }

        private void picValidCode_Click(object sender, EventArgs e)
        {
            picValidCode.Image = Bitmap.FromStream(validCode.CreateCheckCodeImage());
        }

        private void yes_Click(object sender, EventArgs e)
        {
            string a, b,c,d;
            a = "";
            b = "";
            c="";
            d="";
            string sql = "select * from users where 用户名=@_username";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@_username", SqlDbType.NVarChar, 20);
            cmd.Parameters["@_username"].Value = uiTextBox1.Text;
            conn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                a = rd[0].ToString();
                b = rd[1].ToString();
                c=rd[2].ToString();
                d=rd[4].ToString();
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
            else if(uiTextBox2.Text == b)
            {
                MessageBox.Show("登陆成功", "提示");
                Class1.用户名 = a;
                Class1.姓名 = c;
                Class1.省份 = d;
                主页面 f = new 主页面();
                f.Show();
                this.Close();
            }
            else if(uiTextBox2.Text != b)
            {
                MessageBox.Show("密码错误，请重新输入");
                uiTextBox2.Text = "";
            }
        }//用户登录

        private void no_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
