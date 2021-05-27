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
    public partial class 说明 : Form
    {
        public 说明()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void uiCheckBox1_ValueChanged(object sender, bool value)
        {
            new 支付().Show();
            Form f6 = new 支付();//进入支付页面
        }
    }
}
