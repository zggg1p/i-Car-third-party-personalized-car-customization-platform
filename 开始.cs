using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace i_car1
{
    public partial class 开始 : Form
    {
        public 开始()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            登录 f = new 登录();
            f.Show();//进入登陆页面
            this.Close();

        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            注册 f = new 注册();
            f.Show();//进入注册页面
            this.Close();
        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {
        }

        private void uiLabel2_Click(object sender, EventArgs e)
        {
            new 厂商注册().Show();
            Form f7 = new 厂商注册();//进入厂商注册页面
            this.Close();
        }

        private void uiLabel3_Click(object sender, EventArgs e)
        {
            new 厂商登录().Show();
            Form f7 = new 厂商登录();//进入厂商登录页面
            this.Close();
        }

        private void uiSymbolButton1_MouseDown(object sender, MouseEventArgs e)
        {
            uiSymbolButton1.Visible = false;
        }
        private void uiSymbolButton2_MouseDown(object sender, MouseEventArgs e)
        {
            uiSymbolButton2.Visible = false;
        }

    }
}
