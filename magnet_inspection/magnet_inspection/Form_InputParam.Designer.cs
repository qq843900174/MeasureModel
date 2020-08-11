namespace magnet_inspection
{
    partial class Form_InputParam
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Thresmin = new System.Windows.Forms.TextBox();
            this.textBox_Thresmax = new System.Windows.Forms.TextBox();
            this.textBox_TopPt = new System.Windows.Forms.TextBox();
            this.textBox_LeftPt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_RightPt = new System.Windows.Forms.TextBox();
            this.textBox_BottomPt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_MaterialH = new System.Windows.Forms.TextBox();
            this.textBox_MaterialW = new System.Windows.Forms.TextBox();
            this.button_Confirm = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_Cancel);
            this.groupBox1.Controls.Add(this.button_Confirm);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox_MaterialH);
            this.groupBox1.Controls.Add(this.textBox_MaterialW);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox_RightPt);
            this.groupBox1.Controls.Add(this.textBox_BottomPt);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_LeftPt);
            this.groupBox1.Controls.Add(this.textBox_TopPt);
            this.groupBox1.Controls.Add(this.textBox_Thresmax);
            this.groupBox1.Controls.Add(this.textBox_Thresmin);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 351);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输入参数：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "阈值上限：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "阈值下限：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "ROI左上角坐标:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "ROI右下角坐标:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "物料宽和高:";
            // 
            // textBox_Thresmin
            // 
            this.textBox_Thresmin.Location = new System.Drawing.Point(106, 48);
            this.textBox_Thresmin.Name = "textBox_Thresmin";
            this.textBox_Thresmin.Size = new System.Drawing.Size(39, 25);
            this.textBox_Thresmin.TabIndex = 5;
            // 
            // textBox_Thresmax
            // 
            this.textBox_Thresmax.Location = new System.Drawing.Point(261, 48);
            this.textBox_Thresmax.Name = "textBox_Thresmax";
            this.textBox_Thresmax.Size = new System.Drawing.Size(39, 25);
            this.textBox_Thresmax.TabIndex = 6;
            // 
            // textBox_TopPt
            // 
            this.textBox_TopPt.Location = new System.Drawing.Point(138, 98);
            this.textBox_TopPt.Name = "textBox_TopPt";
            this.textBox_TopPt.Size = new System.Drawing.Size(69, 25);
            this.textBox_TopPt.TabIndex = 7;
            // 
            // textBox_LeftPt
            // 
            this.textBox_LeftPt.Location = new System.Drawing.Point(243, 98);
            this.textBox_LeftPt.Name = "textBox_LeftPt";
            this.textBox_LeftPt.Size = new System.Drawing.Size(69, 25);
            this.textBox_LeftPt.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(215, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "，";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(215, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "，";
            // 
            // textBox_RightPt
            // 
            this.textBox_RightPt.Location = new System.Drawing.Point(243, 141);
            this.textBox_RightPt.Name = "textBox_RightPt";
            this.textBox_RightPt.Size = new System.Drawing.Size(69, 25);
            this.textBox_RightPt.TabIndex = 11;
            // 
            // textBox_BottomPt
            // 
            this.textBox_BottomPt.Location = new System.Drawing.Point(138, 141);
            this.textBox_BottomPt.Name = "textBox_BottomPt";
            this.textBox_BottomPt.Size = new System.Drawing.Size(69, 25);
            this.textBox_BottomPt.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(201, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "，";
            // 
            // textBox_MaterialH
            // 
            this.textBox_MaterialH.Location = new System.Drawing.Point(229, 210);
            this.textBox_MaterialH.Name = "textBox_MaterialH";
            this.textBox_MaterialH.Size = new System.Drawing.Size(69, 25);
            this.textBox_MaterialH.TabIndex = 14;
            // 
            // textBox_MaterialW
            // 
            this.textBox_MaterialW.Location = new System.Drawing.Point(124, 210);
            this.textBox_MaterialW.Name = "textBox_MaterialW";
            this.textBox_MaterialW.Size = new System.Drawing.Size(69, 25);
            this.textBox_MaterialW.TabIndex = 13;
            // 
            // button_Confirm
            // 
            this.button_Confirm.Location = new System.Drawing.Point(57, 280);
            this.button_Confirm.Name = "button_Confirm";
            this.button_Confirm.Size = new System.Drawing.Size(75, 47);
            this.button_Confirm.TabIndex = 16;
            this.button_Confirm.Text = "确认";
            this.button_Confirm.UseVisualStyleBackColor = true;
            this.button_Confirm.Click += new System.EventHandler(this.button_Confirm_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(225, 280);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 47);
            this.button_Cancel.TabIndex = 17;
            this.button_Cancel.Text = "取消";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // Form_InputParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 375);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_InputParam";
            this.Text = "输入设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_MaterialH;
        private System.Windows.Forms.TextBox textBox_MaterialW;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_RightPt;
        private System.Windows.Forms.TextBox textBox_BottomPt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_LeftPt;
        private System.Windows.Forms.TextBox textBox_TopPt;
        private System.Windows.Forms.TextBox textBox_Thresmax;
        private System.Windows.Forms.TextBox textBox_Thresmin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Confirm;
    }
}