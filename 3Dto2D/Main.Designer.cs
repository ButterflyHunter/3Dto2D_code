namespace _3Dto2D
{
    partial class Main
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
            this.label3 = new System.Windows.Forms.Label();
            this.nud_rotz = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nud_roty = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_rotx = new System.Windows.Forms.NumericUpDown();
            this.Btn_Import = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Btn_ExportLib = new System.Windows.Forms.Button();
            this.nud_y = new System.Windows.Forms.NumericUpDown();
            this.nud_x = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DXpanel = new System.Windows.Forms.Panel();
            this.nud_frame = new System.Windows.Forms.NumericUpDown();
            this.textBox_OffSetX = new System.Windows.Forms.TextBox();
            this.textBox_OffSetY = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.btn_Colour = new System.Windows.Forms.Button();
            this.btn_SaveRef = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.Btn_ImportLib = new System.Windows.Forms.Button();
            this.Lbl_RefName = new System.Windows.Forms.Label();
            this.Lbl_MeshName = new System.Windows.Forms.Label();
            this.checkBox_ShowHands = new System.Windows.Forms.CheckBox();
            this.Btn_OpenHandRef = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.text_test_framemax = new System.Windows.Forms.TextBox();
            this.text_test_framemin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox_BlankHands = new System.Windows.Forms.CheckBox();
            this.Lbl_HandRefName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_rotz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_roty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_rotx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_x)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_frame)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "rotz";
            // 
            // nud_rotz
            // 
            this.nud_rotz.DecimalPlaces = 2;
            this.nud_rotz.Location = new System.Drawing.Point(6, 71);
            this.nud_rotz.Maximum = new decimal(new int[] {
            361,
            0,
            0,
            0});
            this.nud_rotz.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nud_rotz.Name = "nud_rotz";
            this.nud_rotz.Size = new System.Drawing.Size(120, 20);
            this.nud_rotz.TabIndex = 5;
            this.nud_rotz.ValueChanged += new System.EventHandler(this.nud_rotz_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "roty";
            // 
            // nud_roty
            // 
            this.nud_roty.DecimalPlaces = 2;
            this.nud_roty.Location = new System.Drawing.Point(6, 45);
            this.nud_roty.Maximum = new decimal(new int[] {
            361,
            0,
            0,
            0});
            this.nud_roty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nud_roty.Name = "nud_roty";
            this.nud_roty.Size = new System.Drawing.Size(120, 20);
            this.nud_roty.TabIndex = 3;
            this.nud_roty.ValueChanged += new System.EventHandler(this.nud_roty_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "rotx";
            // 
            // nud_rotx
            // 
            this.nud_rotx.DecimalPlaces = 2;
            this.nud_rotx.Location = new System.Drawing.Point(6, 19);
            this.nud_rotx.Maximum = new decimal(new int[] {
            361,
            0,
            0,
            0});
            this.nud_rotx.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nud_rotx.Name = "nud_rotx";
            this.nud_rotx.Size = new System.Drawing.Size(120, 20);
            this.nud_rotx.TabIndex = 1;
            this.nud_rotx.ValueChanged += new System.EventHandler(this.nud_rotx_ValueChanged);
            // 
            // Btn_Import
            // 
            this.Btn_Import.Location = new System.Drawing.Point(12, 41);
            this.Btn_Import.Name = "Btn_Import";
            this.Btn_Import.Size = new System.Drawing.Size(94, 23);
            this.Btn_Import.TabIndex = 0;
            this.Btn_Import.Text = "3D Mesh";
            this.Btn_Import.UseVisualStyleBackColor = true;
            this.Btn_Import.Click += new System.EventHandler(this.Btn_Import_Click);
            // 
            // Btn_ExportLib
            // 
            this.Btn_ExportLib.Location = new System.Drawing.Point(12, 347);
            this.Btn_ExportLib.Name = "Btn_ExportLib";
            this.Btn_ExportLib.Size = new System.Drawing.Size(75, 23);
            this.Btn_ExportLib.TabIndex = 9;
            this.Btn_ExportLib.Text = "Create Lib";
            this.Btn_ExportLib.UseVisualStyleBackColor = true;
            this.Btn_ExportLib.Click += new System.EventHandler(this.Btn_ExportLib_Click);
            // 
            // nud_y
            // 
            this.nud_y.DecimalPlaces = 1;
            this.nud_y.Location = new System.Drawing.Point(6, 45);
            this.nud_y.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_y.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nud_y.Name = "nud_y";
            this.nud_y.Size = new System.Drawing.Size(120, 20);
            this.nud_y.TabIndex = 11;
            this.nud_y.ValueChanged += new System.EventHandler(this.nud_y_ValueChanged);
            // 
            // nud_x
            // 
            this.nud_x.DecimalPlaces = 1;
            this.nud_x.Location = new System.Drawing.Point(6, 19);
            this.nud_x.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_x.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nud_x.Name = "nud_x";
            this.nud_x.Size = new System.Drawing.Size(120, 20);
            this.nud_x.TabIndex = 10;
            this.nud_x.ValueChanged += new System.EventHandler(this.nud_x_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(133, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(133, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "x";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nud_x);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.nud_y);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(12, 179);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 77);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Move";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nud_rotx);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.nud_roty);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.nud_rotz);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(164, 100);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rotation";
            // 
            // DXpanel
            // 
            this.DXpanel.BackColor = System.Drawing.Color.Black;
            this.DXpanel.Location = new System.Drawing.Point(236, 36);
            this.DXpanel.Name = "DXpanel";
            this.DXpanel.Size = new System.Drawing.Size(250, 250);
            this.DXpanel.TabIndex = 17;
            // 
            // nud_frame
            // 
            this.nud_frame.Location = new System.Drawing.Point(366, 295);
            this.nud_frame.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nud_frame.Name = "nud_frame";
            this.nud_frame.Size = new System.Drawing.Size(120, 20);
            this.nud_frame.TabIndex = 18;
            this.nud_frame.ValueChanged += new System.EventHandler(this.nud_frame_ValueChanged);
            // 
            // textBox_OffSetX
            // 
            this.textBox_OffSetX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_OffSetX.Location = new System.Drawing.Point(384, 321);
            this.textBox_OffSetX.Name = "textBox_OffSetX";
            this.textBox_OffSetX.ReadOnly = true;
            this.textBox_OffSetX.Size = new System.Drawing.Size(40, 20);
            this.textBox_OffSetX.TabIndex = 19;
            // 
            // textBox_OffSetY
            // 
            this.textBox_OffSetY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_OffSetY.Location = new System.Drawing.Point(446, 321);
            this.textBox_OffSetY.Name = "textBox_OffSetY";
            this.textBox_OffSetY.ReadOnly = true;
            this.textBox_OffSetY.Size = new System.Drawing.Size(40, 20);
            this.textBox_OffSetY.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(368, 325);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "X";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(430, 325);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Y";
            // 
            // btn_Colour
            // 
            this.btn_Colour.Location = new System.Drawing.Point(411, 7);
            this.btn_Colour.Name = "btn_Colour";
            this.btn_Colour.Size = new System.Drawing.Size(64, 23);
            this.btn_Colour.TabIndex = 23;
            this.btn_Colour.Text = "Bk Colour";
            this.btn_Colour.UseVisualStyleBackColor = true;
            this.btn_Colour.Click += new System.EventHandler(this.btn_Colour_Click);
            // 
            // btn_SaveRef
            // 
            this.btn_SaveRef.Location = new System.Drawing.Point(411, 346);
            this.btn_SaveRef.Name = "btn_SaveRef";
            this.btn_SaveRef.Size = new System.Drawing.Size(75, 23);
            this.btn_SaveRef.TabIndex = 24;
            this.btn_SaveRef.Text = "SaveRef";
            this.btn_SaveRef.UseVisualStyleBackColor = true;
            this.btn_SaveRef.Click += new System.EventHandler(this.btn_SaveRef_Click);
            // 
            // Btn_ImportLib
            // 
            this.Btn_ImportLib.Location = new System.Drawing.Point(12, 12);
            this.Btn_ImportLib.Name = "Btn_ImportLib";
            this.Btn_ImportLib.Size = new System.Drawing.Size(94, 23);
            this.Btn_ImportLib.TabIndex = 25;
            this.Btn_ImportLib.Text = "Character Type";
            this.Btn_ImportLib.UseVisualStyleBackColor = true;
            this.Btn_ImportLib.Click += new System.EventHandler(this.Btn_ImportLib_Click);
            // 
            // Lbl_RefName
            // 
            this.Lbl_RefName.AutoSize = true;
            this.Lbl_RefName.Location = new System.Drawing.Point(112, 17);
            this.Lbl_RefName.Name = "Lbl_RefName";
            this.Lbl_RefName.Size = new System.Drawing.Size(99, 13);
            this.Lbl_RefName.TabIndex = 26;
            this.Lbl_RefName.Tag = "";
            this.Lbl_RefName.Text = "No Ref File Loaded";
            // 
            // Lbl_MeshName
            // 
            this.Lbl_MeshName.AutoSize = true;
            this.Lbl_MeshName.Location = new System.Drawing.Point(112, 46);
            this.Lbl_MeshName.Name = "Lbl_MeshName";
            this.Lbl_MeshName.Size = new System.Drawing.Size(108, 13);
            this.Lbl_MeshName.TabIndex = 27;
            this.Lbl_MeshName.Tag = "";
            this.Lbl_MeshName.Text = "No Mesh File Loaded";
            // 
            // checkBox_ShowHands
            // 
            this.checkBox_ShowHands.AutoSize = true;
            this.checkBox_ShowHands.Location = new System.Drawing.Point(12, 325);
            this.checkBox_ShowHands.Name = "checkBox_ShowHands";
            this.checkBox_ShowHands.Size = new System.Drawing.Size(87, 17);
            this.checkBox_ShowHands.TabIndex = 28;
            this.checkBox_ShowHands.Text = "Show Hands";
            this.checkBox_ShowHands.UseVisualStyleBackColor = true;
            this.checkBox_ShowHands.CheckedChanged += new System.EventHandler(this.checkBox_ShowHands_CheckedChanged);
            // 
            // Btn_OpenHandRef
            // 
            this.Btn_OpenHandRef.Location = new System.Drawing.Point(13, 295);
            this.Btn_OpenHandRef.Name = "Btn_OpenHandRef";
            this.Btn_OpenHandRef.Size = new System.Drawing.Size(75, 23);
            this.Btn_OpenHandRef.TabIndex = 29;
            this.Btn_OpenHandRef.Text = "Hand Ref File";
            this.Btn_OpenHandRef.UseVisualStyleBackColor = true;
            this.Btn_OpenHandRef.Click += new System.EventHandler(this.Btn_OpenHandRef_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 377);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(498, 22);
            this.statusStrip1.TabIndex = 30;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // text_test_framemax
            // 
            this.text_test_framemax.Location = new System.Drawing.Point(148, 349);
            this.text_test_framemax.Name = "text_test_framemax";
            this.text_test_framemax.Size = new System.Drawing.Size(33, 20);
            this.text_test_framemax.TabIndex = 32;
            this.text_test_framemax.Text = "0";
            // 
            // text_test_framemin
            // 
            this.text_test_framemin.Location = new System.Drawing.Point(93, 349);
            this.text_test_framemin.Name = "text_test_framemin";
            this.text_test_framemin.Size = new System.Drawing.Size(33, 20);
            this.text_test_framemin.TabIndex = 33;
            this.text_test_framemin.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 352);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "to";
            // 
            // checkBox_BlankHands
            // 
            this.checkBox_BlankHands.AutoSize = true;
            this.checkBox_BlankHands.Location = new System.Drawing.Point(106, 325);
            this.checkBox_BlankHands.Name = "checkBox_BlankHands";
            this.checkBox_BlankHands.Size = new System.Drawing.Size(87, 17);
            this.checkBox_BlankHands.TabIndex = 36;
            this.checkBox_BlankHands.Text = "Blank Hands";
            this.checkBox_BlankHands.UseVisualStyleBackColor = true;
            this.checkBox_BlankHands.CheckedChanged += new System.EventHandler(this.checkBox_BlankHands_CheckedChanged);
            // 
            // Lbl_HandRefName
            // 
            this.Lbl_HandRefName.AutoSize = true;
            this.Lbl_HandRefName.Location = new System.Drawing.Point(95, 301);
            this.Lbl_HandRefName.Name = "Lbl_HandRefName";
            this.Lbl_HandRefName.Size = new System.Drawing.Size(79, 13);
            this.Lbl_HandRefName.TabIndex = 37;
            this.Lbl_HandRefName.Text = "No File Loaded";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 399);
            this.Controls.Add(this.Lbl_HandRefName);
            this.Controls.Add(this.checkBox_BlankHands);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.text_test_framemin);
            this.Controls.Add(this.text_test_framemax);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Btn_OpenHandRef);
            this.Controls.Add(this.checkBox_ShowHands);
            this.Controls.Add(this.Lbl_MeshName);
            this.Controls.Add(this.Lbl_RefName);
            this.Controls.Add(this.btn_Colour);
            this.Controls.Add(this.Btn_ImportLib);
            this.Controls.Add(this.btn_SaveRef);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_OffSetY);
            this.Controls.Add(this.textBox_OffSetX);
            this.Controls.Add(this.nud_frame);
            this.Controls.Add(this.DXpanel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_Import);
            this.Controls.Add(this.Btn_ExportLib);
            this.Name = "Main";
            this.Text = "3D Model to 2D Animation ";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.nud_rotz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_roty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_rotx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_x)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_frame)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Btn_Import;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nud_rotz;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nud_roty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nud_rotx;
        private System.Windows.Forms.Button Btn_ExportLib;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nud_y;
        private System.Windows.Forms.NumericUpDown nud_x;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel DXpanel;
        private System.Windows.Forms.NumericUpDown nud_frame;
        private System.Windows.Forms.TextBox textBox_OffSetX;
        private System.Windows.Forms.TextBox textBox_OffSetY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button btn_Colour;
        private System.Windows.Forms.Button btn_SaveRef;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button Btn_ImportLib;
        private System.Windows.Forms.Label Lbl_RefName;
        private System.Windows.Forms.Label Lbl_MeshName;
        private System.Windows.Forms.CheckBox checkBox_ShowHands;
        private System.Windows.Forms.Button Btn_OpenHandRef;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.TextBox text_test_framemax;
        private System.Windows.Forms.TextBox text_test_framemin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox_BlankHands;
        private System.Windows.Forms.Label Lbl_HandRefName;
    }
}

