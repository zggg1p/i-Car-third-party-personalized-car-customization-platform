using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;
using i_car1;
namespace yxh
{
    public partial class Form1 : Form
    {
        public SqlConnection conn;
        public static Form1 sw;
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            string constr = @"Server=.\sqlexpress;Database=2021040614;Integrated security=True;";
            conn = new SqlConnection(constr);
            sw = this;
        }
        float x = 0;
        int c = 6;
        private void uiGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            new Form4().Show();
            Form f4 = new Form4();//详情
        }


        private void uiButton2_MouseDown(object sender, MouseEventArgs e)
        {
            x = 2;  //左转
            timer1.Enabled = true;
        }

        private void uiButton2_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
        }

        private void uiButton3_MouseDown(object sender, MouseEventArgs e)
        {
            x = -2;  //右转
            timer1.Enabled = true;
        }

        private void uiButton3_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
        }

        private void uiRadioButton1_ValueChanged(object sender, bool value)
        {
            c = 1;
            changecolor();
            Class1.颜色 = uiRadioButton1.Text;
        }

        private void uiRadioButton4_ValueChanged(object sender, bool value)
        {
            c = 2;
            changecolor();
            Class1.颜色 = uiRadioButton4.Text;
        }

        private void uiRadioButton5_ValueChanged(object sender, bool value)
        {
            c = 3;
            changecolor();
            Class1.颜色 = uiRadioButton5.Text;
        }

        private void uiRadioButton2_ValueChanged(object sender, bool value)
        {
            c = 4;
            changecolor();
            Class1.颜色 = uiRadioButton2.Text;
        }

        private void uiRadioButton3_ValueChanged(object sender, bool value)
        {
            c = 5;
            changecolor();
            Class1.颜色 = uiRadioButton3.Text;
        }

        private void uiRadioButton6_ValueChanged(object sender, bool value)
        {
            c = 6;
            changecolor();
            Class1.颜色 = uiRadioButton6.Text;
        }
        private void changecolor()
        {
            axUnityWebPlayer1.SendMessage("body_rear_wing", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("body_rear_wing_L", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("body_rear_wing_R", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("detail_mirror", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("detail_parktronic_front", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("door_front_left", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("door_front_left_door_handle", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("door_front_left_side_backward_mirror_body", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("door_front_R", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("door_front_R_door_handle", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("door_front_R_side_backward_mirror_body", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("door_rear_left", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("door_rear_left_door_handle", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("door_rear_R", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("door_rear_R_door_handle", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("Fender_rear", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("tailgate01", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("Fender_rear_MeshPart0", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("Fender_rear_MeshPart1", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("Fender_rear_MeshPart2", "colorchangeC", c);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            axUnityWebPlayer1.SendMessage("Toyota_Vellfire_(Mk2)_Aero_HQinterior_2015", "rotateX", x);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            uiRadioButton7.Checked = true;
            uiRadioButton12.Checked = true;
            uiRadioButton16.Checked = true;
            uiRadioButton18.Checked = true;
            Class1.订单号 = Class1.姓名 + DateTime.Now.ToFileTimeUtc().ToString();
            pictureBox15.Image = i_car1.Properties.Resources.亚麻色优质真皮合成皮;
            pictureBox14.Image = i_car1.Properties.Resources.第二排电动Ottoman宽适旗舰座椅;
        }

        private void uiRadioButton18_ValueChanged(object sender, bool value)
        {
            pictureBox15.Image = i_car1.Properties.Resources.亚麻色优质真皮合成皮;
        }

        private void uiRadioButton19_ValueChanged(object sender, bool value)
        {
            pictureBox15.Image = i_car1.Properties.Resources.亚麻色高级Nappa真皮合成皮;
        }

        private void uiRadioButton20_ValueChanged(object sender, bool value)
        {
            pictureBox15.Image = i_car1.Properties.Resources.黑色高级Nappa真皮合成皮;
        }

        private void uiCheckBox1_ValueChanged(object sender, bool value)
        {
            pictureBox14.Image = i_car1.Properties.Resources.第二排电动Ottoman宽适旗舰座椅;
        }

        private void uiCheckBox2_ValueChanged(object sender, bool value)
        {
            pictureBox14.Image = i_car1.Properties.Resources.可伸缩电动腿托可调节头枕全倾倒功能;
        }

        private void uiCheckBox3_ValueChanged(object sender, bool value)
        {
            pictureBox14.Image = i_car1.Properties.Resources.座椅通风及加热;
        }

        private void uiCheckBox4_ValueChanged(object sender, bool value)
        {
            pictureBox14.Image = i_car1.Properties.Resources.独立手枕控制面板;
        }
        private void uiButton4_Click(object sender, EventArgs e)
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
            label1.Text = Class1.订单号;
            string sql0 = @"insert into order1(订单编号,用户名,汽车名称,颜色,下单时间)
                          values(@订单编号,@用户名,@汽车名称,@颜色,@下单时间)";
            SqlCommand cmd0 = new SqlCommand(sql0, conn);
            cmd0.Parameters.Add("@订单编号", SqlDbType.NVarChar,50).Value = Class1.订单号;
            cmd0.Parameters.Add("@用户名", SqlDbType.NVarChar, 50).Value = Class1.用户名;
            cmd0.Parameters.Add("@汽车名称", SqlDbType.NVarChar, 50).Value = "埃尔法";
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
            string sqlF = @"insert into orderparts
                               values(@订单编号,@零件编号)";
            SqlCommand cmdF = new SqlCommand(sqlF, conn);
            cmdF.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
            cmdF.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = "30001";
            try
            {
                conn.Open();
                cmdF.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "失败");
            }
            finally
            {
                conn.Close();
            }
            string sqlB = @"insert into orderparts
                            values(@订单编号,@零件编号)";
            SqlCommand cmdB = new SqlCommand(sqlB, conn);
            cmdB.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
            cmdB.Parameters.Add("@零件编号", SqlDbType.NVarChar, 5).Value = "30002";
            try
            {
                conn.Open();
                cmdB.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "失败");
            }
            finally
            {
                conn.Close();
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
            if (uiRadioButton19.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiRadioButton19.Text;
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
            if (uiRadioButton20.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uiRadioButton20.Text;
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
            string sqlm = @"select 零件种类,零件名称,价格 from components,orderparts
                           where components.零件编号=orderparts.零件编号
                           and 订单编号=@订单编号";
            SqlCommand cmdm = new SqlCommand(sqlm, conn);
            cmdm.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
            SqlDataAdapter ad = new SqlDataAdapter(cmdm);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            uiDataGridView1.DataSource = dt;
            string sqlprice = @"select 基础价格 from cars where 汽车名称='埃尔法'";
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
            label2.Text = "总价为" + price2.ToString() + "元";
            string sql总价 = @"update order1 set 总价 =@总价 where 订单编号=@订单编号";
            SqlCommand cmd总价 = new SqlCommand(sql总价, conn);
            cmd总价.Parameters.Add("@总价", SqlDbType.Int).Value = Class1.总价;
            cmd总价.Parameters.Add("@订单编号", SqlDbType.VarChar, 50).Value = Class1.订单号;
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
            label2.Text = "总价为" + price2.ToString() + "元";
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
        }//选配过程，以及显示

        private void uiButton5_Click(object sender, EventArgs e)
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
                label2.Text = "总价为0元";
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
            {}//取消订单
        }

        private void uiButton6_Click(object sender, EventArgs e)
        {
            new 说明().Show();
            Form f6 = new 说明();//进入说明页面
        }

        private void uiRadioButton12_ValueChanged(object sender, bool value)
        {
            Class1.颜色 = uiRadioButton12.Text;
        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void uiRadioButton8_ValueChanged(object sender, bool value)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void uiCheckBox22_ValueChanged(object sender, bool value)
        {

        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {

        }

        private void uiGroupBox7_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel6_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
