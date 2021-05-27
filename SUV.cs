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
using i_car1;

namespace i_car3
{
    public partial class Form3 : Form
    {
        public static Form3 SUV;
        int c = 6;
        int speed = 60;  //全局变量
        SqlConnection conn;
        string constr = @"server=.\sqlexpress;database=2021040614;Integrated Security=true;";
        public Form3()
        {
            InitializeComponent();
            conn = new SqlConnection(constr);
            SUV = this;
        }

        private void uiImageButton1_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.ShowDialog();
            SqlConnection conn = new SqlConnection(constr);
        }

        private void uiImageButton2_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.ShowDialog();
        }

        private void uiImageButton3_MouseDown(object sender, MouseEventArgs e)
        {
            speed = 60;  //左转
            timer1.Enabled = true;
        }

        private void uiImageButton3_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
        }

        private void uiImageButton4_MouseDown(object sender, MouseEventArgs e)
        {
            speed = -60;  //左转
            timer1.Enabled = true;
        }

        private void uiImageButton4_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
        }

        private void uiRadioButton1_ValueChanged(object sender, bool value)
        {
            c = 1;
            timer1.Enabled = true;
            changecolor();
        }

        private void uiRadioButton3_ValueChanged(object sender, bool value)
        {
            c = 2;
            timer1.Enabled = true;
            changecolor();
        }

        private void uiRadioButton5_ValueChanged(object sender, bool value)
        {
            c = 3;
            timer1.Enabled = true;
            changecolor();
        }

        private void uiRadioButton2_ValueChanged(object sender, bool value)
        {
            c = 4;
            timer1.Enabled = true;
            changecolor();
        }

        private void uiRadioButton4_ValueChanged(object sender, bool value)
        {
            c = 5;
            timer1.Enabled = true;
            changecolor();
        }

        private void uiRadioButton6_ValueChanged(object sender, bool value)
        {
            c = 6;
            timer1.Enabled = true;
            changecolor();
        }

        private void changecolor()
        {
            axUnityWebPlayer1.SendMessage("carpaint_antena", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("carpaint_body_l", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("carpaint_body_r", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("carpaint_bumper_f", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("carpaint_bumper_grill", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("carpaint_bumper_top", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("carpaint_doors_f", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("carpaint_doors_r", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("carpaint_fenders_f", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("carpaint_hood", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("carpaint_mirrors", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("carpaint_roof", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("carpaint_tailgate", "colorchangeC", c);
            axUnityWebPlayer1.SendMessage("carpaint_tailgate_top", "colorchangeC", c);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            axUnityWebPlayer1.SendMessage("AudiQ8_2019_hi", "rotateX", speed);
        }
        int index = 0;
        ImageList il = new ImageList();
        private void Form3_Load(object sender, EventArgs e)
        {
            il = imageList1;
            pictureBox24.Image = il.Images[0];

            //默认选项
            uiRadioButton19.Checked = true;//发动机
            uiRadioButton1.Checked = true;// 车的颜色
            uiRadioButton13.Checked = true;//轮毂颜色
            uiRadioButton7.Checked = true;//天窗
            uiRadioButton9.Checked = true;//车的颜色
            uiRadioButton22.Checked = true;//风格颜色
            //默认座位颜色预览
            il = imageList1;
            pictureBox24.Image = il.Images[index];
            uiRadioButton26.Checked = true;//真皮装备包
            uiRadioButton28.Checked = true;//真皮装备包
            uiRadioButton10.Checked = true;//后视镜
            uiCheckBox30.Checked = true;//照明
            uiCheckBox43.Checked = true;//照明
            uiCheckBox45.Checked = true;//照明
            uiCheckBox30.Enabled = false;
            uiCheckBox43.Enabled = false;
            uiCheckBox45.Enabled = false;
            uiCheckBox11.Checked = true;//娱乐
            uiCheckBox9.Checked = true;//娱乐
            uiCheckBox14.Checked = true;//娱乐
            uiCheckBox11.Enabled = false;//娱乐
            uiCheckBox9.Enabled = false;//娱乐
            uiCheckBox14.Enabled = false;//娱乐
            uiCheckBox19.Checked = true;//娱乐
            //生产订单号
            Class1.订单号 = Class1.姓名 + DateTime.Now.ToFileTimeUtc().ToString();
            uiLabel14.Text = Class1.订单号; 
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            il = imageList1;
            pictureBox24.Image = il.Images[index];
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            il = imageList2;
            pictureBox24.Image = il.Images[index];
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            il = imageList3;
            pictureBox24.Image = il.Images[index];
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            il = imageList4;
            pictureBox24.Image = il.Images[index];
        }

        private void uiImageButton7_Click(object sender, EventArgs e)
        {
            index--;
            if (index < 0)
            {
                index = il.Images.Count - 1;//如果下标正好等于数组大小，说明超了，就赋个0，从头开始 if(index == imageList1.Images.Count)
            }
            pictureBox24.Image = il.Images[index];
        }

        private void uiImageButton5_Click(object sender, EventArgs e)
        {
            index++;
            if (index == il.Images.Count)
            {
                index = 0;//如果下标正好等于数组大小，说明超了，就赋个0，从头开始 if(index == imageList1.Images.Count)
            }
            pictureBox24.Image = il.Images[index];
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            index++;
            if (index == il.Images.Count)
            {
                index = 0;//如果下标正好等于数组大小，说明超了，就赋个0，从头开始 if(index == imageList1.Images.Count)

            }
            pictureBox24.Image = il.Images[index];
        }

        private void uiContextMenuStrip1_Opening(object sender, CancelEventArgs e)
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
        }

        //自定义参数输入函数（radiobutton6:）
        private void setpara(UIRadioButton uIRadioButton) 
        {
            if (uIRadioButton.Checked)
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
            }
        }

        //自定义参数输入函数（checkbox）
        private void setpara1(UICheckBox uICheckBox)
        {
            if (uICheckBox.Checked)
            {
                string sql1 = @"select 零件编号 from components where 零件名称=@零件名称";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@零件名称", SqlDbType.NVarChar, 100).Value = uICheckBox.Text;
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
        }


        private void uiImageButton11_Click(object sender, EventArgs e)
        {
            //先删除旧表orderparts
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
            //再删除旧表order1
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
            //插入order1
            string sql0 = @"insert into order1(订单编号,用户名,汽车名称,颜色,下单时间)
                          values(@订单编号,@用户名,@汽车名称,@颜色,@下单时间)";
            SqlCommand cmd0 = new SqlCommand(sql0, conn);
            cmd0.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
            cmd0.Parameters.Add("@用户名", SqlDbType.NVarChar, 50).Value = Class1.用户名;
            cmd0.Parameters.Add("@汽车名称", SqlDbType.NVarChar, 50).Value = "奥迪Q8";
            if (uiRadioButton1.Checked)
                 Class1.颜色 = uiRadioButton1.Text;
            else if (uiRadioButton2.Checked)
                 Class1.颜色 = uiRadioButton2.Text;
            else if (uiRadioButton3.Checked)
                 Class1.颜色 = uiRadioButton3.Text;
            else if (uiRadioButton4.Checked)
                 Class1.颜色 = uiRadioButton4.Text;
            else if (uiRadioButton5.Checked)
                 Class1.颜色 = uiRadioButton5.Text;
            else if (uiRadioButton6.Checked)
                 Class1.颜色 = uiRadioButton6.Text;
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

            //参数输入
            foreach (Control control in this.Controls)
            {
                if (control is UIRadioButton)
                {
                    UIRadioButton ur = (UIRadioButton)control;
                    setpara(ur);
                }
            }

            setpara(uiRadioButton7);
            setpara(uiRadioButton8);
            setpara(uiRadioButton9);
            setpara(uiRadioButton10);
            setpara(uiRadioButton11);
            setpara(uiRadioButton12);
            setpara(uiRadioButton13);
            setpara(uiRadioButton14);
            setpara(uiRadioButton15);
            setpara(uiRadioButton16);
            setpara(uiRadioButton17);
            setpara(uiRadioButton18);
            setpara(uiRadioButton19);
            setpara(uiRadioButton20);
            setpara(uiRadioButton21);
            setpara(uiRadioButton22);
            setpara(uiRadioButton23);
            setpara(uiRadioButton24);
            setpara(uiRadioButton25);
            setpara(uiRadioButton26);
            setpara(uiRadioButton27);
            setpara(uiRadioButton28);
            setpara(uiRadioButton29);
            setpara1(uiCheckBox10);
            setpara1(uiCheckBox11);
            setpara1(uiCheckBox12);
            setpara1(uiCheckBox13);
            setpara1(uiCheckBox14);
            setpara1(uiCheckBox15);
            setpara1(uiCheckBox16);
            setpara1(uiCheckBox17);
            setpara1(uiCheckBox18);
            setpara1(uiCheckBox19);
            setpara1(uiCheckBox20);
            setpara1(uiCheckBox21);
            setpara1(uiCheckBox22);
            setpara1(uiCheckBox23);
            setpara1(uiCheckBox24);
            setpara1(uiCheckBox25);
            setpara1(uiCheckBox26);
            setpara1(uiCheckBox27);
            setpara1(uiCheckBox28);
            setpara1(uiCheckBox29);
            setpara1(uiCheckBox30);
            setpara1(uiCheckBox31);
            setpara1(uiCheckBox32);
            setpara1(uiCheckBox33);
            setpara1(uiCheckBox34);
            setpara1(uiCheckBox35);
            setpara1(uiCheckBox36);
            setpara1(uiCheckBox37);
            setpara1(uiCheckBox38);
            setpara1(uiCheckBox39);
            setpara1(uiCheckBox40);
            setpara1(uiCheckBox41);
            setpara1(uiCheckBox42);
            setpara1(uiCheckBox43);
            setpara1(uiCheckBox44);
            setpara1(uiCheckBox45);
            setpara1(uiCheckBox46);
            setpara1(uiCheckBox47);
            setpara1(uiCheckBox48);
            setpara1(uiCheckBox49);
            setpara1(uiCheckBox50);
            setpara1(uiCheckBox51);
            setpara1(uiCheckBox52);

            string sqlm = @"select 零件种类,零件名称,价格 from components,orderparts
                           where components.零件编号=orderparts.零件编号
                           and 订单编号=@订单编号 order by 价格";
            SqlCommand cmdm = new SqlCommand(sqlm, conn);
            cmdm.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
            SqlDataAdapter ad = new SqlDataAdapter(cmdm);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            uiDataGridView1.DataSource = dt;

            //总价计算
            string sqlprice = @"select 基础价格 from cars where 汽车名称='奥迪Q8'";
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
            uiLabel17.Text =  price2.ToString() + "元";
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
        }//选配过程

        private void uiImageButton15_Click(object sender, EventArgs e)
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
                           and 订单编号=@订单编号 order by 价格" ;
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
            uiLabel17.Text =  price2.ToString() + "元";
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
        }//删除已选零件并更新

        private void uiImageButton13_Click(object sender, EventArgs e)
        {
            new 说明().Show();
            Form f6 = new 说明();
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
                           and 订单编号=@订单编号 order by 价格";
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
            uiLabel17.Text = price2.ToString() + "元";
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
            }//删除订单
        }

        private void axUnityWebPlayer1_OnExternalCall(object sender, AxUnityWebPlayerAXLib._DUnityWebPlayerAXEvents_OnExternalCallEvent e)
        {

        }

        private void uiRadioButton14_ValueChanged(object sender, bool value)
        {

        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {

        }
    }
}
