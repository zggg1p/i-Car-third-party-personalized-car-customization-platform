namespace i_car1
{
    partial class 登录
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(登录));
            this.picValidCode = new System.Windows.Forms.PictureBox();
            this.uiTextBox1 = new Sunny.UI.UITextBox();
            this.uiTextBox2 = new Sunny.UI.UITextBox();
            this.uiSymbolLabel2 = new Sunny.UI.UISymbolLabel();
            this.uiSymbolLabel1 = new Sunny.UI.UISymbolLabel();
            this.uiTextBox3 = new Sunny.UI.UITextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picValidCode)).BeginInit();
            this.SuspendLayout();
            // 
            // picValidCode
            // 
            this.picValidCode.BackColor = System.Drawing.Color.Transparent;
            this.picValidCode.Location = new System.Drawing.Point(1004, 483);
            this.picValidCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picValidCode.Name = "picValidCode";
            this.picValidCode.Size = new System.Drawing.Size(112, 30);
            this.picValidCode.TabIndex = 20;
            this.picValidCode.TabStop = false;
            this.picValidCode.Click += new System.EventHandler(this.picValidCode_Click);
            // 
            // uiTextBox1
            // 
            this.uiTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.uiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox1.FillColor = System.Drawing.Color.White;
            this.uiTextBox1.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.uiTextBox1.Location = new System.Drawing.Point(718, 306);
            this.uiTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.uiTextBox1.Maximum = 2147483647D;
            this.uiTextBox1.Minimum = -2147483648D;
            this.uiTextBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTextBox1.Name = "uiTextBox1";
            this.uiTextBox1.Padding = new System.Windows.Forms.Padding(4);
            this.uiTextBox1.RectColor = System.Drawing.Color.Transparent;
            this.uiTextBox1.Size = new System.Drawing.Size(258, 39);
            this.uiTextBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBox1.TabIndex = 22;
            // 
            // uiTextBox2
            // 
            this.uiTextBox2.BackColor = System.Drawing.Color.Transparent;
            this.uiTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox2.FillColor = System.Drawing.Color.White;
            this.uiTextBox2.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.uiTextBox2.Location = new System.Drawing.Point(718, 394);
            this.uiTextBox2.Margin = new System.Windows.Forms.Padding(4);
            this.uiTextBox2.Maximum = 2147483647D;
            this.uiTextBox2.Minimum = -2147483648D;
            this.uiTextBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTextBox2.Name = "uiTextBox2";
            this.uiTextBox2.Padding = new System.Windows.Forms.Padding(4);
            this.uiTextBox2.PasswordChar = '*';
            this.uiTextBox2.RectColor = System.Drawing.Color.Transparent;
            this.uiTextBox2.Size = new System.Drawing.Size(258, 39);
            this.uiTextBox2.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBox2.TabIndex = 23;
            // 
            // uiSymbolLabel2
            // 
            this.uiSymbolLabel2.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolLabel2.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.uiSymbolLabel2.Location = new System.Drawing.Point(932, 553);
            this.uiSymbolLabel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolLabel2.Name = "uiSymbolLabel2";
            this.uiSymbolLabel2.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.uiSymbolLabel2.Size = new System.Drawing.Size(184, 56);
            this.uiSymbolLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolLabel2.Symbol = 61453;
            this.uiSymbolLabel2.TabIndex = 26;
            this.uiSymbolLabel2.Text = "CANCEL";
            this.uiSymbolLabel2.Click += new System.EventHandler(this.no_Click);
            // 
            // uiSymbolLabel1
            // 
            this.uiSymbolLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolLabel1.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.uiSymbolLabel1.Location = new System.Drawing.Point(718, 540);
            this.uiSymbolLabel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolLabel1.Name = "uiSymbolLabel1";
            this.uiSymbolLabel1.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.uiSymbolLabel1.Size = new System.Drawing.Size(135, 84);
            this.uiSymbolLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolLabel1.TabIndex = 25;
            this.uiSymbolLabel1.Text = "OK";
            this.uiSymbolLabel1.Click += new System.EventHandler(this.yes_Click);
            // 
            // uiTextBox3
            // 
            this.uiTextBox3.BackColor = System.Drawing.Color.Transparent;
            this.uiTextBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox3.FillColor = System.Drawing.Color.White;
            this.uiTextBox3.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.uiTextBox3.Location = new System.Drawing.Point(718, 483);
            this.uiTextBox3.Margin = new System.Windows.Forms.Padding(4);
            this.uiTextBox3.Maximum = 2147483647D;
            this.uiTextBox3.Minimum = -2147483648D;
            this.uiTextBox3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTextBox3.Name = "uiTextBox3";
            this.uiTextBox3.Padding = new System.Windows.Forms.Padding(4);
            this.uiTextBox3.PasswordChar = '*';
            this.uiTextBox3.RectColor = System.Drawing.Color.Transparent;
            this.uiTextBox3.Size = new System.Drawing.Size(258, 39);
            this.uiTextBox3.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBox3.TabIndex = 25;
            // 
            // 登录
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1310, 737);
            this.Controls.Add(this.uiSymbolLabel2);
            this.Controls.Add(this.uiTextBox3);
            this.Controls.Add(this.uiSymbolLabel1);
            this.Controls.Add(this.uiTextBox1);
            this.Controls.Add(this.uiTextBox2);
            this.Controls.Add(this.picValidCode);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "登录";
            this.Text = "登录";
            this.Load += new System.EventHandler(this.Form14_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picValidCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picValidCode;
        private Sunny.UI.UITextBox uiTextBox1;
        private Sunny.UI.UITextBox uiTextBox2;
        private Sunny.UI.UISymbolLabel uiSymbolLabel2;
        private Sunny.UI.UISymbolLabel uiSymbolLabel1;
        private Sunny.UI.UITextBox uiTextBox3;
    }
}