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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.groupBox1.Size = new System.Drawing.Size(290, 81);
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
            this.btnClose.Location = new System.Drawing.Point(201, 385);
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
            this.groupBox2.Size = new System.Drawing.Size(290, 81);
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
            this.groupBox3.Size = new System.Drawing.Size(290, 79);
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
            this.groupBox4.Size = new System.Drawing.Size(289, 72);
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
            this.btnApply.Location = new System.Drawing.Point(102, 385);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(93, 23);
            this.btnApply.TabIndex = 9;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 414);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
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
    }
}

