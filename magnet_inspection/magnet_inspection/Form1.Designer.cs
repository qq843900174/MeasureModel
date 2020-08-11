namespace magnet_inspection
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Do = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.trackBar_Threshold = new System.Windows.Forms.TrackBar();
            this.button_Roi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Threshold = new System.Windows.Forms.TextBox();
            this.button_Threshold = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Open_Picture = new System.Windows.Forms.Button();
            this.button_Input_Set = new System.Windows.Forms.Button();
            this.hWindowControl1 = new HalconDotNet.HWindowControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Threshold)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Do
            // 
            this.button_Do.Location = new System.Drawing.Point(824, 51);
            this.button_Do.Name = "button_Do";
            this.button_Do.Size = new System.Drawing.Size(86, 49);
            this.button_Do.TabIndex = 1;
            this.button_Do.Text = "物料检测";
            this.button_Do.UseVisualStyleBackColor = true;
            this.button_Do.Click += new System.EventHandler(this.button_Do_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 619);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // trackBar_Threshold
            // 
            this.trackBar_Threshold.Location = new System.Drawing.Point(116, 515);
            this.trackBar_Threshold.Maximum = 255;
            this.trackBar_Threshold.Name = "trackBar_Threshold";
            this.trackBar_Threshold.Size = new System.Drawing.Size(104, 56);
            this.trackBar_Threshold.TabIndex = 4;
            this.trackBar_Threshold.Scroll += new System.EventHandler(this.trackBar_Threshold_Scroll);
            // 
            // button_Roi
            // 
            this.button_Roi.Location = new System.Drawing.Point(420, 515);
            this.button_Roi.Name = "button_Roi";
            this.button_Roi.Size = new System.Drawing.Size(98, 45);
            this.button_Roi.TabIndex = 5;
            this.button_Roi.Text = "绘制ROI";
            this.button_Roi.UseVisualStyleBackColor = true;
            this.button_Roi.Click += new System.EventHandler(this.button_Roi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 515);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "二值化阈值：";
            // 
            // textBox_Threshold
            // 
            this.textBox_Threshold.Location = new System.Drawing.Point(238, 515);
            this.textBox_Threshold.Name = "textBox_Threshold";
            this.textBox_Threshold.Size = new System.Drawing.Size(38, 25);
            this.textBox_Threshold.TabIndex = 7;
            this.textBox_Threshold.Text = "0";
            // 
            // button_Threshold
            // 
            this.button_Threshold.Location = new System.Drawing.Point(299, 515);
            this.button_Threshold.Name = "button_Threshold";
            this.button_Threshold.Size = new System.Drawing.Size(98, 45);
            this.button_Threshold.TabIndex = 8;
            this.button_Threshold.Text = "二值化显示";
            this.button_Threshold.UseVisualStyleBackColor = true;
            this.button_Threshold.Click += new System.EventHandler(this.button_Threshold_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(659, 400);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(276, 198);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(659, 382);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "输出结果：";
            // 
            // button_Open_Picture
            // 
            this.button_Open_Picture.Location = new System.Drawing.Point(698, 51);
            this.button_Open_Picture.Name = "button_Open_Picture";
            this.button_Open_Picture.Size = new System.Drawing.Size(86, 49);
            this.button_Open_Picture.TabIndex = 11;
            this.button_Open_Picture.Text = "打开图片";
            this.button_Open_Picture.UseVisualStyleBackColor = true;
            this.button_Open_Picture.Click += new System.EventHandler(this.button_Open_Picture_Click);
            // 
            // button_Input_Set
            // 
            this.button_Input_Set.Location = new System.Drawing.Point(541, 515);
            this.button_Input_Set.Name = "button_Input_Set";
            this.button_Input_Set.Size = new System.Drawing.Size(98, 45);
            this.button_Input_Set.TabIndex = 12;
            this.button_Input_Set.Text = "输入设置";
            this.button_Input_Set.UseVisualStyleBackColor = true;
            this.button_Input_Set.Click += new System.EventHandler(this.button_Input_Set_Click);
            // 
            // hWindowControl1
            // 
            this.hWindowControl1.BackColor = System.Drawing.Color.Black;
            this.hWindowControl1.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControl1.Location = new System.Drawing.Point(0, 0);
            this.hWindowControl1.Name = "hWindowControl1";
            this.hWindowControl1.Size = new System.Drawing.Size(640, 480);
            this.hWindowControl1.TabIndex = 13;
            this.hWindowControl1.WindowSize = new System.Drawing.Size(640, 480);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(653, 512);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.hWindowControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(645, 483);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(667, 464);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 619);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button_Input_Set);
            this.Controls.Add(this.button_Open_Picture);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button_Threshold);
            this.Controls.Add(this.textBox_Threshold);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Roi);
            this.Controls.Add(this.trackBar_Threshold);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.button_Do);
            this.Name = "Form1";
            this.Text = "Magnet_inspect";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Threshold)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_Do;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TrackBar trackBar_Threshold;
        private System.Windows.Forms.Button button_Roi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Threshold;
        private System.Windows.Forms.Button button_Threshold;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Open_Picture;
        private System.Windows.Forms.Button button_Input_Set;
        private HalconDotNet.HWindowControl hWindowControl1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

