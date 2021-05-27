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
    public partial class 后台数据 : Form
    {
        public static 后台数据 后台数据2;
        public SqlConnection conn;
        public 后台数据()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            后台数据2 = this;
            string constr = @"Server=.\sqlexpress;Database=2021040614;Integrated security=True;";
            conn = new SqlConnection(constr);
        }
        string i;
        private void Form24_Load(object sender, EventArgs e)
        {
            string sql订单 = "select * from order1 ";
            SqlCommand cmd订单 = new SqlCommand(sql订单, conn);
            SqlDataAdapter ad订单 = new SqlDataAdapter(cmd订单);
            DataTable dt订单 = new DataTable();
            ad订单.Fill(dt订单);
            uiDataGridView1.DataSource = dt订单;
            string sql反馈 = "select * from baoxiu";
            SqlCommand cmd反馈 = new SqlCommand(sql反馈, conn);
            SqlDataAdapter ad反馈 = new SqlDataAdapter(cmd反馈);
            DataTable dt反馈 = new DataTable();
            ad反馈.Fill(dt反馈);
            uiDataGridView2.DataSource = dt反馈;

            string sql载入 = "select 汽车名称 from cars where 厂商='" + Class1.厂商 + "'";
            SqlCommand cmd载入 = new SqlCommand(sql载入, conn);
            conn.Open();
            SqlDataReader rd载入 = cmd载入.ExecuteReader();
            while (rd载入.Read())
            {
                comboBox3.Items.Add(rd载入[0]);
                comboBox4.Items.Add(rd载入[0]);
            }
            rd载入.Close();
            conn.Close();
            comboBox3.SelectedIndex = 1;
            comboBox1.SelectedIndex = 1;
            comboBox4.SelectedIndex = 2;
            string sql = "select order1.汽车名称,count(order1.汽车名称) as 销售量 from order1,cars where 厂商='" + Class1.厂商 + "'and cars.汽车名称=order1.汽车名称 group by order1.汽车名称";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            chart1.DataSource = dt;
            chart1.Series["Series1"]["PieLineColor"] = "Black";//连线颜色
            chart1.Series["Series1"]["PieLabelStyle"] = "Outside";//标签位置
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 15;//起始角度
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 45;//倾斜度(0～90)
            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.Series["Series1"].XValueMember = "汽车名称";
            chart1.Series["Series1"].YValueMembers = "销售量";
            int j;
            string sql汽车 = "select count(汽车名称) from cars where 厂商='" + Class1.厂商 + "'";
            SqlCommand cmd汽车 = new SqlCommand(sql汽车, conn);
            conn.Open();
            j = Convert.ToInt32(cmd汽车.ExecuteScalar());
            conn.Close();
            string[] a = new string[j];
            for (int x = 0; x < j; x++)
            {
                a[x] = dt.Rows[x][0].ToString();
                chart2.Series[x].Name = a[x];
                chart3.Series[x].Name = a[x];
            }
            i = comboBox1.Text;
            string[] 月份 = new string[] { "1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月" };
            for (int x = 0; x < j; x++)
            {
                double[] b = new double[12];
                double[] c = new double[12];
                for (int y = 1; y <= 12; y++)
                {
                    var FirstDay = new DateTime(Convert.ToInt32(i), y, 1);
                    var LastDay = FirstDay.AddMonths(1).AddDays(-1);
                    string sql2 = "select isnull(count(*),0) from order1 where 汽车名称='" + a[x] + "' and 下单时间>='" + FirstDay.ToString() + "' and 下单时间<='" + LastDay.ToString() + "'";
                    SqlCommand cmd2 = new SqlCommand(sql2, conn);
                    conn.Open();
                    b[y - 1] = Convert.ToInt32(cmd2.ExecuteScalar());
                    conn.Close();
                    string sql3 = "select isnull(sum(总价),0) from order1 where 汽车名称='" + a[x] + "' and 下单时间>='" + FirstDay.ToString() + "' and 下单时间<='" + LastDay.ToString() + "'";
                    SqlCommand cmd3 = new SqlCommand(sql3, conn);
                    conn.Open();
                    c[y - 1] = Convert.ToInt32(cmd3.ExecuteScalar());
                    conn.Close();
                }
                chart2.Series[x].Points.DataBindXY(月份, b);
                chart3.Series[x].Points.DataBindXY(月份, c);
            }
            chart2.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            chart2.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 15;//起始角度
            chart2.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 30;//倾斜度(0～90)
            chart2.ChartAreas["ChartArea1"].AxisX.Interval = 1; //决定x轴显示文本的间隔，1为强制每个柱状体都显示，3则间隔3个显示
            chart2.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font("宋体", 9, FontStyle.Regular);
            chart2.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart3.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            chart3.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 15;//起始角度
            chart3.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 30;//倾斜度(0～90)
            chart3.ChartAreas["ChartArea1"].AxisX.Interval = 1; //决定x轴显示文本的间隔，1为强制每个柱状体都显示，3则间隔3个显示
            chart3.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font("宋体", 9, FontStyle.Regular);
            chart3.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            string s = comboBox3.Text;
            string[] 年龄 = new string[] { "18岁以下", "18-30岁", "31-40岁", "41-50岁", "51-60岁", "60岁以上" };
            double[] 数量 = new double[6];
            for (int x = 0; x < 6; x++)
            {
                string sql2 = "select isnull(count(*),0) from order1,users where order1.用户名=users.用户名 and 汽车名称='" + s + "' and 年龄='" + 年龄[x] + "'";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                conn.Open();
                数量[x] = Convert.ToInt32(cmd2.ExecuteScalar());
                conn.Close();
            }
            chart4.Series[0].Points.DataBindXY(年龄, 数量);
            chart4.Series["Series1"]["PieLineColor"] = "Black";//连线颜色
            chart4.Series["Series1"]["PieLabelStyle"] = "Outside";//标签位置
            chart4.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            chart4.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 15;//起始角度
            chart4.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 45;//倾斜度(0～90)
            chart4.Series[0].IsValueShownAsLabel = true;
            chart4.Series["Series1"].XValueMember = "年龄";
            chart4.Series["Series1"].YValueMembers = "销售量";

            //string sql报修 = "select baoxiu.类型,count(*) 数量 from baoxiu,order1 where baoxiu.订单编号=order1.订单编号 and order1.汽车名称='" + comboBox4.Text + "' and baoxiu.时间>='"+uiDatePicker1.Text+"' and baoxiu.时间<='"+uiDatePicker2.Text+"' group by baoxiu.类型";
            //SqlCommand cmd报修 = new SqlCommand(sql报修, conn);
            //SqlDataAdapter ad报修 = new SqlDataAdapter(cmd报修);
            //DataTable dt报修 = new DataTable();
            //ad报修.Fill(dt报修);
            //chart5.DataSource = dt报修;
            //chart5.Series["Series0"].XValueMember = "类型";
            //chart5.Series["Series0"].YValueMembers = "数量";

            string t = comboBox4.Text;
            string[] 种类 = new string[] { "外观异常", "动力异常", "内饰损坏", "系统安全", "其他"};
            double[] 数量1 = new double[5];
            for (int x = 0; x < 5; x++)
            {
                string sql2 = "select isnull(count(*),0) from baoxiu,order1 where baoxiu.类型='"+种类[x]+"' and baoxiu.订单编号=order1.订单编号 and order1.汽车名称='" + comboBox4.Text + "' and baoxiu.时间>='" + uiDatePicker1.Text + "' and baoxiu.时间<='" + uiDatePicker2.Text + "' group by baoxiu.类型";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                conn.Open();
                数量1[x] = Convert.ToInt32(cmd2.ExecuteScalar());
                conn.Close();
            }
            chart5.Series[0].Points.DataBindXY(种类, 数量1);

        }//后台数据加载
        public string ChartArea1 { get; set; }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = comboBox1.SelectedIndex;
            string sql = "select order1.汽车名称,count(order1.汽车名称) as 销售量 from order1,cars where 厂商='" + Class1.厂商 + "'and cars.汽车名称=order1.汽车名称 group by order1.汽车名称";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            chart1.DataSource = dt;
            chart1.Series["Series1"]["PieLineColor"] = "Black";//连线颜色
            chart1.Series["Series1"]["PieLabelStyle"] = "Outside";//标签位置
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 15;//起始角度
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 45;//倾斜度(0～90)
            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.Series["Series1"].XValueMember = "汽车名称";
            chart1.Series["Series1"].YValueMembers = "销售量";
            int j;
            string sql汽车 = "select count(汽车名称) from cars where 厂商='" + Class1.厂商 + "'";
            SqlCommand cmd汽车 = new SqlCommand(sql汽车, conn);
            conn.Open();
            j = Convert.ToInt32(cmd汽车.ExecuteScalar());
            conn.Close();
            string[] a = new string[j];
            for (int x = 0; x < j; x++)
            {
                a[x] = dt.Rows[x][0].ToString();
                chart2.Series[x].Name = a[x];
                chart3.Series[x].Name = a[x];
            }
            i = comboBox1.Text;
            string[] 月份 = new string[] { "1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月" };
            for (int x = 0; x < j; x++)
            {
                double[] b = new double[12];
                double[] c = new double[12];
                for (int y = 1; y <= 12; y++)
                {
                    var FirstDay = new DateTime(Convert.ToInt32(i), y, 1);
                    var LastDay = FirstDay.AddMonths(1).AddDays(-1);
                    string sql2 = "select isnull(count(*),0) from order1 where 汽车名称='" + a[x] + "' and 下单时间>='" + FirstDay.ToString() + "' and 下单时间<='" + LastDay.ToString() + "'";
                    SqlCommand cmd2 = new SqlCommand(sql2, conn);
                    conn.Open();
                    b[y - 1] = Convert.ToInt32(cmd2.ExecuteScalar());
                    conn.Close();
                    string sql3 = "select isnull(sum(总价),0) from order1 where 汽车名称='" + a[x] + "' and 下单时间>='" + FirstDay.ToString() + "' and 下单时间<='" + LastDay.ToString() + "'";
                    SqlCommand cmd3 = new SqlCommand(sql3, conn);
                    conn.Open();
                    c[y - 1] = Convert.ToInt32(cmd3.ExecuteScalar());
                    conn.Close();
                }
                chart2.Series[x].Points.DataBindXY(月份, b);
                chart3.Series[x].Points.DataBindXY(月份, c);
            }
            chart2.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            chart2.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 15;//起始角度
            chart2.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 30;//倾斜度(0～90)
            chart2.ChartAreas["ChartArea1"].AxisX.Interval = 1; //决定x轴显示文本的间隔，1为强制每个柱状体都显示，3则间隔3个显示
            chart2.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font("宋体", 9, FontStyle.Regular);
            chart2.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart3.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            chart3.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 15;//起始角度
            chart3.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 30;//倾斜度(0～90)
            chart3.ChartAreas["ChartArea1"].AxisX.Interval = 1; //决定x轴显示文本的间隔，1为强制每个柱状体都显示，3则间隔3个显示
            chart3.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font("宋体", 9, FontStyle.Regular);
            chart3.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = comboBox2.SelectedIndex;
            string sql = "select order1.汽车名称,isnull(count(order1.汽车名称),0) as 销售量 from order1,cars where 厂商='" + Class1.厂商 + "'and cars.汽车名称=order1.汽车名称 group by order1.汽车名称";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            chart1.DataSource = dt;
            chart1.Series["Series1"]["PieLineColor"] = "Black";//连线颜色
            chart1.Series["Series1"]["PieLabelStyle"] = "Outside";//标签位置
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 15;//起始角度
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 45;//倾斜度(0～90)
            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.Series["Series1"].XValueMember = "汽车名称";
            chart1.Series["Series1"].YValueMembers = "销售量";
            int j;
            string sql汽车 = "select count(汽车名称) from cars where 厂商='" + Class1.厂商 + "'";
            SqlCommand cmd汽车 = new SqlCommand(sql汽车, conn);
            conn.Open();
            j = Convert.ToInt32(cmd汽车.ExecuteScalar());
            conn.Close();
            string[] a = new string[j];
            for (int x = 0; x < j; x++)
            {
                a[x] = dt.Rows[x][0].ToString();
                chart2.Series[x].Name = a[x];
                chart3.Series[x].Name = a[x];
            }
            i = comboBox1.Text;
            string[] 月份 = new string[] { "1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月" };
            for (int x = 0; x < j; x++)
            {
                double[] b = new double[12];
                double[] c = new double[12];
                for (int y = 1; y <= 12; y++)
                {
                    var FirstDay = new DateTime(Convert.ToInt32(i), y, 1);
                    var LastDay = FirstDay.AddMonths(1).AddDays(-1);
                    string sql2 = "select isnull(count(*),0) from order1 where 汽车名称='" + a[x] + "' and 下单时间>='" + FirstDay.ToString() + "' and 下单时间<='" + LastDay.ToString() + "'";
                    SqlCommand cmd2 = new SqlCommand(sql2, conn);
                    conn.Open();
                    b[y - 1] = Convert.ToInt32(cmd2.ExecuteScalar());
                    conn.Close();
                    string sql3 = "select isnull(sum(总价),0) from order1 where 汽车名称='" + a[x] + "' and 下单时间>='" + FirstDay.ToString() + "' and 下单时间<='" + LastDay.ToString() + "'";
                    SqlCommand cmd3 = new SqlCommand(sql3, conn);
                    conn.Open();
                    c[y - 1] = Convert.ToInt32(cmd3.ExecuteScalar());
                    conn.Close();
                }
                chart2.Series[x].Points.DataBindXY(月份, b);
                chart3.Series[x].Points.DataBindXY(月份, c);
            }
            chart2.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            chart2.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 15;//起始角度
            chart2.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 30;//倾斜度(0～90)
            chart2.ChartAreas["ChartArea1"].AxisX.Interval = 1; //决定x轴显示文本的间隔，1为强制每个柱状体都显示，3则间隔3个显示
            chart2.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font("宋体", 9, FontStyle.Regular);
            chart2.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart3.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            chart3.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 15;//起始角度
            chart3.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 30;//倾斜度(0～90)
            chart3.ChartAreas["ChartArea1"].AxisX.Interval = 1; //决定x轴显示文本的间隔，1为强制每个柱状体都显示，3则间隔3个显示
            chart3.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font("宋体", 9, FontStyle.Regular);
            chart3.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
        }
        //图像展示
        private void uiButton1_Click(object sender, EventArgs e)
        {
            string sql = "select order1.汽车名称,count(order1.汽车名称) as 销售量 from order1,cars where 厂商='" + Class1.厂商 + "'and cars.汽车名称=order1.汽车名称 group by order1.汽车名称";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            chart1.DataSource = dt;
            chart1.Series["Series1"]["PieLineColor"] = "Black";//连线颜色
            chart1.Series["Series1"]["PieLabelStyle"] = "Outside";//标签位置
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 15;//起始角度
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 45;//倾斜度(0～90)
            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.Series["Series1"].XValueMember = "汽车名称";
            chart1.Series["Series1"].YValueMembers = "销售量";
            int j;
            string sql汽车 = "select count(汽车名称) from cars where 厂商='" + Class1.厂商 + "'";
            SqlCommand cmd汽车 = new SqlCommand(sql汽车, conn);
            conn.Open();
            j = Convert.ToInt32(cmd汽车.ExecuteScalar());
            conn.Close();
            string[] a = new string[j];
            for (int x = 0; x < j; x++)
            {
                a[x] = dt.Rows[x][0].ToString();
                chart2.Series[x].Name = a[x];
                chart3.Series[x].Name = a[x];
            }
            i = comboBox1.Text;
            string[] 月份 = new string[] { "1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月" };
            for (int x = 0; x < j; x++)
            {
                double[] b = new double[12];
                double[] c = new double[12];
                for (int y = 1; y <= 12; y++)
                {
                    var FirstDay = new DateTime(Convert.ToInt32(i), y, 1);
                    var LastDay = FirstDay.AddMonths(1).AddDays(-1);
                    string sql2 = "select isnull(count(*),0) from order1 where 汽车名称='" + a[x] + "' and 下单时间>='" + FirstDay.ToString() + "' and 下单时间<='" + LastDay.ToString() + "'";
                    SqlCommand cmd2 = new SqlCommand(sql2, conn);
                    conn.Open();
                    b[y - 1] = Convert.ToInt32(cmd2.ExecuteScalar());
                    conn.Close();
                    string sql3 = "select isnull(sum(总价),0) from order1 where 汽车名称='" + a[x] + "' and 下单时间>='" + FirstDay.ToString() + "' and 下单时间<='" + LastDay.ToString() + "'";
                    SqlCommand cmd3 = new SqlCommand(sql3, conn);
                    conn.Open();
                    c[y - 1] = Convert.ToInt32(cmd3.ExecuteScalar());
                    conn.Close();
                }
                chart2.Series[x].Points.DataBindXY(月份, b);
                chart3.Series[x].Points.DataBindXY(月份, c);
            }
            chart2.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            chart2.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 15;//起始角度
            chart2.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 30;//倾斜度(0～90)
            chart2.ChartAreas["ChartArea1"].AxisX.Interval = 1; //决定x轴显示文本的间隔，1为强制每个柱状体都显示，3则间隔3个显示
            chart2.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font("宋体", 9, FontStyle.Regular);
            chart2.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart3.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            chart3.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 15;//起始角度
            chart3.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 30;//倾斜度(0～90)
            chart3.ChartAreas["ChartArea1"].AxisX.Interval = 1; //决定x轴显示文本的间隔，1为强制每个柱状体都显示，3则间隔3个显示
            chart3.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font("宋体", 9, FontStyle.Regular);
            chart3.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
        }
        //图像展示
        private void uiButton2_Click(object sender, EventArgs e)
        {
            string sql = "select order1.汽车名称,count(order1.汽车名称) as 销售量 from order1,cars where 厂商='" + Class1.厂商 + "'and cars.汽车名称=order1.汽车名称 group by order1.汽车名称";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            chart1.DataSource = dt;
            chart1.Series["Series1"]["PieLineColor"] = "Black";//连线颜色
            chart1.Series["Series1"]["PieLabelStyle"] = "Outside";//标签位置
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 15;//起始角度
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 45;//倾斜度(0～90)
            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.Series["Series1"].XValueMember = "汽车名称";
            chart1.Series["Series1"].YValueMembers = "销售量";
            int j;
            string sql汽车 = "select count(汽车名称) from cars where 厂商='" + Class1.厂商 + "'";
            SqlCommand cmd汽车 = new SqlCommand(sql汽车, conn);
            conn.Open();
            j = Convert.ToInt32(cmd汽车.ExecuteScalar());
            conn.Close();
            string[] a = new string[j];
            for (int x = 0; x < j; x++)
            {
                a[x] = dt.Rows[x][0].ToString();
                chart2.Series[x].Name = a[x];
                chart3.Series[x].Name = a[x];
            }
            i = comboBox1.Text;
            string[] 季度 = new string[] { "第一季度", "第二季度", "第三季度", "第四季度" };
            for (int x = 0; x < j; x++)
            {
                double[] b = new double[4];
                double[] c = new double[4];
                for (int y = 0; y <= 3; y++)
                {
                    var FirstDay = new DateTime(Convert.ToInt32(i), 3 * y + 1, 1);
                    var FirstDay1 = new DateTime(Convert.ToInt32(i), 3 * y + 3, 1);
                    var LastDay = FirstDay1.AddMonths(1).AddDays(-1);
                    string sql2 = "select isnull(count(*),0) from order1 where 汽车名称='" + a[x] + "' and 下单时间>='" + FirstDay.ToString() + "' and 下单时间<='" + LastDay.ToString() + "'";
                    SqlCommand cmd2 = new SqlCommand(sql2, conn);
                    conn.Open();
                    b[y] = Convert.ToInt32(cmd2.ExecuteScalar());
                    conn.Close();
                    string sql3 = "select isnull(sum(总价),0) from order1 where 汽车名称='" + a[x] + "' and 下单时间>='" + FirstDay.ToString() + "' and 下单时间<='" + LastDay.ToString() + "'";
                    SqlCommand cmd3 = new SqlCommand(sql3, conn);
                    conn.Open();
                    c[y] = Convert.ToInt32(cmd3.ExecuteScalar());
                    conn.Close();
                }
                chart2.Series[x].Points.DataBindXY(季度, b);
                chart3.Series[x].Points.DataBindXY(季度, c);
            }
            chart2.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            chart2.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 15;//起始角度
            chart2.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 30;//倾斜度(0～90)
            chart2.ChartAreas["ChartArea1"].AxisX.Interval = 1; //决定x轴显示文本的间隔，1为强制每个柱状体都显示，3则间隔3个显示
            chart2.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font("宋体", 9, FontStyle.Regular);
            chart2.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart3.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            chart3.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 15;//起始角度
            chart3.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 30;//倾斜度(0～90)
            chart3.ChartAreas["ChartArea1"].AxisX.Interval = 1; //决定x轴显示文本的间隔，1为强制每个柱状体都显示，3则间隔3个显示
            chart3.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font("宋体", 9, FontStyle.Regular);
            chart3.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            string sql = "select order1.汽车名称,count(order1.汽车名称) as 销售量 from order1,cars where 厂商='" + Class1.厂商 + "'and cars.汽车名称=order1.汽车名称 group by order1.汽车名称";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            chart1.DataSource = dt;
            chart1.Series["Series1"]["PieLineColor"] = "Black";//连线颜色
            chart1.Series["Series1"]["PieLabelStyle"] = "Outside";//标签位置
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 15;//起始角度
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 45;//倾斜度(0～90)
            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.Series["Series1"].XValueMember = "汽车名称";
            chart1.Series["Series1"].YValueMembers = "销售量";
            int j;
            string sql汽车 = "select count(汽车名称) from cars where 厂商='" + Class1.厂商 + "'";
            SqlCommand cmd汽车 = new SqlCommand(sql汽车, conn);
            conn.Open();
            j = Convert.ToInt32(cmd汽车.ExecuteScalar());
            conn.Close();
            string[] a = new string[j];
            for (int x = 0; x < j; x++)
            {
                a[x] = dt.Rows[x][0].ToString();
                chart2.Series[x].Name = a[x];
                chart3.Series[x].Name = a[x];
            }
            i = comboBox1.Text;
            string[] 月份 = new string[] { "1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月" };
            for (int x = 0; x < j; x++)
            {
                double[] b = new double[12];
                double[] c = new double[12];
                for (int y = 1; y <= 12; y++)
                {
                    var FirstDay = new DateTime(Convert.ToInt32(i), y, 1);
                    var LastDay = FirstDay.AddMonths(1).AddDays(-1);
                    string sql2 = "select isnull(count(*),0) from order1 where 汽车名称='" + a[x] + "' and 下单时间>='" + FirstDay.ToString() + "' and 下单时间<='" + LastDay.ToString() + "'";
                    SqlCommand cmd2 = new SqlCommand(sql2, conn);
                    conn.Open();
                    b[y - 1] = Convert.ToInt32(cmd2.ExecuteScalar());
                    conn.Close();
                    string sql3 = "select isnull(sum(总价),0) from order1 where 汽车名称='" + a[x] + "' and 下单时间>='" + FirstDay.ToString() + "' and 下单时间<='" + LastDay.ToString() + "'";
                    SqlCommand cmd3 = new SqlCommand(sql3, conn);
                    conn.Open();
                    c[y - 1] = Convert.ToInt32(cmd3.ExecuteScalar());
                    conn.Close();
                }
                chart2.Series[x].Points.DataBindXY(月份, b);
                chart3.Series[x].Points.DataBindXY(月份, c);
            }
            chart2.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            chart2.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 15;//起始角度
            chart2.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 30;//倾斜度(0～90)
            chart2.ChartAreas["ChartArea1"].AxisX.Interval = 1; //决定x轴显示文本的间隔，1为强制每个柱状体都显示，3则间隔3个显示
            chart2.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font("宋体", 9, FontStyle.Regular);
            chart2.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart3.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            chart3.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 15;//起始角度
            chart3.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 30;//倾斜度(0～90)
            chart3.ChartAreas["ChartArea1"].AxisX.Interval = 1; //决定x轴显示文本的间隔，1为强制每个柱状体都显示，3则间隔3个显示
            chart3.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font("宋体", 9, FontStyle.Regular);
            chart3.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
        }
        //图像展示
        private void uiButton3_Click(object sender, EventArgs e)
        {
            string sql = "select order1.汽车名称,count(order1.汽车名称) as 销售量 from order1,cars where 厂商='" + Class1.厂商 + "'and cars.汽车名称=order1.汽车名称 group by order1.汽车名称";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            chart1.DataSource = dt;
            chart1.Series["Series1"]["PieLineColor"] = "Black";//连线颜色
            chart1.Series["Series1"]["PieLabelStyle"] = "Outside";//标签位置
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 15;//起始角度
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 45;//倾斜度(0～90)
            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.Series["Series1"].XValueMember = "汽车名称";
            chart1.Series["Series1"].YValueMembers = "销售量";
            int j;
            string sql汽车 = "select count(汽车名称) from cars where 厂商='" + Class1.厂商 + "'";
            SqlCommand cmd汽车 = new SqlCommand(sql汽车, conn);
            conn.Open();
            j = Convert.ToInt32(cmd汽车.ExecuteScalar());
            conn.Close();
            string[] a = new string[j];
            for (int x = 0; x < j; x++)
            {
                a[x] = dt.Rows[x][0].ToString();
                chart2.Series[x].Name = a[x];
                chart3.Series[x].Name = a[x];
            }
            i = comboBox1.Text;
            string[] 季度 = new string[] { "第一季度", "第二季度", "第三季度", "第四季度" };
            for (int x = 0; x < j; x++)
            {
                double[] b = new double[4];
                double[] c = new double[4];
                for (int y = 0; y <= 3; y++)
                {
                    var FirstDay = new DateTime(Convert.ToInt32(i), 3 * y + 1, 1);
                    var FirstDay1 = new DateTime(Convert.ToInt32(i), 3 * y + 3, 1);
                    var LastDay = FirstDay1.AddMonths(1).AddDays(-1);
                    string sql2 = "select isnull(count(*),0) from order1 where 汽车名称='" + a[x] + "' and 下单时间>='" + FirstDay.ToString() + "' and 下单时间<='" + LastDay.ToString() + "'";
                    SqlCommand cmd2 = new SqlCommand(sql2, conn);
                    conn.Open();
                    b[y] = Convert.ToInt32(cmd2.ExecuteScalar());
                    conn.Close();
                    string sql3 = "select isnull(sum(总价),0) from order1 where 汽车名称='" + a[x] + "' and 下单时间>='" + FirstDay.ToString() + "' and 下单时间<='" + LastDay.ToString() + "'";
                    SqlCommand cmd3 = new SqlCommand(sql3, conn);
                    conn.Open();
                    c[y] = Convert.ToInt32(cmd3.ExecuteScalar());
                    conn.Close();
                }
                chart2.Series[x].Points.DataBindXY(季度, b);
                chart3.Series[x].Points.DataBindXY(季度, c);
            }
            chart2.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            chart2.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 15;//起始角度
            chart2.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 30;//倾斜度(0～90)
            chart2.ChartAreas["ChartArea1"].AxisX.Interval = 1; //决定x轴显示文本的间隔，1为强制每个柱状体都显示，3则间隔3个显示
            chart2.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font("宋体", 9, FontStyle.Regular);
            chart2.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart3.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            chart3.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 15;//起始角度
            chart3.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 30;//倾斜度(0～90)
            chart3.ChartAreas["ChartArea1"].AxisX.Interval = 1; //决定x轴显示文本的间隔，1为强制每个柱状体都显示，3则间隔3个显示
            chart3.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font("宋体", 9, FontStyle.Regular);
            chart3.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
        }
        //图像展示
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = comboBox3.Text;
            string[] 年龄 = new string[] { "18岁以下", "18-30岁", "31-40岁", "41-50岁", "51-60岁", "60岁以上" };
            double[] 数量 = new double[6];
            for (int x = 0; x < 6; x++)
            {
                string sql2 = "select isnull(count(*),0) from order1,users where order1.用户名=users.用户名 and 汽车名称='" + s + "' and 年龄='" + 年龄[x] + "'";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                conn.Open();
                数量[x] = Convert.ToInt32(cmd2.ExecuteScalar());
                conn.Close();
            }
            chart4.Series[0].Points.DataBindXY(年龄, 数量);
            chart4.Series["Series1"]["PieLineColor"] = "Black";//连线颜色
            chart4.Series["Series1"]["PieLabelStyle"] = "Outside";//标签位置
            chart4.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            chart4.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 15;//起始角度
            chart4.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 45;//倾斜度(0～90)
            chart4.Series[0].IsValueShownAsLabel = true;
            chart4.Series["Series1"].XValueMember = "年龄";
            chart4.Series["Series1"].YValueMembers = "销售量";
        }
        //年龄分析
        private void 详情ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (uiDataGridView1.CurrentRow.Cells[0].Value.ToString() == string.Empty)
                MessageBox.Show("请选择一个订单", "提示");
            else
            {
                Class1.订单号 = uiDataGridView1.CurrentRow.Cells[0].Value.ToString();
                string sql = @"select 姓名 from users,order1 where order1.用户名=users.用户名 and 订单编号=@订单编号";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号; ;
                try
                {
                    conn.Open();
                    Class1.姓名 = cmd.ExecuteScalar().ToString();
                }
                catch(SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
                finally
                {
                    conn.Close();
                }

                订单详情 f = new 订单详情();
                f.Show();
            }//查看所选订单的详情
        }

        private void 查看订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (uiDataGridView2.CurrentRow.Cells[4].Value.ToString() == string.Empty)
                MessageBox.Show("请选择一个订单", "提示");
            else
            {
                Class1.订单号 = uiDataGridView2.CurrentRow.Cells[4].Value.ToString();
                string sql = @"select 姓名 from users,order1 where users.用户名=order1.用户名 and order1.订单编号=@订单编号";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@订单编号", SqlDbType.NVarChar, 50).Value = Class1.订单号;
                conn.Open();
                Class1.姓名 = cmd.ExecuteScalar().ToString();
                conn.Close();
                订单详情 f = new 订单详情();
                f.Show();
            }
        }//查看所选订单的详情

        private void 回复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (uiDataGridView2.CurrentRow.Cells[0].Value.ToString() == string.Empty)
                MessageBox.Show("请选择一个反馈", "提示");
            else
            {
                Class1.反馈编号 = uiDataGridView2.CurrentRow.Cells[0].Value.ToString();
                厂家回复 f = new 厂家回复();
                f.Show();
            }//进入回复页面，给予用户回复
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\i-car\\各地销量.py");//python地图动态展示
        }

        private void uiDatePicker1_ValueChanged(object sender, DateTime value)
        {
            string t = comboBox4.Text;
            string[] 种类 = new string[] { "外观异常", "动力异常", "内饰损坏", "系统安全", "其他" };
            double[] 数量1 = new double[5];
            for (int x = 0; x < 5; x++)
            {
                string sql2 = "select isnull(count(*),0) from baoxiu,order1 where baoxiu.类型='" + 种类[x] + "' and baoxiu.订单编号=order1.订单编号 and order1.汽车名称='" + comboBox4.Text + "' and baoxiu.时间>='" + uiDatePicker1.Text + "' and baoxiu.时间<='" + uiDatePicker2.Text + "' group by baoxiu.类型";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                conn.Open();
                数量1[x] = Convert.ToInt32(cmd2.ExecuteScalar());
                conn.Close();
            }
            chart5.Series[0].Points.DataBindXY(种类, 数量1);
        }

        private void uiDatePicker2_ValueChanged(object sender, DateTime value)
        {
            string t = comboBox4.Text;
            string[] 种类 = new string[] { "外观异常", "动力异常", "内饰损坏", "系统安全", "其他" };
            double[] 数量1 = new double[5];
            for (int x = 0; x < 5; x++)
            {
                string sql2 = "select isnull(count(*),0) from baoxiu,order1 where baoxiu.类型='" + 种类[x] + "' and baoxiu.订单编号=order1.订单编号 and order1.汽车名称='" + comboBox4.Text + "' and baoxiu.时间>='" + uiDatePicker1.Text + "' and baoxiu.时间<='" + uiDatePicker2.Text + "' group by baoxiu.类型";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                conn.Open();
                数量1[x] = Convert.ToInt32(cmd2.ExecuteScalar());
                conn.Close();
            }
            chart5.Series[0].Points.DataBindXY(种类, 数量1);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string t = comboBox4.Text;
            string[] 种类 = new string[] { "外观异常", "动力异常", "内饰损坏", "系统安全", "其他" };
            double[] 数量1 = new double[5];
            for (int x = 0; x < 5; x++)
            {
                string sql2 = "select isnull(count(*),0) from baoxiu,order1 where baoxiu.类型='" + 种类[x] + "' and baoxiu.订单编号=order1.订单编号 and order1.汽车名称='" + comboBox4.Text + "' and baoxiu.时间>='" + uiDatePicker1.Text + "' and baoxiu.时间<='" + uiDatePicker2.Text + "' group by baoxiu.类型";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                conn.Open();
                数量1[x] = Convert.ToInt32(cmd2.ExecuteScalar());
                conn.Close();
            }
            chart5.Series[0].Points.DataBindXY(种类, 数量1);//不同车辆故障分析
        }
    }
}
