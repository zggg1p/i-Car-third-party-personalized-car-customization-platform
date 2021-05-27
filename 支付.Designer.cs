
namespace i_car1
{
    partial class 支付
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(支付));
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uiRadioButton2 = new Sunny.UI.UIRadioButton();
            this.uiRadioButton1 = new Sunny.UI.UIRadioButton();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("黑体", 18F);
            this.uiLabel2.Location = new System.Drawing.Point(450, 120);
            this.uiLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(166, 37);
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "uiLabel2";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("黑体", 18F);
            this.uiLabel3.Location = new System.Drawing.Point(197, 35);
            this.uiLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(419, 45);
            this.uiLabel3.TabIndex = 2;
            this.uiLabel3.Text = "uiLabel3";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.pictureBox1);
            this.uiGroupBox1.Controls.Add(this.uiRadioButton2);
            this.uiGroupBox1.Controls.Add(this.uiRadioButton1);
            this.uiGroupBox1.FillColor = System.Drawing.Color.White;
            this.uiGroupBox1.Font = new System.Drawing.Font("黑体", 12F);
            this.uiGroupBox1.Location = new System.Drawing.Point(40, 200);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 26, 0, 0);
            this.uiGroupBox1.RectColor = System.Drawing.Color.White;
            this.uiGroupBox1.Size = new System.Drawing.Size(576, 517);
            this.uiGroupBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiGroupBox1.TabIndex = 3;
            this.uiGroupBox1.Text = null;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(126, 127);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(298, 281);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // uiRadioButton2
            // 
            this.uiRadioButton2.BackColor = System.Drawing.Color.Transparent;
            this.uiRadioButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButton2.Font = new System.Drawing.Font("黑体", 18F);
            this.uiRadioButton2.Location = new System.Drawing.Point(330, 29);
            this.uiRadioButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRadioButton2.Name = "uiRadioButton2";
            this.uiRadioButton2.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiRadioButton2.RadioButtonColor = System.Drawing.Color.Gray;
            this.uiRadioButton2.Size = new System.Drawing.Size(94, 38);
            this.uiRadioButton2.Style = Sunny.UI.UIStyle.Custom;
            this.uiRadioButton2.TabIndex = 1;
            this.uiRadioButton2.Text = "微信";
            this.uiRadioButton2.ValueChanged += new Sunny.UI.UIRadioButton.OnValueChanged(this.uiRadioButton2_ValueChanged);
            // 
            // uiRadioButton1
            // 
            this.uiRadioButton1.BackColor = System.Drawing.Color.Transparent;
            this.uiRadioButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButton1.Font = new System.Drawing.Font("黑体", 18F);
            this.uiRadioButton1.Location = new System.Drawing.Point(126, 29);
            this.uiRadioButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRadioButton1.Name = "uiRadioButton1";
            this.uiRadioButton1.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiRadioButton1.RadioButtonColor = System.Drawing.Color.Gray;
            this.uiRadioButton1.Size = new System.Drawing.Size(126, 38);
            this.uiRadioButton1.Style = Sunny.UI.UIStyle.Custom;
            this.uiRadioButton1.TabIndex = 0;
            this.uiRadioButton1.Text = "支付宝";
            this.uiRadioButton1.ValueChanged += new Sunny.UI.UIRadioButton.OnValueChanged(this.uiRadioButton1_ValueChanged);
            // 
            // 支付
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(658, 751);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel2);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "支付";
            this.Text = "支付";
            this.Load += new System.EventHandler(this.支付_Load);
            this.uiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UIRadioButton uiRadioButton2;
        private Sunny.UI.UIRadioButton uiRadioButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}