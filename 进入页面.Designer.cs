
namespace i_car1
{
    partial class 进入页面
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(进入页面));
            this.uiButton1 = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // uiButton1
            // 
            this.uiButton1.BackColor = System.Drawing.Color.Transparent;
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.FillColor = System.Drawing.Color.Transparent;
            this.uiButton1.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiButton1.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiButton1.FillPressColor = System.Drawing.Color.Transparent;
            this.uiButton1.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton1.ForeColor = System.Drawing.Color.Transparent;
            this.uiButton1.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiButton1.Location = new System.Drawing.Point(732, 333);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.RectColor = System.Drawing.Color.Transparent;
            this.uiButton1.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiButton1.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiButton1.RectPressColor = System.Drawing.Color.Transparent;
            this.uiButton1.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiButton1.Size = new System.Drawing.Size(413, 407);
            this.uiButton1.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton1.TabIndex = 2;
            this.uiButton1.Click += new System.EventHandler(this.label2_Click);
            // 
            // 进入页面
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1885, 1061);
            this.Controls.Add(this.uiButton1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "进入页面";
            this.Text = "i-car";
            this.Load += new System.EventHandler(this.进入页面_Load);
            this.Click += new System.EventHandler(this.进入页面_Click);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIButton uiButton1;
    }
}