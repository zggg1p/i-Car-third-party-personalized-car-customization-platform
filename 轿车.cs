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
using Sunny.UI;
using System.Runtime.Serialization.Formatters.Binary;

namespace i_car1
{
    public partial class 轿车 : Form
    {
        public static 轿车 jc;
        private void setpara(UIRadioButton uIRadioButton)
        {
            string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
            SqlCommand cmd = new SqlCommand(sql1, conn);
            cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uIRadioButton.Text;
            try
            {
                conn.Open();
                Class1.零件编号 = cmd.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "失败");
            }
            finally
            {
                conn.Close();
            }
            string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
            SqlCommand cmd2 = new SqlCommand(sql2, conn);
            cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
            cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
            try
            {
                conn.Open();
                cmd2.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "失败");
            }
            finally
            {
                conn.Close();
            }
        }//选配过程
        public SqlConnection conn;
        public 轿车()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            string constr = @"Server=.\sqlexpress;Database=2021040614;Integrated security=True;";
            conn = new SqlConnection(constr);
            jc = this;
        }
        float x = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            axUnityWebPlayer1.SendMessage("MAZDA6", "rotateX", x);
        }

        private void uiButton1_MouseDown(object sender, MouseEventArgs e)
        {
            x = 2;
            timer1.Enabled = true;
        }

        private void uiButton1_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
        }

        private void uiButton2_MouseDown(object sender, MouseEventArgs e)
        {
            x = -2;
            timer1.Enabled = true;
        }

        private void uiButton2_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            uiComboboxEx1.SelectedIndex = 0;
            uiComboboxEx2.SelectedIndex = 0;
            uiComboboxEx3.SelectedIndex = 0;
            uiRadioButton1.Checked = true;
            uiRadioButton3.Checked = true;
            uiRadioButton11.Checked = true;
            uiRadioButton12.Checked = true;
            uiRadioButton13.Checked = true;
            uiRadioButton7.Checked = true;
            uiRadioButton9.Checked = true;
            Class1.订单号 = Class1.姓名 + DateTime.Now.ToFileTimeUtc().ToString();
            label78.Text = Class1.订单号;
        }

        private void uiComboboxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c = 1;
            if (uiComboboxEx1.Text == "雪白色") { c = 1; }
            if (uiComboboxEx1.Text == "银色") { c = 2; }
            if (uiComboboxEx1.Text == "黑色") { c = 3; }
            if (uiComboboxEx1.Text == "粉色") { c = 4; }
            if (uiComboboxEx1.Text == "深红色") { c = 5; }
            if (uiComboboxEx1.Text == "浅蓝色") { c = 6; }
            if (uiComboboxEx1.Text == "深蓝色") { c = 7; }
            if (uiComboboxEx1.Text == "橘黄色") { c = 8; }
            if (uiComboboxEx1.Text == "灰色") { c = 9; }
            if (uiComboboxEx1.Text == "浅绿色") { c = 10; }
            axUnityWebPlayer1.SendMessage("luntai_01", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("luntai_02", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("luntai_03", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("luntai_04", "colorchangeC", c);
        }

        private void uiComboboxEx2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c = 1;
            if (uiComboboxEx2.Text == "雪白色") { c = 1; }
            if (uiComboboxEx2.Text == "银色") { c = 2; }
            if (uiComboboxEx2.Text == "黑色") { c = 3; }
            if (uiComboboxEx2.Text == "粉色") { c = 4; }
            if (uiComboboxEx2.Text == "深红色") { c = 5; }
            if (uiComboboxEx2.Text == "浅蓝色") { c = 6; }
            if (uiComboboxEx2.Text == "深蓝色") { c = 7; }
            if (uiComboboxEx2.Text == "橘黄色") { c = 8; }
            if (uiComboboxEx2.Text == "灰色") { c = 9; }
            if (uiComboboxEx2.Text == "浅绿色") { c = 10; }
            axUnityWebPlayer1.SendMessage("qianlian_01", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("qianlian_02", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("qianlian_03", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("door_01", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("door_02", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("door_03", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("door_04", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("weibu_01", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("weibu_02", "colorchangeC", c);
        }

        private void uiComboboxEx3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c = 1;
            if (uiComboboxEx3.Text == "雪白色") { c = 1; }
            if (uiComboboxEx3.Text == "银色") { c = 2; }
            if (uiComboboxEx3.Text == "黑色") { c = 3; }
            if (uiComboboxEx3.Text == "粉色") { c = 4; }
            if (uiComboboxEx3.Text == "深红色") { c = 5; }
            if (uiComboboxEx3.Text == "浅蓝色") { c = 6; }
            if (uiComboboxEx3.Text == "深蓝色") { c = 7; }
            if (uiComboboxEx3.Text == "橘黄色") { c = 8; }
            if (uiComboboxEx3.Text == "灰色") { c = 9; }
            if (uiComboboxEx3.Text == "浅绿色") { c = 10; }
            axUnityWebPlayer1.SendMessage("mirrors", "colorchangeC", c);
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.Show();
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            f.Show();
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            string sql删除 = @"delete from orderparts where 订单编号=@订单编号";
            SqlCommand cmd删除 = new SqlCommand(sql删除, conn);
            cmd删除.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
            try
            {
                conn.Open();
                cmd删除.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "失败");
            }
            finally
            {
                conn.Close();
            }
            string sql删除2 = @"delete from order1 where 订单编号=@订单编号";
            SqlCommand cmd删除2 = new SqlCommand(sql删除2, conn);
            cmd删除2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
            try
            {
                conn.Open();
                cmd删除2.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "失败");
            }
            finally
            {
                conn.Close();
            }
            string sql0 = @"insert into order1(订单编号,用户名,汽车名称,颜色,下单时间)
                          values(@订单编号,@用户名,@汽车名称,@颜色,@下单时间)";
            SqlCommand cmd0 = new SqlCommand(sql0, conn);
            cmd0.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
            cmd0.Parameters.Add("@用户名", SqlDbType.NVarChar, 50).Value = Class1.用户名;
            cmd0.Parameters.Add("@汽车名称", SqlDbType.NVarChar, 50).Value = "伊兰特";
            Class1.颜色 = uiComboboxEx2.Text;
            cmd0.Parameters.Add("@颜色", SqlDbType.NVarChar, 50).Value = Class1.颜色;
            cmd0.Parameters.Add("@下单时间", SqlDbType.NVarChar, 50).Value = DateTime.Now.ToString();
            try
            {
                conn.Open();
                cmd0.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "失败");
            }
            finally
            {
                conn.Close();
            }
            if (uiRadioButton1.Checked)
            {
                setpara(uiRadioButton1);
            }
            if (uiRadioButton2.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiRadioButton2.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiRadioButton3.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiRadioButton3.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiRadioButton4.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiRadioButton4.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiRadioButton5.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiRadioButton5.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiRadioButton6.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiRadioButton6.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiRadioButton7.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiRadioButton7.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiRadioButton8.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiRadioButton8.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiRadioButton9.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiRadioButton9.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiRadioButton10.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiRadioButton10.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiRadioButton11.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiRadioButton11.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiRadioButton12.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiRadioButton12.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiRadioButton13.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiRadioButton13.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiRadioButton14.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiRadioButton14.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiRadioButton15.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiRadioButton15.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiRadioButton16.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiRadioButton16.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiRadioButton17.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiRadioButton17.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiRadioButton18.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiRadioButton18.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox1.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox1.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox2.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox2.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox3.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox3.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox4.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox4.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox5.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox5.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox6.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox6.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox7.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox7.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox8.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox8.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox9.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox9.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox10.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox10.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox11.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox11.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox12.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox12.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox13.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox13.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox14.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox14.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox15.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox15.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox16.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox16.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox17.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox17.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox18.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox18.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox19.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox19.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox20.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox20.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox21.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox21.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox22.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox22.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox23.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox23.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox24.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox24.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox25.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox25.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox26.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox26.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox27.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox27.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox28.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox28.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox29.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox29.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox30.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox30.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox31.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox31.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox32.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox32.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox33.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox33.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox34.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox34.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox35.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox35.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox36.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox36.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox37.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox37.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox38.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox38.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox39.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox39.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox40.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox40.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox41.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox41.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox42.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox42.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox43.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox43.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiCheckBox44.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiCheckBox44.Text;
                try
                {
                    conn.Open();
                    Class1.零件编号 = cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiComboboxEx1.Text!="")
            {
                string a = "20003";
                if (uiComboboxEx1.Text == "雪白色") a = "20003";
                else if (uiComboboxEx1.Text == "银色") a = "20004";
                else if (uiComboboxEx1.Text == "黑色") a = "20005";
                else if (uiComboboxEx1.Text == "粉色") a = "20006";
                else if (uiComboboxEx1.Text == "深红色") a = "20007";
                else if (uiComboboxEx1.Text == "浅蓝色") a = "20008";
                else if (uiComboboxEx1.Text == "深蓝色") a = "20009";
                else if (uiComboboxEx1.Text == "橘黄色") a = "20010";
                else if (uiComboboxEx1.Text == "灰色") a = "20011";
                else if (uiComboboxEx1.Text == "浅绿色") a = "20012";
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = a;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            if (uiComboboxEx3.Text != "")
            {
                string b = "20013";
                if (uiComboboxEx3.Text == "雪白色") b = "20013";
                else if (uiComboboxEx3.Text == "银色") b = "20014";
                else if (uiComboboxEx3.Text == "黑色") b = "20015";
                else if (uiComboboxEx3.Text == "粉色") b = "20016";
                else if (uiComboboxEx3.Text == "深红色") b = "20017";
                else if (uiComboboxEx3.Text == "浅蓝色") b = "20018";
                else if (uiComboboxEx3.Text == "深蓝色") b = "20019";
                else if (uiComboboxEx3.Text == "橘黄色") b = "20020";
                else if (uiComboboxEx3.Text == "灰色") b = "20021";
                else if (uiComboboxEx3.Text == "浅绿色") b = "20022";
                string sql2 = @"insert into orderparts
                               values(@订单编号,@零件编号)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = b;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            string sqlm = @"select 零件种类,零件名称,价格 from components,orderparts
                           where components.零件编号=orderparts.零件编号
                           and 订单编号=@订单编号";
            SqlCommand cmdm = new SqlCommand(sqlm, conn);
            cmdm.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
            SqlDataAdapter ad = new SqlDataAdapter(cmdm);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            uiDataGridView1.DataSource = dt;
            string sqlprice = @"select 基础价格 from cars where 汽车名称='伊兰特'";
            SqlCommand cmdprice = new SqlCommand(sqlprice, conn);
            try
            {
                conn.Open();
                Class1.基础价格 = int.Parse(cmdprice.ExecuteScalar().ToString());
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "失败");
            }
            finally
            {
                conn.Close();
            }
            int c = dt.Rows.Count;
            int price2 = 0;
            for (int i = 0; i < c; i++)
            {
                price2 += int.Parse(dt.Rows[i][2].ToString());
            }
            price2 = price2 + Class1.基础价格;
            Class1.总价 = price2;
            label79.Text = "总价为" + price2.ToString() + "元";
            string sql总价 = @"update order1 set 总价 =@总价 where 订单编号=@订单编号";
            SqlCommand cmd总价 = new SqlCommand(sql总价, conn);
            cmd总价.Parameters.Add("@总价", SqlDbType.Int).Value = Class1.总价;
            cmd总价.Parameters.Add("@订单编号", SqlDbType.NVarChar, 255).Value = Class1.订单号;
            try
            {
                conn.Open();
                cmd总价.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "失败");
            }
            finally
            {
                conn.Close();
            }

        }//选配过程及显示

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
            SqlCommand cmd = new SqlCommand(sql1, conn);
            cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiDataGridView1.CurrentRow.Cells[1].Value.ToString();
            try
            {
                conn.Open();
                Class1.零件编号 = cmd.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "失败");
            }
            finally
            {
                conn.Close();
            }
            string sql2 = @"delete from orderparts where 订单编号=@订单编号 and 零件编号=@零件编号";
            SqlCommand cmd2 = new SqlCommand(sql2, conn);
            cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
            cmd2.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = Class1.零件编号;
            try
            {
                conn.Open();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("删除成功");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "失败");
            }
            finally
            {
                conn.Close();
            }
            string sqlm = @"select 零件种类,零件名称,价格 from components,orderparts
                           where components.零件编号=orderparts.零件编号
                           and 订单编号=@订单编号";
            SqlCommand cmdm = new SqlCommand(sqlm, conn);
            cmdm.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
            SqlDataAdapter ad = new SqlDataAdapter(cmdm);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            uiDataGridView1.DataSource = dt;
            int c = dt.Rows.Count;
            int price2 = 0;
            for (int i = 0; i < c; i++)
            {
                price2 += int.Parse(dt.Rows[i][2].ToString());
            }
            price2 = price2 + Class1.基础价格;
            Class1.总价 = price2;
            label79.Text = "总价为" + price2.ToString() + "元";
            string sql总价 = @"update order1 set 总价 =@总价 where 订单编号=@订单编号";
            SqlCommand cmd总价 = new SqlCommand(sql总价, conn);
            cmd总价.Parameters.Add("@总价", SqlDbType.Int).Value = Class1.总价;
            cmd总价.Parameters.Add("@订单编号", SqlDbType.VarChar, 20).Value = Class1.订单号;
            try
            {
                conn.Open();
                cmd总价.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
               MessageBox.Show(ex.ToString(), "失败");
            }
            finally
            {
               conn.Close();
            }
        }

        private void uiButton6_Click(object sender, EventArgs e)
        {
            DialogResult dr;

            dr = MessageBox.Show("确定取消订单吗？", "取消提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.Yes)
            {
                string sql2 = @"delete from orderparts where 订单编号=@订单编号";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                try
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("删除成功");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
                string sqlm = @"select 零件种类,零件名称,价格 from components,orderparts
                           where components.零件编号=orderparts.零件编号
                           and 订单编号=@订单编号";
                SqlCommand cmdm = new SqlCommand(sqlm, conn);
                cmdm.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                SqlDataAdapter ad = new SqlDataAdapter(cmdm);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                uiDataGridView1.DataSource = dt;
                label79.Text = "总价为0元";
                string sql删除2 = @"delete from order1 where 订单编号=@订单编号";
                SqlCommand cmd删除2 = new SqlCommand(sql删除2, conn);
                cmd删除2.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                try
                {
                    conn.Open();
                    cmd删除2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            { }
        }

        private void uiButton7_Click(object sender, EventArgs e)
        {
            new 说明().Show();
            Form f6 = new 说明();
        }
        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void uiCheckBox19_ValueChanged(object sender, bool value)
        {

        }
    }
}
