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
    public partial class 文章 : Form
    {
        public SqlConnection conn;
        public 文章()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            string constr = @"Server=.\sqlexpress;Database=2021040614;Integrated security=True;";
            conn = new SqlConnection(constr);
        }

        private void Form23_Load(object sender, EventArgs e)
        {
            string sql = "select * from forum where headline='" + Class1.标题 + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                uiRichTextBox1.Text = rd[2].ToString() + "\r\n作者：" + rd[0].ToString() + "\r\n发布时间：" + rd[1] + "\r\n" + rd[3];
                label1.Text = rd[4].ToString();
            }
            conn.Close();
            rd.Close();
            string sql1 = "select count(*) from collect where headline='" + Class1.标题 + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            conn.Open();
            label2.Text = cmd1.ExecuteScalar().ToString();
            conn.Close();
            string sql2 = "select count(*) from discuss where headline='" + Class1.标题 + "'";
            SqlCommand cmd2 = new SqlCommand(sql2, conn);
            conn.Open();
            label3.Text = cmd2.ExecuteScalar().ToString();
            conn.Close();
            string sql4 = "select * from discuss where headline='" + Class1.标题 + "'";
            SqlCommand cmd4 = new SqlCommand(sql4, conn);
            conn.Open();
            SqlDataReader rd2 = cmd4.ExecuteReader();
            while (rd2.Read())
            {
                uiListBox1.Items.Add(rd2[2].ToString() + " //用户：" + rd2[1].ToString() + " //时间：" + rd2[3].ToString());
            }
            conn.Close();
            rd2.Close();//初始加载
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "update forum set likenum=likenum+1 where headline='" + Class1.标题 + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            label1.Text = "";
            string sql1 = "select * from forum where headline='" + Class1.标题 + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            conn.Open();
            SqlDataReader rd = cmd1.ExecuteReader();
            while (rd.Read())
            {
                label1.Text = rd[4].ToString();
            }
            conn.Close();
            rd.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "insert into collect values(@name,@head,getdate())";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@head", SqlDbType.NVarChar, 30);
            cmd.Parameters["@name"].Value = Class1.用户名;
            cmd.Parameters["@head"].Value = Class1.标题;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "失败");
            }
            finally
            {
                conn.Close();
            }
            label2.Text = "";
            string sql1 = "select count(*) from collect where headline='" + Class1.标题 + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            conn.Open();
            label2.Text = cmd1.ExecuteScalar().ToString();
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (uiRichTextBox2.Text == "")
            {
                MessageBox.Show("请输入评论", "提示");
            }
            else
            {
                string sql = "insert into discuss values(@head,@name,@text,getdate())";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@head", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@text", SqlDbType.Text);
                cmd.Parameters["@head"].Value = Class1.标题;
                cmd.Parameters["@name"].Value = Class1.用户名;
                cmd.Parameters["@text"].Value = uiRichTextBox2.Text;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "失败");
                }
                finally
                {
                    MessageBox.Show("您的评论已成功发出", "提示");
                    conn.Close();
                }
                label3.Text = "";
                string sql2 = "select count(*) from discuss where headline='" + Class1.标题 + "'";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                conn.Open();
                label3.Text = cmd2.ExecuteScalar().ToString();
                conn.Close();
                uiListBox1.Items.Clear();
                string sql4 = "select * from discuss where headline='" + Class1.标题 + "'";
                SqlCommand cmd4 = new SqlCommand(sql4, conn);
                conn.Open();
                SqlDataReader rd2 = cmd4.ExecuteReader();
                while (rd2.Read())
                {
                    uiListBox1.Items.Add(rd2[2].ToString() + " //用户：" + rd2[1].ToString() + " //时间：" + rd2[3].ToString());
                }
                conn.Close();
                rd2.Close();
            }
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            string sql = "update forum set likenum=likenum+1 where headline='" + Class1.标题 + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            label1.Text = "";
            string sql1 = "select * from forum where headline='" + Class1.标题 + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            conn.Open();
            SqlDataReader rd = cmd1.ExecuteReader();
            while (rd.Read())
            {
                label1.Text = rd[4].ToString();
            }
            conn.Close();
            rd.Close();//点赞
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            string sql = "insert into collect values(@name,@head,getdate())";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@head", SqlDbType.NVarChar, 30);
            cmd.Parameters["@name"].Value = Class1.用户名;
            cmd.Parameters["@head"].Value = Class1.标题;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "失败");
            }
            finally
            {
                conn.Close();
            }
            label2.Text = "";
            string sql1 = "select count(*) from collect where headline='" + Class1.标题 + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            conn.Open();
            label2.Text = cmd1.ExecuteScalar().ToString();
            conn.Close();//收藏
        }

        private void uiSymbolButton3_Click(object sender, EventArgs e)
        {
            if (uiRichTextBox2.Text == "")
            {
                MessageBox.Show("请输入评论", "提示");
            }
            else
            {
                string sql = "insert into discuss values(@head,@name,@text,getdate())";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@head", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@text", SqlDbType.Text);
                cmd.Parameters["@head"].Value = Class1.标题;
                cmd.Parameters["@name"].Value = Class1.用户名;
                cmd.Parameters["@text"].Value = uiRichTextBox2.Text;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "失败");
                }
                finally
                {
                    MessageBox.Show("您的评论已成功发出", "提示");
                    conn.Close();
                }
                label3.Text = "";
                string sql2 = "select count(*) from discuss where headline='" + Class1.标题 + "'";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                conn.Open();
                label3.Text = cmd2.ExecuteScalar().ToString();
                conn.Close();
                uiListBox1.Items.Clear();
                string sql4 = "select * from discuss where headline='" + Class1.标题 + "'";
                SqlCommand cmd4 = new SqlCommand(sql4, conn);
                conn.Open();
                SqlDataReader rd2 = cmd4.ExecuteReader();
                while (rd2.Read())
                {
                    uiListBox1.Items.Add(rd2[2].ToString() + " //用户：" + rd2[1].ToString() + " //时间：" + rd2[3].ToString());
                }
                conn.Close();
                rd2.Close();
            }
        }//评论

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
