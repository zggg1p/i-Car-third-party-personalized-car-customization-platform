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
    public partial class 进入页面 : Form
    {
        public 进入页面()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void 进入页面_Load(object sender, EventArgs e)
        {

        }

        private void 进入页面_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            new 开始().Show();
            Form f7 = new 开始();//进入厂商注册页面
        }
    }
}
