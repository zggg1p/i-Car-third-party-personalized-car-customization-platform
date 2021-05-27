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
using yxh;
using i_car3;
using 智能推荐方案;

namespace i_car1
{
    public partial class 主页面 : Form
    {
        public SqlConnection conn;
        int index = 0;
        Image[] images = new Image[3];
        public 主页面()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            string constr = @"Server=.\sqlexpress;Database=2021040614;Integrated security=True;";
            conn = new SqlConnection(constr);//连接数据库
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            轿车 f = new 轿车();
            f.Show();//打开轿车购买页面
        }
        
        private void Form20_Load(object sender, EventArgs e)
        {
            images[0] = Properties.Resources.a;
            images[1] = Properties.Resources.b;
            images[2] = Properties.Resources.c;
            pictureBox4.Image = images[0];
            SqlCommand cmd = new SqlCommand("talk1", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            uiDataGridView1.DataSource = dt;
            string sql = "select forum.headline 标题,writer 作者,kind 类别,collect.times 收藏时间 from forum,collect where forum.headline=collect.headline and collect.username='" + Class1.用户名 + "'";
            SqlCommand cmd1 = new SqlCommand(sql, conn);
            SqlDataAdapter ad1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            ad1.Fill(dt1);
            uiDataGridView2.DataSource = dt1;//文章
            String sql1 = "select * from users where 用户名='" + Class1.用户名 + "'";
            SqlCommand cmd2 = new SqlCommand(sql1, conn);
            conn.Open();
            SqlDataReader rd = cmd2.ExecuteReader();
            while (rd.Read())
            {
                uiTextBox10.Text = rd[0].ToString();
                uiTextBox10.Enabled = false;
                uiTextBox9.Text = rd[1].ToString();
                uiTextBox4.Text = rd[2].ToString();
                uiTextBox4.Enabled = false;
                comboBox2.Text = rd[3].ToString();
                comboBox3.Text = rd[4].ToString();
                uiTextBox5.Text = rd[5].ToString();
                uiTextBox6.Text = rd[6].ToString();
                uiTextBox7.Text = rd[7].ToString();
                uiTextBox8.Text = rd[8].ToString();
            }
            rd.Close();
            conn.Close();//个人信息
            string sql订单 = @"select 订单编号,汽车名称,总价,下单时间,支付状态 from order1
                              where 用户名=@用户名";
            SqlCommand cmd订单 = new SqlCommand(sql订单, conn);
            cmd订单.Parameters.Add("@用户名", SqlDbType.NVarChar, 20).Value = Class1.用户名;
            SqlDataAdapter ad订单 = new SqlDataAdapter(cmd订单);
            DataTable dt订单 = new DataTable();
            ad订单.Fill(dt订单);
            uiDataGridView3.DataSource = dt订单;
            label7.Text = Class1.姓名;//交易记录

        }

        private void 查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (uiDataGridView1.CurrentRow.Cells[0].Value.ToString() == string.Empty)
                MessageBox.Show("请选择一篇文章", "提示");
            else
            {
                Class1.标题 = uiDataGridView1.CurrentRow.Cells[0].Value.ToString();
                文章 f = new 文章();
                f.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into forum values(@writer,getdate(),@headline,@content,0,@kind)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@writer", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@headline", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@content", SqlDbType.Text);
            cmd.Parameters.Add("@kind", SqlDbType.NVarChar, 30);
            cmd.Parameters["@writer"].Value = Class1.用户名;
            cmd.Parameters["@headline"].Value = uiTextBox1.Text;
            cmd.Parameters["@content"].Value = uiRichTextBox1.Text;
            cmd.Parameters["@kind"].Value = comboBox1.Text;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("发布成功", "提示");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "失败");
            }
            finally
            {
                conn.Close();
            }//发布文章
            SqlCommand cmd1 = new SqlCommand("talk1", conn);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter ad = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            uiDataGridView1.DataSource = dt;//更新
        }

        private void uiTextBox2_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("talk2", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@keyword", SqlDbType.VarChar, 50).Value = uiTextBox2.Text;
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            uiDataGridView1.DataSource = dt;//根据文本查找
        }

        private void uiTextBox3_TextChanged(object sender, EventArgs e)
        {
            string a = uiTextBox3.Text;
            string sql = @"select forum.headline 标题,writer 作者,kind 类别,collect.times 收藏时间 from forum,collect where forum.headline=collect.headline and 
                        collect.username='" + Class1.用户名 + "'and (collect.headline like '%" + a + "%' or forum.writer like '%" + a + "%' or forum.kind like '%" + a + "%')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            uiDataGridView2.DataSource = dt;//根据文本查找
        }

        private void 取消收藏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (uiDataGridView2.CurrentRow.Cells[0].Value.ToString() == string.Empty)
                MessageBox.Show("请选择取消收藏的一篇文章", "提示");
            else
            {
                String sql = "delete from collect where headline='" + uiDataGridView2.CurrentRow.Cells[0].Value.ToString() + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("您已取消收藏", "提示");
            }//取消收藏
            string sql2 = "select forum.headline 标题,writer 作者,kind 类别,collect.times 收藏时间 from forum,collect where forum.headline=collect.headline and collect.username='" + Class1.用户名 + "'";
            SqlCommand cmd2 = new SqlCommand(sql2, conn);
            SqlDataAdapter ad2 = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            ad2.Fill(dt);
            uiDataGridView2.DataSource = dt;//更新
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            string sql = "select * from users where 用户名='" + Class1.用户名 + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable ds = new DataTable();
            da.Fill(ds);
            DataRow newrow = ds.NewRow();
            ds.Rows[0][0] = Class1.用户名;
            ds.Rows[0][1] = uiTextBox9.Text;
            ds.Rows[0][2] = uiTextBox4.Text;
            ds.Rows[0][3] = comboBox2.Text;
            ds.Rows[0][4] = comboBox3.Text;
            ds.Rows[0][5] = uiTextBox5.Text;
            ds.Rows[0][6] = uiTextBox6.Text;
            ds.Rows[0][7] = uiTextBox7.Text;
            ds.Rows[0][8] = uiTextBox8.Text;
            try
            {
                SqlCommandBuilder bd = new SqlCommandBuilder(da);
                da.Update(ds);
                MessageBox.Show("个人信息修改成功", "提示");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "失败");
            }//信息更改
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            Form f6 = new Form1();//商务车购买
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            轿车 f = new 轿车();
            f.Show();//轿车购买
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();//suv购买
        }

        private void uiTabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            string sql = "select forum.headline 标题,writer 作者,kind 类别,collect.times 收藏时间 from forum,collect where forum.headline=collect.headline and collect.username='" + Class1.用户名 + "'";
            SqlCommand cmd1 = new SqlCommand(sql, conn);
            SqlDataAdapter ad1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            ad1.Fill(dt1);
            uiDataGridView2.DataSource = dt1;//收藏栏
            string sql订单 = @"select 订单编号,汽车名称,总价,下单时间,支付状态 from order1
                              where 用户名=@用户名";
            SqlCommand cmd订单 = new SqlCommand(sql订单, conn);
            cmd订单.Parameters.Add("@用户名", SqlDbType.NVarChar, 20).Value = Class1.用户名;
            SqlDataAdapter ad订单 = new SqlDataAdapter(cmd订单);
            DataTable dt订单 = new DataTable();
            ad订单.Fill(dt订单);
            uiDataGridView3.DataSource = dt订单;//交易记录更新
        }

        private void 详情ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class1.订单号 = uiDataGridView3.CurrentRow.Cells[0].Value.ToString();
            new 订单详情().Show();
            Form f6 = new 订单详情();//查看订单详情
        }

        private void uiContextMenuStrip3_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 报修ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class1.订单号 = uiDataGridView3.CurrentRow.Cells[0].Value.ToString();
            new 报修().Show();
            Form f6 = new 报修();//进入报修
        }

        private void tabPage9_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void uiTabControlMenu2_MouseClick(object sender, MouseEventArgs e)
        {
            string sql反馈 = @"select  order1.订单编号 订单编号,反馈编号,类型,内容, 是否回复 from order1,baoxiu 
                             where order1.订单编号 =baoxiu.订单编号 and order1.用户名=@用户名";
            SqlCommand cmd反馈 = new SqlCommand(sql反馈, conn);
            cmd反馈.Parameters.Add("@用户名", SqlDbType.NVarChar, 20).Value = Class1.用户名;
            SqlDataAdapter ad反馈 = new SqlDataAdapter(cmd反馈);
            DataTable dt反馈 = new DataTable();
            ad反馈.Fill(dt反馈);
            uiDataGridView4.DataSource = dt反馈;//查看保修信息
        }

        private void 查看回复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class1.反馈编号 = uiDataGridView4.CurrentRow.Cells[1].Value.ToString();
            new 反馈().Show();
            Form f6 = new 反馈();//查看反馈详情
        }
        //private void uiButton2_Click(object sender, EventArgs e)
        //{
        //    index++;
        //    if (index == 3)
        //    {
        //        index = 0;//如果下标正好等于数组大小，说明超了，就赋个0，从头开始 if(index == imageList1.Images.Count)
        //    }
        //    pictureBox4.Image = images[index];
         
        //    //C:\Users\Administrator\Desktop\i - car1\bin\Debug\0.jpg
        //}
        //private void uiButton1_Click_1(object sender, EventArgs e)
        //{
        //    index--;
        //    if (index < 0)
        //    {
        //        index = 2;//如果下标正好等于数组大小，说明超了，就赋个0，从头开始 if(index == imageList1.Images.Count)
        //    }
        //    pictureBox4.Image = images[index];
        //}
        private void uiButton4_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                new Form1().Show();
                Form f6 = new Form1();
                Class1.汽车品牌 = "埃尔法";
            }
            if (index == 1)
            {
                轿车 f = new 轿车();
                f.Show();
                Class1.汽车品牌 = "伊兰特";
            }
            if (index == 2)
            {
                Form3 f = new Form3();
                f.Show();
                Class1.汽车品牌 = "奥迪Q8";
            }//根据照片进入选配页面
        }
        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            index--;
            if (index < 0)
            {
                index = 2;//如果下标正好等于数组大小，说明超了，就赋个0，从头开始 if(index == imageList1.Images.Count)
            }
            pictureBox4.Image = images[index];
        }
        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            index++;
            if (index == 3)
            {
                index = 0;//如果下标正好等于数组大小，说明超了，就赋个0，从头开始 if(index == imageList1.Images.Count)
            }
            pictureBox4.Image = images[index];
            //循环播放
            //C:\Users\Administrator\Desktop\i - car1\bin\Debug\0.jpg
            //this.BackgroundImage = Properties.Resources.myPic;
        }
        private void uiButton1_Click_2(object sender, EventArgs e)
        {
            string sql = "insert into forum values(@writer,getdate(),@headline,@content,0,@kind)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@writer", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@headline", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@content", SqlDbType.Text);
            cmd.Parameters.Add("@kind", SqlDbType.NVarChar, 30);
            cmd.Parameters["@writer"].Value = Class1.用户名;
            cmd.Parameters["@headline"].Value = uiTextBox1.Text;
            cmd.Parameters["@content"].Value = uiRichTextBox1.Text;
            cmd.Parameters["@kind"].Value = comboBox1.Text;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("发布成功", "提示");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "失败");
            }
            finally
            {
                conn.Close();
            }
            SqlCommand cmd1 = new SqlCommand("talk1", conn);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter ad = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            uiDataGridView1.DataSource = dt;
        }

        private void uiSymbolButton3_Click_1(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.Show();//智能选配
        }

        private void 投诉ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("投诉请保存好相关信息\r\n24小时投诉热线：021-26382638\r\n邮箱：shanghaidazhong@163.com");
        }

        private void uiLabel5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void uiTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiTextBox1_Click(object sender, EventArgs e)
        {
            if (uiTextBox1.Text == "标题输入不超过50字")
            {
                uiTextBox1.Text = "";
                uiTextBox1.ForeColor = Color.Black;
            }
            else
            { }
        }
    }
}
