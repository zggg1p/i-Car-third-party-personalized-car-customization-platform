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
    public partial class 厂家回复 : Form
    {
        public SqlConnection conn;
        public 厂家回复()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            string constr = @"Server=.\sqlexpress;Database=2021040614;Integrated security=True;";
            conn = new SqlConnection(constr);
        }

        private void Form26_Load(object sender, EventArgs e)
        {
            string sql = "select * from baoxiu where 反馈编号='" + Class1.反馈编号 + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                uiTextBox1.Text = Class1.反馈编号;
                uiTextBox2.Text = rd[1].ToString();
                uiRichTextBox2.Text = rd[2].ToString();
                uiTextBox3.Text = rd[3].ToString();

            }
            conn.Close();
            rd.Close();
            string sql1="select * from huifu where 反馈编号='" + Class1.反馈编号 + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            conn.Open();
            SqlDataReader rd1 = cmd1.ExecuteReader();
            while (rd1.Read())
            {
                uiRichTextBox1.Text = rd1[1].ToString();
            }
            conn.Close();
            rd1.Close();//编号等加载
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            string sql = "select isnull(count(*),0) from huifu where 反馈编号='" + Class1.反馈编号 + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            if (i != 0)
            {
                string sql1 = "update huifu set 反馈详情='" + uiRichTextBox1.Text + "' where 反馈编号='" + Class1.反馈编号 + "'";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                conn.Open();
                cmd1.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                string sql1 = "update baoxiu set 是否回复='是' where 反馈编号='" + Class1.反馈编号 + "'";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                conn.Open();
                cmd1.ExecuteNonQuery();
                conn.Close();
                string sql2 = "insert into huifu values('"+Class1.反馈编号+"','"+uiRichTextBox1.Text+"','"+DateTime.Now.ToString()+"')";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();
            }
            this.Close();//进行反馈及更新
        }

        private void 厂家回复_FormClosing(object sender, FormClosingEventArgs e)
        {
            string sql反馈 = "select * from baoxiu";
            SqlCommand cmd反馈 = new SqlCommand(sql反馈, conn);
            SqlDataAdapter ad反馈 = new SqlDataAdapter(cmd反馈);
            DataTable dt反馈 = new DataTable();
            ad反馈.Fill(dt反馈);
            后台数据.后台数据2.uiDataGridView2.DataSource = dt反馈;//前端更新
        }
    }
}
