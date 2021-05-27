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
    public partial class 注册 : Form
    {
        public SqlConnection conn;
        public 注册()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            string constr = @"Server=.\sqlexpress;Database=2021040614;Integrated security=True;";
            conn = new SqlConnection(constr);//连接数据库
        }

        private void Form17_Load(object sender, EventArgs e)
        {
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            string sql = "insert into users values(@_username,@_code,@_name,@_gender,@_sheng,@_shi,@_dizhi,@_mail,@_num,@age)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@_username", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@_code", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@_name", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@_gender", SqlDbType.NVarChar, 2);
            cmd.Parameters.Add("@_sheng", SqlDbType.NVarChar, 10);
            cmd.Parameters.Add("@_shi", SqlDbType.NVarChar, 10);
            cmd.Parameters.Add("@_dizhi", SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@_mail", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@_num", SqlDbType.NVarChar, 11);
            cmd.Parameters.Add("@age", SqlDbType.NVarChar, 20);
            cmd.Parameters["@_username"].Value = uiTextBox1.Text;
            cmd.Parameters["@_code"].Value = uiTextBox2.Text;
            cmd.Parameters["@_name"].Value = uiTextBox3.Text;
            cmd.Parameters["@_sheng"].Value = comboBox1.Text;
            cmd.Parameters["@_shi"].Value = uiTextBox5.Text;
            cmd.Parameters["@_dizhi"].Value = uiTextBox6.Text;
            cmd.Parameters["@_mail"].Value = uiTextBox7.Text;
            cmd.Parameters["@_num"].Value = uiTextBox8.Text;
            cmd.Parameters["@age"].Value = comboBox2.Text;
            if (uiRadioButton1.Checked) cmd.Parameters["@_gender"].Value = uiRadioButton1.Text;
            if (uiRadioButton2.Checked) cmd.Parameters["@_gender"].Value = uiRadioButton2.Text;
            try
            {
                if (uiTextBox1.Text != "" && uiTextBox2.Text != "" && uiTextBox3.Text != "" && uiTextBox5.Text != "" && uiTextBox6.Text != "" && uiTextBox7.Text != "" && uiTextBox8.Text != "" && comboBox1.Text!="")
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("注册成功", "提示");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("请完善信息", "提示");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "失败");
            }
            finally
            {
                conn.Close();
            }//注册
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiLabel9_Click(object sender, EventArgs e)
        {

        }

        private void uiComboboxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void uiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void uiTextBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void uiTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiTextBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void uiTextBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void uiTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void uiLabel8_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel7_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel6_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel5_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel4_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel3_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel2_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void uiTextBox1_Click(object sender, EventArgs e)
        {
            if (uiTextBox1.Text == "用户名") 
            {
                uiTextBox1.Text = "";
                uiTextBox1.ForeColor = Color.Black;
            }
            else
            { }
        }

        private void uiTextBox2_Click(object sender, EventArgs e)
        {
            if (uiTextBox2.Text == "密码")
            {
                uiTextBox2.Text = "";
                uiTextBox2.ForeColor = Color.Black;
            }
            else
            { }
        }

        private void uiTextBox3_Click(object sender, EventArgs e)
        {
            if (uiTextBox3.Text == "姓名")
            {
                uiTextBox3.Text = "";
                uiTextBox3.ForeColor = Color.Black;
            }
            else
            { }
        }

        private void uiTextBox8_Click(object sender, EventArgs e)
        {
            if (uiTextBox8.Text == "手机号")
            {
                uiTextBox8.Text = "";
                uiTextBox8.ForeColor = Color.Black;
            }
            else
            { }
        }

        private void uiTextBox5_Click(object sender, EventArgs e)
        {
            if (uiTextBox5.Text == "地级市")
            {
                uiTextBox5.Text = "";
                uiTextBox5.ForeColor = Color.Black;
            }
            else
            { }
        }

        private void uiTextBox6_Click(object sender, EventArgs e)
        {
            if (uiTextBox6.Text == "详细地址")
            {
                uiTextBox6.Text = "";
                uiTextBox6.ForeColor = Color.Black;
            }
            else
            { }
        }

        private void uiTextBox7_Click(object sender, EventArgs e)
        {
            if (uiTextBox7.Text == "邮箱")
            {
                uiTextBox7.Text = "";
                uiTextBox7.ForeColor = Color.Black;
            }
            else
            { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void uiRadioButton1_ValueChanged(object sender, bool value)
        {

        }

        private void uiRadioButton2_ValueChanged(object sender, bool value)
        {

        }
    }
}
