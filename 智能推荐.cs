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

namespace 智能推荐方案
{
    public partial class Form10 : Form
    {
        SqlConnection conn;
        string constr = @"server=.\sqlexpress;database=2021040614;Integrated Security=true;";
        public Form10()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            conn = new SqlConnection(constr);
        }

        //自定义函数：滚动条变化导致textbox变化
        private void uitrackbar(UITrackBar uiTrackBar1,UITextBox uiTextBox1,UITextBox uiTextBox2)
        {
            uiTextBox1.Text = uiTrackBar1.Value.ToString();
            uiTextBox2.Text = (uiTrackBar1.Maximum - uiTrackBar1.Value).ToString();
        }

        //自定义函数：修改其中一个textbox改变对应的滚动条与textbox
        private void left_textchange(UITrackBar uiTrackBar1, UITextBox uiTextBox1, UITextBox uiTextBox2)
        {
            if (uiTextBox1.Text == "")
                uiTextBox1.Text = "1";
            else
                uiTextBox2.Text = (uiTrackBar1.Maximum - int.Parse(uiTextBox1.Text)).ToString();
            uiTrackBar1.Value = int.Parse(uiTextBox1.Text);
        }
        //自定义函数：修改其中一个textbox改变对应的滚动条与textbox
        private void right_textchange(UITrackBar uiTrackBar1, UITextBox uiTextBox1, UITextBox uiTextBox2)
        {
            if (uiTextBox2.Text == "")
                uiTextBox2.Text = "10";
            else
            {
                uiTextBox1.Text = (uiTrackBar1.Maximum - int.Parse(uiTextBox2.Text)).ToString();
            }
            uiTrackBar1.Value = int.Parse(uiTextBox1.Text);
        }

        private void uiTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            uitrackbar(uiTrackBar1, uiTextBox1, uiTextBox2);
        }

        private void uiTextBox1_TextChanged(object sender, EventArgs e)
        {
            left_textchange(uiTrackBar1, uiTextBox1, uiTextBox2);
        }

        private void uiTextBox2_TextChanged(object sender, EventArgs e)
        {
            right_textchange(uiTrackBar1, uiTextBox1, uiTextBox2);
        }

        private void uiTrackBar2_ValueChanged(object sender, EventArgs e)
        {
            uitrackbar(uiTrackBar2, uiTextBox3, uiTextBox4);
        }
        private void uiTextBox3_TextChanged(object sender, EventArgs e)
        {
            left_textchange(uiTrackBar2, uiTextBox3, uiTextBox4);
        }

        private void uiTextBox4_TextChanged(object sender, EventArgs e)
        {
            right_textchange(uiTrackBar2, uiTextBox3, uiTextBox4);
        }

        private void uiTrackBar3_ValueChanged(object sender, EventArgs e)
        {
            uitrackbar(uiTrackBar3, uiTextBox5, uiTextBox6);
        }

        private void uiTextBox5_TextChanged(object sender, EventArgs e)
        {
            left_textchange(uiTrackBar3, uiTextBox5, uiTextBox6);
        }

        private void uiTextBox6_TextChanged(object sender, EventArgs e)
        {
            right_textchange(uiTrackBar3, uiTextBox5, uiTextBox6);
        }

        private void uiTrackBar4_ValueChanged(object sender, EventArgs e)
        {
            uitrackbar(uiTrackBar4, uiTextBox7, uiTextBox8);
        }

        private void uiTextBox7_TextChanged(object sender, EventArgs e)
        {
            left_textchange(uiTrackBar4, uiTextBox7, uiTextBox8);
        }

        private void uiTextBox8_TextChanged(object sender, EventArgs e)
        {
            right_textchange(uiTrackBar4, uiTextBox7, uiTextBox8);
        }

        private void uiTrackBar5_ValueChanged(object sender, EventArgs e)
        {
            uitrackbar(uiTrackBar5, uiTextBox9, uiTextBox10);
        }

        private void uiTextBox9_TextChanged(object sender, EventArgs e)
        {
            left_textchange(uiTrackBar5, uiTextBox9, uiTextBox10);
        }

        private void uiTextBox10_TextChanged(object sender, EventArgs e)
        {
            right_textchange(uiTrackBar5, uiTextBox9, uiTextBox10);
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            //传递参数
            Class1.x = float.Parse(uiTextBox2.Text) / float.Parse(uiTextBox1.Text);
            Class1.y = float.Parse(uiTextBox4.Text) / float.Parse(uiTextBox1.Text);
            Class1.z = float.Parse(uiTextBox6.Text) / float.Parse(uiTextBox5.Text);
            Class1.q = float.Parse(uiTextBox8.Text) / float.Parse(uiTextBox7.Text);
            Class1.t = float.Parse(uiTextBox10.Text) * float.Parse(uiTextBox9.Text);
            float ans = float.Parse(uiTextBox2.Text) * float.Parse(uiTextBox1.Text) * float.Parse(uiTextBox4.Text)
             * float.Parse(uiTextBox1.Text) * float.Parse(uiTextBox6.Text) * float.Parse(uiTextBox5.Text) * float.Parse(uiTextBox8.Text)
             * float.Parse(uiTextBox7.Text) * float.Parse(uiTextBox10.Text) * float.Parse(uiTextBox9.Text);
            if (ans == 0)
            {
                MessageBox.Show("请重新输入正确的参数！均不能为0");
            }
            else
            {
                float[] gue_point = new float[5] { Class1.x, Class1.y, Class1.z, Class1.q, Class1.t };//得出用户两两比较的权重
                float[,] arr_st = new float[6, 6];//生成判断矩阵

                //得到上三角矩阵
                for (int i = 0; i < 6; i++)
                {
                    for (int j = i; j < 6; j++)
                    {
                        if (i == j)
                            arr_st[i, j] = 1;
                        else
                            arr_st[i, j] = gue_point[j - 1] * arr_st[i, j - 1];
                    }
                }

                //填充下三角矩阵
                for (int i = 1; i < 6; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        arr_st[i, j] = 1 / arr_st[j, i];
                    }
                }

                //得到客户两两比较
                //计算权重

                float sum = 0;
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        sum += arr_st[i, j];
                    }
                }

                //求权重
                float[] weigt = new float[6];
                float row_sum = 0;
                for (int i = 0; i < 6; i++)
                {
                    row_sum = 0;
                    for (int j = 0; j < 6; j++)
                    {
                        row_sum += arr_st[i, j];
                    }
                    weigt[i] = row_sum / sum;
                }

                //加权平均求总得分

                conn.Open();
                DataTable dt = new DataTable();
                string sql = "select * from choice";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
                int r = dt.Rows.Count;
                //得到方案名称表
                string[] name = new string[r];
                for (int i = 0; i < r; i++)
                {
                    name[i] = dt.Rows[i][0].ToString();
                }
                //得到各方案不同因素得分表
                int[,] fac_score = new int[r, 6];
                for (int i = 0; i < r; i++)
                {
                    for (int j = 1; j < 7; j++)
                    {
                        fac_score[i, j - 1] = int.Parse(dt.Rows[i][j].ToString());
                    }
                }

                //相乘计算权重
                float[] score = new float[r];
                float allscore = 0;
                for (int i = 0; i < r; i++)
                {
                    allscore = 0;
                    for (int j = 0; j < 6; j++)
                    {
                        allscore += fac_score[i, j] * weigt[j];
                    }
                    score[i] = allscore;
                }

                int maxindex = MaxIndex(score);
                string choice = name[maxindex].ToString();
                MessageBox.Show("根据您的需求，我们得到最适合您的方案为：  " + choice);
                conn.Close();
                Form12 f12 = new Form12();
                f12.ShowDialog();
            }

        }
        public static int MaxIndex<T>(T[] arr) where T : IComparable<T>
        {
            var i_Pos = 0;
            var value = arr[0];
            for (var i = 1; i < arr.Length; ++i)
            {
                var _value = arr[i];
                if (_value.CompareTo(value) > 0)
                {
                    value = _value;
                    i_Pos = i;
                }
            }
            return i_Pos;
        }

        private void uiLedDisplay1_Click(object sender, EventArgs e)
        {

        }

        private void uiGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiSymbolButton2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
