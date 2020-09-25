namespace LogiLockLED
{
    partial class ConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbEnableCaps = new System.Windows.Forms.CheckBox();
            this.btnCapsOffColour = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCapsOnColour = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbEnableNum = new System.Windows.Forms.CheckBox();
            this.btnNumOffColour = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNumOnColour = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbEnableScroll = new System.Windows.Forms.CheckBox();
            this.btnScrollOffColour = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnScrollOnColour = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbEnable = new System.Windows.Forms.CheckBox();
            this.cbAutoStartApp = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbOsdEnabled = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbOSDPosition = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.btnOsdFont = new System.Windows.Forms.Button();
            this.cbOsdPadding = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbOsdMargin = new System.Windows.Forms.NumericUpDown();
            this.cbOsdRoundedCorners = new System.Windows.Forms.CheckBox();
            this.btnOsdTxtColour = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnOsdBkColour = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbOsdOpacity = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbOsdPadding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOsdMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOsdOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbEnableCaps);
            this.groupBox1.Controls.Add(this.btnCapsOffColour);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnCapsOnColour);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 81);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Caps Lock";
            // 
            // cbEnableCaps
            // 
            this.cbEnableCaps.AutoSize = true;
            this.cbEnableCaps.Location = new System.Drawing.Point(9, 20);
            this.cbEnableCaps.Name = "cbEnableCaps";
            this.cbEnableCaps.Size = new System.Drawing.Size(59, 17);
            this.cbEnableCaps.TabIndex = 4;
            this.cbEnableCaps.Text = "Enable";
            this.cbEnableCaps.UseVisualStyleBackColor = true;
            this.cbEnableCaps.CheckedChanged += new System.EventHandler(this.cbEnableCaps_CheckedChanged);
            // 
            // btnCapsOffColour
            // 
            this.btnCapsOffColour.Location = new System.Drawing.Point(197, 43);
            this.btnCapsOffColour.Name = "btnCapsOffColour";
            this.btnCapsOffColour.Size = new System.Drawing.Size(44, 23);
            this.btnCapsOffColour.TabIndex = 3;
            this.btnCapsOffColour.UseVisualStyleBackColor = true;
            this.btnCapsOffColour.Click += new System.EventHandler(this.btnColour_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Off Colour:";
            // 
            // btnCapsOnColour
            // 
            this.btnCapsOnColour.Location = new System.Drawing.Point(69, 43);
            this.btnCapsOnColour.Name = "btnCapsOnColour";
            this.btnCapsOnColour.Size = new System.Drawing.Size(44, 23);
            this.btnCapsOnColour.TabIndex = 1;
            this.btnCapsOnColour.UseVisualStyleBackColor = true;
            this.btnCapsOnColour.Click += new System.EventHandler(this.btnColour_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "On Colour:";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(403, 385);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Save and Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbEnableNum);
            this.groupBox2.Controls.Add(this.btnNumOffColour);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnNumOnColour);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(14, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 81);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Num Lock";
            // 
            // cbEnableNum
            // 
            this.cbEnableNum.AutoSize = true;
            this.cbEnableNum.Location = new System.Drawing.Point(9, 20);
            this.cbEnableNum.Name = "cbEnableNum";
            this.cbEnableNum.Size = new System.Drawing.Size(59, 17);
            this.cbEnableNum.TabIndex = 4;
            this.cbEnableNum.Text = "Enable";
            this.cbEnableNum.UseVisualStyleBackColor = true;
            this.cbEnableNum.CheckedChanged += new System.EventHandler(this.cbEnableNum_CheckedChanged);
            // 
            // btnNumOffColour
            // 
            this.btnNumOffColour.Location = new System.Drawing.Point(197, 43);
            this.btnNumOffColour.Name = "btnNumOffColour";
            this.btnNumOffColour.Size = new System.Drawing.Size(44, 23);
            this.btnNumOffColour.TabIndex = 3;
            this.btnNumOffColour.UseVisualStyleBackColor = true;
            this.btnNumOffColour.Click += new System.EventHandler(this.btnColour_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Off Colour:";
            // 
            // btnNumOnColour
            // 
            this.btnNumOnColour.Location = new System.Drawing.Point(69, 43);
            this.btnNumOnColour.Name = "btnNumOnColour";
            this.btnNumOnColour.Size = new System.Drawing.Size(44, 23);
            this.btnNumOnColour.TabIndex = 1;
            this.btnNumOnColour.UseVisualStyleBackColor = true;
            this.btnNumOnColour.Click += new System.EventHandler(this.btnColour_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "On Colour:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbEnableScroll);
            this.groupBox3.Controls.Add(this.btnScrollOffColour);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnScrollOnColour);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(13, 265);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(272, 79);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Scroll Lock";
            // 
            // cbEnableScroll
            // 
            this.cbEnableScroll.AutoSize = true;
            this.cbEnableScroll.Location = new System.Drawing.Point(9, 20);
            this.cbEnableScroll.Name = "cbEnableScroll";
            this.cbEnableScroll.Size = new System.Drawing.Size(59, 17);
            this.cbEnableScroll.TabIndex = 4;
            this.cbEnableScroll.Text = "Enable";
            this.cbEnableScroll.UseVisualStyleBackColor = true;
            this.cbEnableScroll.CheckedChanged += new System.EventHandler(this.cbEnableScroll_CheckedChanged);
            // 
            // btnScrollOffColour
            // 
            this.btnScrollOffColour.Location = new System.Drawing.Point(197, 43);
            this.btnScrollOffColour.Name = "btnScrollOffColour";
            this.btnScrollOffColour.Size = new System.Drawing.Size(44, 23);
            this.btnScrollOffColour.TabIndex = 3;
            this.btnScrollOffColour.UseVisualStyleBackColor = true;
            this.btnScrollOffColour.Click += new System.EventHandler(this.btnColour_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(134, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Off Colour:";
            // 
            // btnScrollOnColour
            // 
            this.btnScrollOnColour.Location = new System.Drawing.Point(69, 43);
            this.btnScrollOnColour.Name = "btnScrollOnColour";
            this.btnScrollOnColour.Size = new System.Drawing.Size(44, 23);
            this.btnScrollOnColour.TabIndex = 1;
            this.btnScrollOnColour.UseVisualStyleBackColor = true;
            this.btnScrollOnColour.Click += new System.EventHandler(this.btnColour_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "On Colour:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbEnable);
            this.groupBox4.Controls.Add(this.cbAutoStartApp);
            this.groupBox4.Location = new System.Drawing.Point(13, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(272, 72);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "General Settings";
            // 
            // cbEnable
            // 
            this.cbEnable.AutoSize = true;
            this.cbEnable.Location = new System.Drawing.Point(8, 42);
            this.cbEnable.Name = "cbEnable";
            this.cbEnable.Size = new System.Drawing.Size(136, 17);
            this.cbEnable.TabIndex = 1;
            this.cbEnable.Text = "Enable Key Lock LEDs";
            this.cbEnable.UseVisualStyleBackColor = true;
            this.cbEnable.CheckedChanged += new System.EventHandler(this.cbEnable_CheckedChanged);
            // 
            // cbAutoStartApp
            // 
            this.cbAutoStartApp.AutoSize = true;
            this.cbAutoStartApp.Location = new System.Drawing.Point(8, 19);
            this.cbAutoStartApp.Name = "cbAutoStartApp";
            this.cbAutoStartApp.Size = new System.Drawing.Size(128, 17);
            this.cbAutoStartApp.TabIndex = 0;
            this.cbAutoStartApp.Text = "Auto Start Application";
            this.cbAutoStartApp.UseVisualStyleBackColor = true;
            this.cbAutoStartApp.CheckedChanged += new System.EventHandler(this.cbAutoStartApp_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 385);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(304, 385);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(93, 23);
            this.btnApply.TabIndex = 9;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.cbOsdOpacity);
            this.groupBox5.Controls.Add(this.btnOsdBkColour);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.btnOsdTxtColour);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.cbOsdRoundedCorners);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.cbOsdMargin);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.cbOsdPadding);
            this.groupBox5.Controls.Add(this.btnOsdFont);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.cbOSDPosition);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.cbOsdEnabled);
            this.groupBox5.Location = new System.Drawing.Point(301, 13);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 266);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "On-Screen Display";
            // 
            // cbOsdEnabled
            // 
            this.cbOsdEnabled.AutoSize = true;
            this.cbOsdEnabled.Location = new System.Drawing.Point(7, 20);
            this.cbOsdEnabled.Name = "cbOsdEnabled";
            this.cbOsdEnabled.Size = new System.Drawing.Size(85, 17);
            this.cbOsdEnabled.TabIndex = 0;
            this.cbOsdEnabled.Text = "Enable OSD";
            this.cbOsdEnabled.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Position:";
            // 
            // cbOSDPosition
            // 
            this.cbOSDPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOSDPosition.FormattingEnabled = true;
            this.cbOSDPosition.Items.AddRange(new object[] {
            "Center",
            "Top Left",
            "Top Right",
            "Bottom Left",
            "Bottom Right"});
            this.cbOSDPosition.Location = new System.Drawing.Point(60, 40);
            this.cbOSDPosition.Name = "cbOSDPosition";
            this.cbOSDPosition.Size = new System.Drawing.Size(121, 21);
            this.cbOSDPosition.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Font:";
            // 
            // btnOsdFont
            // 
            this.btnOsdFont.Location = new System.Drawing.Point(60, 145);
            this.btnOsdFont.Name = "btnOsdFont";
            this.btnOsdFont.Size = new System.Drawing.Size(121, 23);
            this.btnOsdFont.TabIndex = 4;
            this.btnOsdFont.Text = "Font";
            this.btnOsdFont.UseVisualStyleBackColor = true;
            this.btnOsdFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // cbOsdPadding
            // 
            this.cbOsdPadding.Location = new System.Drawing.Point(60, 67);
            this.cbOsdPadding.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.cbOsdPadding.Minimum = new decimal(new int[] {
            -727379969,
            232,
            0,
            -2147483648});
            this.cbOsdPadding.Name = "cbOsdPadding";
            this.cbOsdPadding.Size = new System.Drawing.Size(120, 20);
            this.cbOsdPadding.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Padding:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Margin:";
            // 
            // cbOsdMargin
            // 
            this.cbOsdMargin.Location = new System.Drawing.Point(60, 93);
            this.cbOsdMargin.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.cbOsdMargin.Minimum = new decimal(new int[] {
            -727379969,
            232,
            0,
            -2147483648});
            this.cbOsdMargin.Name = "cbOsdMargin";
            this.cbOsdMargin.Size = new System.Drawing.Size(120, 20);
            this.cbOsdMargin.TabIndex = 7;
            // 
            // cbOsdRoundedCorners
            // 
            this.cbOsdRoundedCorners.AutoSize = true;
            this.cbOsdRoundedCorners.Location = new System.Drawing.Point(7, 122);
            this.cbOsdRoundedCorners.Name = "cbOsdRoundedCorners";
            this.cbOsdRoundedCorners.Size = new System.Drawing.Size(109, 17);
            this.cbOsdRoundedCorners.TabIndex = 9;
            this.cbOsdRoundedCorners.Text = "Rounded Corners";
            this.cbOsdRoundedCorners.UseVisualStyleBackColor = true;
            // 
            // btnOsdTxtColour
            // 
            this.btnOsdTxtColour.Location = new System.Drawing.Point(96, 174);
            this.btnOsdTxtColour.Name = "btnOsdTxtColour";
            this.btnOsdTxtColour.Size = new System.Drawing.Size(44, 23);
            this.btnOsdTxtColour.TabIndex = 11;
            this.btnOsdTxtColour.UseVisualStyleBackColor = true;
            this.btnOsdTxtColour.Click += new System.EventHandler(this.btnColour_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 179);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Text Colour:";
            // 
            // btnOsdBkColour
            // 
            this.btnOsdBkColour.Location = new System.Drawing.Point(96, 203);
            this.btnOsdBkColour.Name = "btnOsdBkColour";
            this.btnOsdBkColour.Size = new System.Drawing.Size(44, 23);
            this.btnOsdBkColour.TabIndex = 13;
            this.btnOsdBkColour.UseVisualStyleBackColor = true;
            this.btnOsdBkColour.Click += new System.EventHandler(this.btnColour_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 208);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Back Colour:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 234);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Opacity:";
            // 
            // cbOsdOpacity
            // 
            this.cbOsdOpacity.Location = new System.Drawing.Point(61, 232);
            this.cbOsdOpacity.Name = "cbOsdOpacity";
            this.cbOsdOpacity.Size = new System.Drawing.Size(119, 20);
            this.cbOsdOpacity.TabIndex = 14;
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 414);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigurationForm";
            this.Text = "LogiLockLED Configuration";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbOsdPadding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOsdMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOsdOpacity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox cbEnableCaps;
        private System.Windows.Forms.Button btnCapsOffColour;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCapsOnColour;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbEnableNum;
        private System.Windows.Forms.Button btnNumOffColour;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNumOnColour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbEnableScroll;
        private System.Windows.Forms.Button btnScrollOffColour;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnScrollOnColour;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cbAutoStartApp;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbEnable;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbOsdEnabled;
        private System.Windows.Forms.ComboBox cbOSDPosition;
        private System.Windows.Forms.Button btnOsdFont;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.CheckBox cbOsdRoundedCorners;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown cbOsdMargin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown cbOsdPadding;
        private System.Windows.Forms.Button btnOsdBkColour;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnOsdTxtColour;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown cbOsdOpacity;
    }
}

