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
using System.Windows.Forms.DataVisualization.Charting;
using i_car1;
using i_car3;
using yxh;

namespace 智能推荐方案
{
    public partial class Form12 : Form
    {
        SqlConnection conn;
        string constr = @"server=.\sqlexpress;database=2021040614;Integrated Security=true;";
        public Form12()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            conn = new SqlConnection(constr);
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            //chart1.Titles.Add("车辆指标得分总评");
            //chart1.Titles[0].ForeColor = Color.Black;
            //chart1.Titles[0].Font = new Font("微软雅黑", 12f, FontStyle.Regular);
            //chart1.Titles[0].Alignment = ContentAlignment.TopCenter;


            //控件背景
            chart1.BackColor = Color.Transparent;
            chart1.ChartAreas[0].BackColor = Color.Transparent;
            chart1.ChartAreas[0].BorderColor = Color.Red;

            ////X轴标签间距
            //chart1.ChartAreas[0].AxisX.Interval = 0.1;
            //chart1.ChartAreas[0].AxisX.LabelStyle.IsStaggered = true;
            //chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            //chart1.ChartAreas[0].AxisX.TitleFont = new Font("微软雅黑", 14f, FontStyle.Regular);
            //chart1.ChartAreas[0].AxisX.TitleForeColor = Color.White;

            ////X坐标轴颜色
            //chart1.ChartAreas[0].AxisX.LineColor = ColorTranslator.FromHtml("#38587a"); ;
            //chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            //chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("微软雅黑", 10f, FontStyle.Regular);

            ////X坐标轴标题
            //chart1.ChartAreas[0].AxisX.Title = "数量(宗)";
            //chart1.ChartAreas[0].AxisX.TitleFont = new Font("微软雅黑", 10f, FontStyle.Regular);
            //chart1.ChartAreas[0].AxisX.TitleForeColor = Color.White;
            //chart1.ChartAreas[0].AxisX.TextOrientation = TextOrientation.Auto;
            //chart1.ChartAreas[0].AxisX.ToolTip = "数量(宗)";

            //X轴网络线条
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#2c4c6d");

            //Y坐标轴颜色
            chart1.ChartAreas[0].AxisY.LineColor = ColorTranslator.FromHtml("#38587a");
            chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Black;
            chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("微软雅黑", 10f, FontStyle.Regular);

            //Y坐标轴标题
            //chart1.ChartAreas[0].AxisY.Title = "数量(宗)";
            //chart1.ChartAreas[0].AxisY.TitleFont = new Font("微软雅黑", 10f, FontStyle.Regular);
            //chart1.ChartAreas[0].AxisY.TitleForeColor = Color.White;
            //chart1.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Auto;
            //chart1.ChartAreas[0].AxisY.ToolTip = "数量(宗)";

            //Y轴网格线条
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#2c4c6d");
            chart1.ChartAreas[0].AxisY2.LineColor = Color.Red;
            chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart1.ChartAreas[0].AxisX.IsInterlaced = false;
            chart1.ChartAreas[0].AxisX.IsMarginVisible = false;

            //刻度线
            chart1.ChartAreas[0].AxisY.MajorTickMark.Enabled = true;
            //chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            //chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            //chart1.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            chart1.ChartAreas[0].AxisY.LabelStyle.Enabled = true;

            //背景渐变——网格线
            //chart1.ChartAreas[0].BackGradientStyle = GradientStyle.None;
            //chart1.ChartAreas[0].AxisX2.InterlacedColor = Color.Black;
            //chart1.ChartAreas[0].AxisY2.InterlacedColor = Color.Black;
            //chart1.ChartAreas[0].BorderWidth = 0;
            //chart1.ChartAreas[0].BackSecondaryColor = Color.Black;
            //chart1.ChartAreas[0].BackImageTransparentColor = Color.Black;
            //chart1.ChartAreas[0].AxisX.InterlacedColor = Color.Black;
            //chart1.ChartAreas[0].AxisX.LineColor = Color.Black;
            //chart1.ChartAreas[0].AxisX2.LineColor = Color.Black;
            //chart1.ChartAreas[0].AxisX2.MajorGrid.LineColor = Color.Black;
            //chart1.ChartAreas[0].AxisX2.MajorTickMark.LineColor = Color.Black;
            //chart1.ChartAreas[0].AxisX2.MinorTickMark.LineColor = Color.Black;
            //chart1.ChartAreas[0].AxisY.InterlacedColor = Color.Black;
            //chart1.ChartAreas[0].AxisY.LineColor = Color.Black;
            //chart1.ChartAreas[0].AxisY2.InterlacedColor = Color.Black;
            //chart1.ChartAreas[0].AxisY2.LineColor = Color.Black;
            //chart1.ChartAreas[0].AxisY2.MajorGrid.LineColor = Color.Black;
            //chart1.ChartAreas[0].AxisY2.MajorTickMark.LineColor = Color.Black;
            //chart1.ChartAreas[0].AxisY2.MinorTickMark.LineColor = Color.Black;


            //图例样式
            //Legend legend4 = new Legend();
            //legend4.Title = "图例";
            //legend4.TitleBackColor = Color.Green;
            //legend4.BackColor = Color.Blue;
            //legend4.TitleForeColor = Color.Red;
            //legend4.TitleFont = new Font("微软雅黑", 10f, FontStyle.Regular);
            //legend4.Font = new Font("微软雅黑", 8f, FontStyle.Regular);
            //legend4.ForeColor = Color.Red;
            //chart1.Legends.Add(legend4);
            //chart1.Legends[0].Position.Auto = true;

            ////Series1
            //chart1.Series[0].XValueType = ChartValueType.String;
            //chart1.Series[0].Label = "#VAL";
            //chart1.Series[0].LabelForeColor = Color.White;
            //chart1.Series[0].ToolTip = "#LEGENDTEXT:#VAL(宗)";
            //chart1.Series[0].ChartType = SeriesChartType.Radar;
            //chart1.Series[0]["RadarDrawingStyle"] = "Line";
            //chart1.Series[0].LegendText = "2015年";
            //chart1.Series[0].IsValueShownAsLabel = true;

            ////Series2
            //chart1.Series.Add(new Series("Series2"));
            //chart1.Series[1].Label = "#VAL";
            //chart1.Series[1].LabelForeColor = Color.White;
            //chart1.Series[1].ToolTip = "#LEGENDTEXT:#VAL(宗)";
            //chart1.Series[1].ChartType = SeriesChartType.Radar;
            //chart1.Series[1]["RadarDrawingStyle"] = "Line";
            //chart1.Series[1].LegendText = "2016年";
            //chart1.Series[1].IsValueShownAsLabel = true;

            ////Series3
            //chart1.Series.Add(new Series("Series3"));
            //chart1.Series[2].Label = "#VAL";
            //chart1.Series[2].LabelForeColor = Color.White;
            //chart1.Series[2].ToolTip = "#LEGENDTEXT:#VAL(宗)";
            //chart1.Series[2].ChartType = SeriesChartType.Radar;
            //chart1.Series[2]["RadarDrawingStyle"] = "Line";
            //chart1.Series[2].LegendText = "2017年";
            //chart1.Series[2].IsValueShownAsLabel = true;
            draw(chart1);
            draw(chart4);
            draw(chart2);
            draw(chart3);
            draw(chart5);
            draw(chart6);

            conn.Open();
            DataTable dt = new DataTable();
            string sql = "select * from choice";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            int r = dt.Rows.Count;
            int[,] fac_score = new int[r, 6];

            for (int i = 0; i < r; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    fac_score[i, j - 1] = int.Parse(dt.Rows[i][j].ToString());
                }
            }

            double[] y1Values = new double[6];
            double[] y2Values = new double[6];
            double[] y3Values = new double[6];
            double[] y4Values = new double[6];
            double[] y5Values = new double[6];
            double[] y6Values = new double[6];

            for (int i = 0; i < 6; i++)
            {
                y1Values[i] = fac_score[0, i];
            }
            for (int i = 0; i < 6; i++)
            {
                y2Values[i] = fac_score[1, i];
            }
            for (int i = 0; i < 6; i++)
            {
                y3Values[i] = fac_score[2, i];
            }
            for (int i = 0; i < 6; i++)
            {
                y4Values[i] = fac_score[3, i];
            }
            for (int i = 0; i < 6; i++)
            {
                y5Values[i] = fac_score[4, i];
            }
            for (int i = 0; i < 6; i++)
            {
                y6Values[i] = fac_score[5, i];
            }

            string[] xValues = { "安全", "舒适", "经济", "油耗", "启动加速", "售后维修" };        



            //Seris2  
            //double[] y2 = { 45.62, 65.54, 70.45, 84.73, 35.42, 55.9, 63.6 };
            //double[] y3 = { 88.62, 35.54, 52.45, 45.73, 88.42, 14.9, 33.6 };
            this.chart1.Series[0].Points.DataBindXY(xValues, y1Values);
            this.chart4.Series[0].Points.DataBindXY(xValues, y2Values);
            this.chart2.Series[0].Points.DataBindXY(xValues, y3Values);
            this.chart3.Series[0].Points.DataBindXY(xValues, y4Values);
            this.chart5.Series[0].Points.DataBindXY(xValues, y5Values);
            this.chart6.Series[0].Points.DataBindXY(xValues, y6Values);
            //this.chart1.Series[1].Points.DataBindY(y2);
            //this.chart1.Series[2].Points.DataBindY(y3);


            ////设置X轴显示间隔为1,X轴数据比较多的时候比较有用  
            //chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 0.1;
            ////设置XY轴标题的名称所在位置位远  
            //chart1.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Near;

            //chart2.ChartAreas[0].AxisX.LabelStyle.Interval = 0.1;
            ////设置XY轴标题的名称所在位置位远  
            //chart2.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Near;

            //chart3.ChartAreas[0].AxisX.LabelStyle.Interval = 0.1;
            ////设置XY轴标题的名称所在位置位远  
            //chart3.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Near;

            //chart4.ChartAreas[0].AxisX.LabelStyle.Interval = 0.1;
            ////设置XY轴标题的名称所在位置位远  
            //chart4.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Near;

            //chart5.ChartAreas[0].AxisX.LabelStyle.Interval = 0.1;
            ////设置XY轴标题的名称所在位置位远  
            //chart5.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Near;

            //chart6.ChartAreas[0].AxisX.LabelStyle.Interval = 0.1;
            ////设置XY轴标题的名称所在位置位远  
            //chart6.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Near;

            //for (int i = 0; i < chart1.Series[0].Points.Count; i++)
            //{
            //    chart1.Series[0].Points[i].MarkerStyle = MarkerStyle.Circle;//设置折点的风格     
            //    chart1.Series[0].Points[i].MarkerColor = Color.Red;//设置seires中折点的颜色   
            //                                                       //    chart1.Series[1].Points[i].MarkerStyle = MarkerStyle.Square;//设置折点的风格     
            //                                                       //    chart1.Series[1].Points[i].MarkerColor = Color.Blue;//设置seires中折点的颜色  
            //                                                       //    chart1.Series[2].Points[i].MarkerStyle = MarkerStyle.Square;//设置折点的风格     
            //                                                       //    chart1.Series[2].Points[i].MarkerColor = Color.Green;//设置seires中折点的颜色  
            //}
            //for (int i = 0; i < chart1.Series[0].Points.Count; i++)
            //{
            //    chart2.Series[0].Points[i].MarkerStyle = MarkerStyle.Circle;//设置折点的风格     
            //    chart2.Series[0].Points[i].MarkerColor = Color.Red;//设置seires中折点的颜色   
            //                                                       //    chart1.Series[1].Points[i].MarkerStyle = MarkerStyle.Square;//设置折点的风格     
            //                                                       //    chart1.Series[1].Points[i].MarkerColor = Color.Blue;//设置seires中折点的颜色  
            //                                                       //    chart1.Series[2].Points[i].MarkerStyle = MarkerStyle.Square;//设置折点的风格     
            //                                                       //    chart1.Series[2].Points[i].MarkerColor = Color.Green;//设置seires中折点的颜色  
            //}
            //for (int i = 0; i < chart1.Series[0].Points.Count; i++)
            //{
            //    chart3.Series[0].Points[i].MarkerStyle = MarkerStyle.Circle;//设置折点的风格     
            //    chart3.Series[0].Points[i].MarkerColor = Color.Red;//设置seires中折点的颜色   
            //                                                       //    chart1.Series[1].Points[i].MarkerStyle = MarkerStyle.Square;//设置折点的风格     
            //                                                       //    chart1.Series[1].Points[i].MarkerColor = Color.Blue;//设置seires中折点的颜色  
            //                                                       //    chart1.Series[2].Points[i].MarkerStyle = MarkerStyle.Square;//设置折点的风格     
            //                                                       //    chart1.Series[2].Points[i].MarkerColor = Color.Green;//设置seires中折点的颜色  
            //}
            //for (int i = 0; i < chart1.Series[0].Points.Count; i++)
            //{
            //    chart4.Series[0].Points[i].MarkerStyle = MarkerStyle.Circle;//设置折点的风格     
            //    chart4.Series[0].Points[i].MarkerColor = Color.Red;//设置seires中折点的颜色   
            //                                                       //    chart1.Series[1].Points[i].MarkerStyle = MarkerStyle.Square;//设置折点的风格     
            //                                                       //    chart1.Series[1].Points[i].MarkerColor = Color.Blue;//设置seires中折点的颜色  
            //                                                       //    chart1.Series[2].Points[i].MarkerStyle = MarkerStyle.Square;//设置折点的风格     
            //                                                       //    chart1.Series[2].Points[i].MarkerColor = Color.Green;//设置seires中折点的颜色  
            //}
            //for (int i = 0; i < chart1.Series[0].Points.Count; i++)
            //{
            //    chart5.Series[0].Points[i].MarkerStyle = MarkerStyle.Circle;//设置折点的风格     
            //    chart5.Series[0].Points[i].MarkerColor = Color.Red;//设置seires中折点的颜色   
            //                                                       //    chart1.Series[1].Points[i].MarkerStyle = MarkerStyle.Square;//设置折点的风格     
            //                                                       //    chart1.Series[1].Points[i].MarkerColor = Color.Blue;//设置seires中折点的颜色  
            //                                                       //    chart1.Series[2].Points[i].MarkerStyle = MarkerStyle.Square;//设置折点的风格     
            //                                                       //    chart1.Series[2].Points[i].MarkerColor = Color.Green;//设置seires中折点的颜色  
            //}
            //for (int i = 0; i < chart1.Series[0].Points.Count; i++)
            //{
            //    chart6.Series[0].Points[i].MarkerStyle = MarkerStyle.Circle;//设置折点的风格     
            //    chart6.Series[0].Points[i].MarkerColor = Color.Red;//设置seires中折点的颜色   
            //                                                       //    chart1.Series[1].Points[i].MarkerStyle = MarkerStyle.Square;//设置折点的风格     
            //                                                       //    chart1.Series[1].Points[i].MarkerColor = Color.Blue;//设置seires中折点的颜色  
            //                                                       //    chart1.Series[2].Points[i].MarkerStyle = MarkerStyle.Square;//设置折点的风格     
            //                                                       //    chart1.Series[2].Points[i].MarkerColor = Color.Green;//设置seires中折点的颜色  
            //}
            

            //for (int i = 0; i < chart1.Series.Count; i++)
            //{
            //    for (int j = 0; j < chart1.Series[i].Points.Count; j++)
            //    {
            //        chart1.Series[i].Points[j].Label = " ";
            //        //chart1.Series[i].Points[j].LabelToolTip = "string.Empty";
            //    }
            //}
            ////chart1.ImageType = ChartImageType.Jpeg;
            ////反锯齿  
            //chart1.AntiAliasing = AntiAliasingStyles.All;
            ////调色板 磨沙:SemiTransparent  
            //chart1.Palette = ChartColorPalette.BrightPastel;

            //chart1.Series[0].ChartType = SeriesChartType.Radar;
            ////chart1.Series[1].ChartType = SeriesChartType.Radar;
            ////chart1.Series[2].ChartType = SeriesChartType.Radar;
            //chart1.Width = 500;
            //chart1.Height = 350;

            //for (int i = 0; i < chart2.Series.Count; i++)
            //{
            //    for (int j = 0; j < chart2.Series[i].Points.Count; j++)
            //    {
            //        chart2.Series[i].Points[j].Label = " ";
            //        //chart2.Series[i].Points[j].LabelToolTip = "string.Empty";
            //    }
            //}
            ////chart2.ImageType = ChartImageType.Jpeg;
            ////反锯齿  
            //chart2.AntiAliasing = AntiAliasingStyles.All;
            ////调色板 磨沙:SemiTransparent  
            //chart2.Palette = ChartColorPalette.BrightPastel;

            //chart2.Series[0].ChartType = SeriesChartType.Radar;
            ////chart2.Series[1].ChartType = SeriesChartType.Radar;
            ////chart2.Series[2].ChartType = SeriesChartType.Radar;
            //chart2.Width = 500;
            //chart2.Height = 350;

            //for (int i = 0; i < chart3.Series.Count; i++)
            //{
            //    for (int j = 0; j < chart3.Series[i].Points.Count; j++)
            //    {
            //        chart3.Series[i].Points[j].Label = " ";
            //        //chart3.Series[i].Points[j].LabelToolTip = "string.Empty";
            //    }
            //}
            ////chart3.ImageType = ChartImageType.Jpeg;
            ////反锯齿  
            //chart3.AntiAliasing = AntiAliasingStyles.All;
            ////调色板 磨沙:SemiTransparent  
            //chart3.Palette = ChartColorPalette.BrightPastel;

            //chart3.Series[0].ChartType = SeriesChartType.Radar;
            ////chart3.Series[1].ChartType = SeriesChartType.Radar;
            ////chart3.Series[2].ChartType = SeriesChartType.Radar;
            //chart3.Width = 500;
            //chart3.Height = 350;

            //for (int i = 0; i < chart4.Series.Count; i++)
            //{
            //    for (int j = 0; j < chart4.Series[i].Points.Count; j++)
            //    {
            //        chart4.Series[i].Points[j].Label = " ";
            //        //chart4.Series[i].Points[j].LabelToolTip = "string.Empty";
            //    }
            //}
            ////chart4.ImageType = ChartImageType.Jpeg;
            ////反锯齿  
            //chart4.AntiAliasing = AntiAliasingStyles.All;
            ////调色板 磨沙:SemiTransparent  
            //chart4.Palette = ChartColorPalette.BrightPastel;

            //chart4.Series[0].ChartType = SeriesChartType.Radar;
            ////chart4.Series[1].ChartType = SeriesChartType.Radar;
            ////chart4.Series[2].ChartType = SeriesChartType.Radar;
            //chart4.Width = 500;
            //chart4.Height = 350;

            //for (int i = 0; i < chart5.Series.Count; i++)
            //{
            //    for (int j = 0; j < chart5.Series[i].Points.Count; j++)
            //    {
            //        chart5.Series[i].Points[j].Label = " ";
            //        //chart5.Series[i].Points[j].LabelToolTip = "string.Empty";
            //    }
            //}
            ////chart5.ImageType = ChartImageType.Jpeg;
            ////反锯齿  
            //chart5.AntiAliasing = AntiAliasingStyles.All;
            ////调色板 磨沙:SemiTransparent  
            //chart5.Palette = ChartColorPalette.BrightPastel;

            //chart5.Series[0].ChartType = SeriesChartType.Radar;
            ////chart5.Series[1].ChartType = SeriesChartType.Radar;
            ////chart5.Series[2].ChartType = SeriesChartType.Radar;
            //chart5.Width = 500;
            //chart5.Height = 350;

            //for (int i = 0; i < chart6.Series.Count; i++)
            //{
            //    for (int j = 0; j < chart6.Series[i].Points.Count; j++)
            //    {
            //        chart6.Series[i].Points[j].Label = " ";
            //        //chart6.Series[i].Points[j].LabelToolTip = "string.Empty";
            //    }
            //}
            ////chart6.ImageType = ChartImageType.Jpeg;
            ////反锯齿  
            //chart6.AntiAliasing = AntiAliasingStyles.All;
            ////调色板 磨沙:SemiTransparent  
            //chart6.Palette = ChartColorPalette.BrightPastel;

            //chart6.Series[0].ChartType = SeriesChartType.Radar;
            ////chart6.Series[1].ChartType = SeriesChartType.Radar;
            ////chart6.Series[2].ChartType = SeriesChartType.Radar;
            //chart6.Width = 500;
            //chart6.Height = 350;

        }
        private static void draw(Chart chart1)
        {
            chart1.BackColor = Color.Transparent;
            chart1.ChartAreas[0].BackColor = Color.Transparent;
            chart1.ChartAreas[0].BorderColor = Color.Red;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#2c4c6d");
            chart1.ChartAreas[0].AxisY.LineColor = ColorTranslator.FromHtml("#38587a");
            chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Black;
            chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("微软雅黑", 10f, FontStyle.Regular);
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#2c4c6d");
            chart1.ChartAreas[0].AxisY2.LineColor = Color.Red;
            chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart1.ChartAreas[0].AxisX.IsInterlaced = false;
            chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart1.ChartAreas[0].AxisY.MajorTickMark.Enabled = true;
            chart1.ChartAreas[0].AxisY.LabelStyle.Enabled = true;
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            new 轿车().Show();
            Form f6 = new 轿车();
            轿车.jc.uiCheckBox14.Checked = true;
            轿车.jc.uiCheckBox24.Checked = true;
            轿车.jc.uiCheckBox26.Checked = true;
            轿车.jc.uiCheckBox31.Checked = true;
            轿车.jc.uiCheckBox28.Checked = true;
        }

        private void uiSymbolButton4_Click(object sender, EventArgs e)
        {
            new Form3().Show();
            Form f6 = new Form3();
            Form3.SUV.uiCheckBox14.Checked = true;
            Form3.SUV.uiCheckBox19.Checked = true;
            Form3.SUV.uiCheckBox55.Checked = true;
            Form3.SUV.uiCheckBox34.Checked = true;
            Form3.SUV.uiCheckBox12.Checked = true;
            Form3.SUV.uiCheckBox7.Checked = true;

        }

        private void uiSymbolButton5_Click(object sender, EventArgs e)
        {
            new Form3().Show();
            Form f6 = new Form3();
            Form3.SUV.uiCheckBox7.Checked = true;
            Form3.SUV.uiCheckBox15.Checked = true;
            Form3.SUV.uiCheckBox55.Checked = true;
            Form3.SUV.uiCheckBox13.Checked = true;
            Form3.SUV.uiCheckBox51.Checked = true;
            Form3.SUV.uiCheckBox36.Checked = true;
            Form3.SUV.uiCheckBox39.Checked = true;
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            Form f6 = new Form1();
            Form1.sw.uiCheckBox6.Checked = true;
            Form1.sw.uiCheckBox11.Checked = true;
            Form1.sw.uiCheckBox13.Checked = true;
            Form1.sw.uiCheckBox16.Checked = true;
            Form1.sw.uiCheckBox14.Checked = true;
            Form1.sw.uiCheckBox17.Checked = true;
            Form1.sw.uiCheckBox19.Checked = true;
            Form1.sw.uiCheckBox22.Checked = true;
        }

        private void uiSymbolButton3_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            Form f6 = new Form1();
            Form1.sw.uiCheckBox19.Checked = true;
            Form1.sw.uiCheckBox30.Checked = true;
            Form1.sw.uiCheckBox5.Checked = true;
            Form1.sw.uiCheckBox8.Checked = true;
            Form1.sw.uiCheckBox7.Checked = true;
            Form1.sw.uiCheckBox14.Checked = true;
            Form1.sw.uiCheckBox15.Checked = true;
        }

        private void uiSymbolButton6_Click(object sender, EventArgs e)
        {
            new Form3().Show();
            Form f6 = new Form3();
            Form3.SUV.uiCheckBox46.Checked = true;
            Form3.SUV.uiCheckBox4.Checked = true;
            Form3.SUV.uiCheckBox5.Checked = true;
            Form3.SUV.uiCheckBox49.Checked = true;
            Form3.SUV.uiCheckBox37.Checked = true;
            Form3.SUV.uiCheckBox27.Checked = true;
            Form3.SUV.uiCheckBox35.Checked = true;
            Form3.SUV.uiCheckBox22.Checked = true;
        }
    }
}
