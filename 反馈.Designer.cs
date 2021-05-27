
namespace i_car1
{
    partial class 反馈
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(反馈));
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiRichTextBox1 = new Sunny.UI.UIRichTextBox();
            this.SuspendLayout();
            // 
            // uiLabel2
            // 
            this.uiLabel2.BackColor = System.Drawing.Color.White;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.uiLabel2.Location = new System.Drawing.Point(185, 62);
            this.uiLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(400, 40);
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "uiLabel2";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.BackColor = System.Drawing.Color.White;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.uiLabel4.Location = new System.Drawing.Point(101, 134);
            this.uiLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(160, 36);
            this.uiLabel4.TabIndex = 3;
            this.uiLabel4.Text = "uiLabel4";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel6
            // 
            this.uiLabel6.BackColor = System.Drawing.Color.White;
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.uiLabel6.Location = new System.Drawing.Point(428, 134);
            this.uiLabel6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(157, 36);
            this.uiLabel6.TabIndex = 5;
            this.uiLabel6.Text = "uiLabel6";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiRichTextBox1
            // 
            this.uiRichTextBox1.AutoWordSelection = true;
            this.uiRichTextBox1.FillColor = System.Drawing.Color.White;
            this.uiRichTextBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiRichTextBox1.Location = new System.Drawing.Point(39, 258);
            this.uiRichTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiRichTextBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRichTextBox1.Name = "uiRichTextBox1";
            this.uiRichTextBox1.Padding = new System.Windows.Forms.Padding(2);
            this.uiRichTextBox1.RectColor = System.Drawing.Color.White;
            this.uiRichTextBox1.Size = new System.Drawing.Size(546, 354);
            this.uiRichTextBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiRichTextBox1.TabIndex = 7;
            // 
            // 反馈
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(624, 677);
            this.Controls.Add(this.uiRichTextBox1);
            this.Controls.Add(this.uiLabel6);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.uiLabel2);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "反馈";
            this.Text = "反馈";
            this.Load += new System.EventHandler(this.反馈_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UIRichTextBox uiRichTextBox1;
    }
}