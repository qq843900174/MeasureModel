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
            this.button_Open_Picture = new System.Windows.Forms.Button();
            this.button_Input_Set = new System.Windows.Forms.Button();
            this.hWindowControl1 = new HalconDotNet.HWindowControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ModelMatch_checkBox = new System.Windows.Forms.CheckBox();
            this.buttonTestModel = new System.Windows.Forms.Button();
            this.buttonSaveModel = new System.Windows.Forms.Button();
            this.buttonCreateModel = new System.Windows.Forms.Button();
            this.buttonSetModel = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonClearMetrology = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonDrawCircle2 = new System.Windows.Forms.Button();
            this.buttonDrawLine2 = new System.Windows.Forms.Button();
            this.buttonDrawCircle1 = new System.Windows.Forms.Button();
            this.Metrology_checkBox = new System.Windows.Forms.CheckBox();
            this.buttonTestMetrology = new System.Windows.Forms.Button();
            this.buttonSaveMetrology = new System.Windows.Forms.Button();
            this.buttonCreateMetrology = new System.Windows.Forms.Button();
            this.buttonDrawLine1 = new System.Windows.Forms.Button();
            this.ModelAngle_textBox = new System.Windows.Forms.TextBox();
            this.labelModelAngle = new System.Windows.Forms.Label();
            this.ModelColumn_textBox = new System.Windows.Forms.TextBox();
            this.labelModelColumn = new System.Windows.Forms.Label();
            this.ModelRow_textBox = new System.Windows.Forms.TextBox();
            this.labelModelRow = new System.Windows.Forms.Label();
            this.buttonAcqGrab = new System.Windows.Forms.Button();
            this.buttonStopAcqGrab = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxResultLog = new System.Windows.Forms.TextBox();
            this.buttonAdapt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Threshold)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Do
            // 
            this.button_Do.Location = new System.Drawing.Point(824, 213);
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
            this.splitter1.Size = new System.Drawing.Size(3, 579);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // trackBar_Threshold
            // 
            this.trackBar_Threshold.Location = new System.Drawing.Point(104, 518);
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
            this.label1.Location = new System.Drawing.Point(1, 537);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "二值化阈值：";
            // 
            // textBox_Threshold
            // 
            this.textBox_Threshold.Location = new System.Drawing.Point(227, 527);
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
            // button_Open_Picture
            // 
            this.button_Open_Picture.Location = new System.Drawing.Point(678, 213);
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

            this.hWindowControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Image_MouseDown);
            this.hWindowControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Image_MouseUp);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
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
            this.tabPage1.Text = "主界面";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ModelMatch_checkBox);
            this.tabPage2.Controls.Add(this.buttonTestModel);
            this.tabPage2.Controls.Add(this.buttonSaveModel);
            this.tabPage2.Controls.Add(this.buttonCreateModel);
            this.tabPage2.Controls.Add(this.buttonSetModel);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(645, 483);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "创建模板";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ModelMatch_checkBox
            // 
            this.ModelMatch_checkBox.AutoSize = true;
            this.ModelMatch_checkBox.Location = new System.Drawing.Point(9, 7);
            this.ModelMatch_checkBox.Margin = new System.Windows.Forms.Padding(4);
            this.ModelMatch_checkBox.Name = "ModelMatch_checkBox";
            this.ModelMatch_checkBox.Size = new System.Drawing.Size(119, 19);
            this.ModelMatch_checkBox.TabIndex = 31;
            this.ModelMatch_checkBox.Text = "模板匹配使能";
            this.ModelMatch_checkBox.UseVisualStyleBackColor = true;
            // 
            // buttonTestModel
            // 
            this.buttonTestModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(196)))));
            this.buttonTestModel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonTestModel.Location = new System.Drawing.Point(234, 277);
            this.buttonTestModel.Name = "buttonTestModel";
            this.buttonTestModel.Size = new System.Drawing.Size(179, 58);
            this.buttonTestModel.TabIndex = 3;
            this.buttonTestModel.Text = "模拟定位";
            this.buttonTestModel.UseVisualStyleBackColor = false;
            this.buttonTestModel.Click += new System.EventHandler(this.buttonTestModel_Click);
            // 
            // buttonSaveModel
            // 
            this.buttonSaveModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(196)))));
            this.buttonSaveModel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSaveModel.Location = new System.Drawing.Point(460, 419);
            this.buttonSaveModel.Name = "buttonSaveModel";
            this.buttonSaveModel.Size = new System.Drawing.Size(179, 58);
            this.buttonSaveModel.TabIndex = 2;
            this.buttonSaveModel.Text = "保存模板";
            this.buttonSaveModel.UseVisualStyleBackColor = false;
            this.buttonSaveModel.Click += new System.EventHandler(this.buttonSaveModel_Click);
            // 
            // buttonCreateModel
            // 
            this.buttonCreateModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(196)))));
            this.buttonCreateModel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonCreateModel.Location = new System.Drawing.Point(234, 167);
            this.buttonCreateModel.Name = "buttonCreateModel";
            this.buttonCreateModel.Size = new System.Drawing.Size(179, 58);
            this.buttonCreateModel.TabIndex = 1;
            this.buttonCreateModel.Text = "创建模板";
            this.buttonCreateModel.UseVisualStyleBackColor = false;
            this.buttonCreateModel.Click += new System.EventHandler(this.buttonCreateModel_Click);
            // 
            // buttonSetModel
            // 
            this.buttonSetModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(196)))));
            this.buttonSetModel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSetModel.Location = new System.Drawing.Point(234, 57);
            this.buttonSetModel.Name = "buttonSetModel";
            this.buttonSetModel.Size = new System.Drawing.Size(179, 58);
            this.buttonSetModel.TabIndex = 0;
            this.buttonSetModel.Text = "模板选取";
            this.buttonSetModel.UseVisualStyleBackColor = false;
            this.buttonSetModel.Click += new System.EventHandler(this.buttonSetModel_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonClearMetrology);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.buttonDrawCircle2);
            this.tabPage3.Controls.Add(this.buttonDrawLine2);
            this.tabPage3.Controls.Add(this.buttonDrawCircle1);
            this.tabPage3.Controls.Add(this.Metrology_checkBox);
            this.tabPage3.Controls.Add(this.buttonTestMetrology);
            this.tabPage3.Controls.Add(this.buttonSaveMetrology);
            this.tabPage3.Controls.Add(this.buttonCreateMetrology);
            this.tabPage3.Controls.Add(this.buttonDrawLine1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(645, 483);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "创建测量工具";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonClearMetrology
            // 
            this.buttonClearMetrology.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(196)))));
            this.buttonClearMetrology.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonClearMetrology.Location = new System.Drawing.Point(244, 418);
            this.buttonClearMetrology.Name = "buttonClearMetrology";
            this.buttonClearMetrology.Size = new System.Drawing.Size(179, 58);
            this.buttonClearMetrology.TabIndex = 50;
            this.buttonClearMetrology.Text = "清空测量工具";
            this.buttonClearMetrology.UseVisualStyleBackColor = false;
            this.buttonClearMetrology.Click += new System.EventHandler(this.buttonClearMetrology_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(196)))));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(371, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 58);
            this.button1.TabIndex = 49;
            this.button1.Text = "测量圆或圆弧2参数";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(196)))));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(369, 110);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(179, 58);
            this.button2.TabIndex = 48;
            this.button2.Text = "测量直线2参数";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(196)))));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button3.Location = new System.Drawing.Point(371, 188);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(179, 58);
            this.button3.TabIndex = 47;
            this.button3.Text = "测量圆或圆弧1参数";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(196)))));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button4.Location = new System.Drawing.Point(369, 32);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(179, 58);
            this.button4.TabIndex = 46;
            this.button4.Text = "测量直线1参数";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // buttonDrawCircle2
            // 
            this.buttonDrawCircle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(196)))));
            this.buttonDrawCircle2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonDrawCircle2.Location = new System.Drawing.Point(114, 266);
            this.buttonDrawCircle2.Name = "buttonDrawCircle2";
            this.buttonDrawCircle2.Size = new System.Drawing.Size(179, 58);
            this.buttonDrawCircle2.TabIndex = 45;
            this.buttonDrawCircle2.Text = "测量圆或圆弧2";
            this.buttonDrawCircle2.UseVisualStyleBackColor = false;
            this.buttonDrawCircle2.Click += new System.EventHandler(this.buttonDrawCircle2_Click);
            // 
            // buttonDrawLine2
            // 
            this.buttonDrawLine2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(196)))));
            this.buttonDrawLine2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonDrawLine2.Location = new System.Drawing.Point(112, 110);
            this.buttonDrawLine2.Name = "buttonDrawLine2";
            this.buttonDrawLine2.Size = new System.Drawing.Size(179, 58);
            this.buttonDrawLine2.TabIndex = 44;
            this.buttonDrawLine2.Text = "测量直线2";
            this.buttonDrawLine2.UseVisualStyleBackColor = false;
            this.buttonDrawLine2.Click += new System.EventHandler(this.buttonDrawLine2_Click);
            // 
            // buttonDrawCircle1
            // 
            this.buttonDrawCircle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(196)))));
            this.buttonDrawCircle1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonDrawCircle1.Location = new System.Drawing.Point(114, 188);
            this.buttonDrawCircle1.Name = "buttonDrawCircle1";
            this.buttonDrawCircle1.Size = new System.Drawing.Size(179, 58);
            this.buttonDrawCircle1.TabIndex = 43;
            this.buttonDrawCircle1.Text = "测量圆或圆弧1";
            this.buttonDrawCircle1.UseVisualStyleBackColor = false;
            this.buttonDrawCircle1.Click += new System.EventHandler(this.buttonDrawCircle1_Click);
            // 
            // Metrology_checkBox
            // 
            this.Metrology_checkBox.AutoSize = true;
            this.Metrology_checkBox.Location = new System.Drawing.Point(7, 6);
            this.Metrology_checkBox.Margin = new System.Windows.Forms.Padding(4);
            this.Metrology_checkBox.Name = "Metrology_checkBox";
            this.Metrology_checkBox.Size = new System.Drawing.Size(119, 19);
            this.Metrology_checkBox.TabIndex = 42;
            this.Metrology_checkBox.Text = "测量工具使能";
            this.Metrology_checkBox.UseVisualStyleBackColor = true;
            // 
            // buttonTestMetrology
            // 
            this.buttonTestMetrology.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(196)))));
            this.buttonTestMetrology.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonTestMetrology.Location = new System.Drawing.Point(23, 418);
            this.buttonTestMetrology.Name = "buttonTestMetrology";
            this.buttonTestMetrology.Size = new System.Drawing.Size(179, 58);
            this.buttonTestMetrology.TabIndex = 35;
            this.buttonTestMetrology.Text = "模拟测量";
            this.buttonTestMetrology.UseVisualStyleBackColor = false;
            this.buttonTestMetrology.Click += new System.EventHandler(this.buttonTestMetrology_Click);
            // 
            // buttonSaveMetrology
            // 
            this.buttonSaveMetrology.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(196)))));
            this.buttonSaveMetrology.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSaveMetrology.Location = new System.Drawing.Point(458, 418);
            this.buttonSaveMetrology.Name = "buttonSaveMetrology";
            this.buttonSaveMetrology.Size = new System.Drawing.Size(179, 58);
            this.buttonSaveMetrology.TabIndex = 34;
            this.buttonSaveMetrology.Text = "保存测量工具";
            this.buttonSaveMetrology.UseVisualStyleBackColor = false;
            this.buttonSaveMetrology.Click += new System.EventHandler(this.buttonSaveMetrology_Click);
            // 
            // buttonCreateMetrology
            // 
            this.buttonCreateMetrology.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(196)))));
            this.buttonCreateMetrology.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonCreateMetrology.Location = new System.Drawing.Point(244, 348);
            this.buttonCreateMetrology.Name = "buttonCreateMetrology";
            this.buttonCreateMetrology.Size = new System.Drawing.Size(179, 58);
            this.buttonCreateMetrology.TabIndex = 33;
            this.buttonCreateMetrology.Text = "创建测量工具";
            this.buttonCreateMetrology.UseVisualStyleBackColor = false;
            this.buttonCreateMetrology.Click += new System.EventHandler(this.buttonCreateMetrology_Click);
            // 
            // buttonDrawLine1
            // 
            this.buttonDrawLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(196)))));
            this.buttonDrawLine1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonDrawLine1.Location = new System.Drawing.Point(112, 32);
            this.buttonDrawLine1.Name = "buttonDrawLine1";
            this.buttonDrawLine1.Size = new System.Drawing.Size(179, 58);
            this.buttonDrawLine1.TabIndex = 32;
            this.buttonDrawLine1.Text = "测量直线1";
            this.buttonDrawLine1.UseVisualStyleBackColor = false;
            this.buttonDrawLine1.Click += new System.EventHandler(this.buttonDrawLine1_Click);
            // 
            // ModelAngle_textBox
            // 
            this.ModelAngle_textBox.Location = new System.Drawing.Point(775, 360);
            this.ModelAngle_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.ModelAngle_textBox.Name = "ModelAngle_textBox";
            this.ModelAngle_textBox.Size = new System.Drawing.Size(73, 25);
            this.ModelAngle_textBox.TabIndex = 30;
            // 
            // labelModelAngle
            // 
            this.labelModelAngle.AutoSize = true;
            this.labelModelAngle.Location = new System.Drawing.Point(718, 363);
            this.labelModelAngle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelModelAngle.Name = "labelModelAngle";
            this.labelModelAngle.Size = new System.Drawing.Size(55, 15);
            this.labelModelAngle.TabIndex = 29;
            this.labelModelAngle.Text = "Angle:";
            // 
            // ModelColumn_textBox
            // 
            this.ModelColumn_textBox.Location = new System.Drawing.Point(775, 320);
            this.ModelColumn_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.ModelColumn_textBox.Name = "ModelColumn_textBox";
            this.ModelColumn_textBox.Size = new System.Drawing.Size(73, 25);
            this.ModelColumn_textBox.TabIndex = 28;
            // 
            // labelModelColumn
            // 
            this.labelModelColumn.AutoSize = true;
            this.labelModelColumn.Location = new System.Drawing.Point(710, 323);
            this.labelModelColumn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelModelColumn.Name = "labelModelColumn";
            this.labelModelColumn.Size = new System.Drawing.Size(63, 15);
            this.labelModelColumn.TabIndex = 27;
            this.labelModelColumn.Text = "Column:";
            // 
            // ModelRow_textBox
            // 
            this.ModelRow_textBox.Location = new System.Drawing.Point(775, 280);
            this.ModelRow_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.ModelRow_textBox.Name = "ModelRow_textBox";
            this.ModelRow_textBox.Size = new System.Drawing.Size(73, 25);
            this.ModelRow_textBox.TabIndex = 26;
            // 
            // labelModelRow
            // 
            this.labelModelRow.AutoSize = true;
            this.labelModelRow.Location = new System.Drawing.Point(734, 283);
            this.labelModelRow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelModelRow.Name = "labelModelRow";
            this.labelModelRow.Size = new System.Drawing.Size(39, 15);
            this.labelModelRow.TabIndex = 25;
            this.labelModelRow.Text = "Row:";
            // 
            // buttonAcqGrab
            // 
            this.buttonAcqGrab.Location = new System.Drawing.Point(678, 25);
            this.buttonAcqGrab.Name = "buttonAcqGrab";
            this.buttonAcqGrab.Size = new System.Drawing.Size(232, 64);
            this.buttonAcqGrab.TabIndex = 15;
            this.buttonAcqGrab.Text = "开始采集图像";
            this.buttonAcqGrab.UseVisualStyleBackColor = true;
            // 
            // buttonStopAcqGrab
            // 
            this.buttonStopAcqGrab.Location = new System.Drawing.Point(678, 110);
            this.buttonStopAcqGrab.Name = "buttonStopAcqGrab";
            this.buttonStopAcqGrab.Size = new System.Drawing.Size(232, 64);
            this.buttonStopAcqGrab.TabIndex = 16;
            this.buttonStopAcqGrab.Text = "停止采集图像";
            this.buttonStopAcqGrab.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(656, 390);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "输出日志：";
            // 
            // textBoxResultLog
            // 
            this.textBoxResultLog.Location = new System.Drawing.Point(659, 409);
            this.textBoxResultLog.Multiline = true;
            this.textBoxResultLog.Name = "textBoxResultLog";
            this.textBoxResultLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxResultLog.Size = new System.Drawing.Size(251, 151);
            this.textBoxResultLog.TabIndex = 18;
            // 
            // buttonAdapt
            // 
            this.buttonAdapt.Location = new System.Drawing.Point(4, 508);
            this.buttonAdapt.Name = "buttonAdapt";
            this.buttonAdapt.Size = new System.Drawing.Size(94, 26);
            this.buttonAdapt.TabIndex = 14;
            this.buttonAdapt.Text = "适应窗口";
            this.buttonAdapt.UseVisualStyleBackColor = true;
            this.buttonAdapt.Click += new System.EventHandler(this.buttonAdapt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 579);
            this.Controls.Add(this.buttonAdapt);
            this.Controls.Add(this.textBoxResultLog);
            this.Controls.Add(this.ModelAngle_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelModelAngle);
            this.Controls.Add(this.buttonStopAcqGrab);
            this.Controls.Add(this.ModelColumn_textBox);
            this.Controls.Add(this.buttonAcqGrab);
            this.Controls.Add(this.labelModelColumn);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ModelRow_textBox);
            this.Controls.Add(this.button_Input_Set);
            this.Controls.Add(this.labelModelRow);
            this.Controls.Add(this.button_Open_Picture);
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
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
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
        private System.Windows.Forms.Button button_Open_Picture;
        private System.Windows.Forms.Button button_Input_Set;
        private HalconDotNet.HWindowControl hWindowControl1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox ModelMatch_checkBox;
        private System.Windows.Forms.TextBox ModelAngle_textBox;
        private System.Windows.Forms.Label labelModelAngle;
        private System.Windows.Forms.TextBox ModelColumn_textBox;
        private System.Windows.Forms.Label labelModelColumn;
        private System.Windows.Forms.TextBox ModelRow_textBox;
        private System.Windows.Forms.Label labelModelRow;
        private System.Windows.Forms.Button buttonTestModel;
        private System.Windows.Forms.Button buttonSaveModel;
        private System.Windows.Forms.Button buttonCreateModel;
        private System.Windows.Forms.Button buttonSetModel;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox Metrology_checkBox;
        private System.Windows.Forms.Button buttonTestMetrology;
        private System.Windows.Forms.Button buttonSaveMetrology;
        private System.Windows.Forms.Button buttonCreateMetrology;
        private System.Windows.Forms.Button buttonDrawLine1;
        private System.Windows.Forms.Button buttonAcqGrab;
        private System.Windows.Forms.Button buttonStopAcqGrab;
        private System.Windows.Forms.Button buttonDrawCircle1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonDrawCircle2;
        private System.Windows.Forms.Button buttonDrawLine2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxResultLog;
        private System.Windows.Forms.Button buttonClearMetrology;
        private System.Windows.Forms.Button buttonAdapt;
    }
}

