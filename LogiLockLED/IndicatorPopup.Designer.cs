namespace LogiLockLED
{
    partial class IndicatorPopup
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndicatorPopup));
            this.lblLockText = new System.Windows.Forms.Label();
            this.hideTimer = new System.Windows.Forms.Timer(this.components);
            this.cornerTL = new System.Windows.Forms.PictureBox();
            this.cornerBR = new System.Windows.Forms.PictureBox();
            this.cornerTR = new System.Windows.Forms.PictureBox();
            this.cornerBL = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cornerTL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cornerBR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cornerTR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cornerBL)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLockText
            // 
            this.lblLockText.AutoSize = true;
            this.lblLockText.BackColor = System.Drawing.Color.Transparent;
            this.lblLockText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLockText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLockText.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLockText.ForeColor = System.Drawing.Color.White;
            this.lblLockText.Location = new System.Drawing.Point(8, 8);
            this.lblLockText.Margin = new System.Windows.Forms.Padding(3);
            this.lblLockText.Name = "lblLockText";
            this.lblLockText.Size = new System.Drawing.Size(289, 72);
            this.lblLockText.TabIndex = 0;
            this.lblLockText.Text = "Num: On";
            this.lblLockText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // hideTimer
            // 
            this.hideTimer.Enabled = true;
            this.hideTimer.Interval = 1000;
            this.hideTimer.Tick += new System.EventHandler(this.hideTimer_Tick);
            // 
            // cornerTL
            // 
            this.cornerTL.BackColor = System.Drawing.Color.Transparent;
            this.cornerTL.Image = ((System.Drawing.Image)(resources.GetObject("cornerTL.Image")));
            this.cornerTL.Location = new System.Drawing.Point(8, 8);
            this.cornerTL.Name = "cornerTL";
            this.cornerTL.Size = new System.Drawing.Size(17, 17);
            this.cornerTL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.cornerTL.TabIndex = 1;
            this.cornerTL.TabStop = false;
            // 
            // cornerBR
            // 
            this.cornerBR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cornerBR.BackColor = System.Drawing.Color.Transparent;
            this.cornerBR.Image = ((System.Drawing.Image)(resources.GetObject("cornerBR.Image")));
            this.cornerBR.Location = new System.Drawing.Point(221, 108);
            this.cornerBR.Name = "cornerBR";
            this.cornerBR.Size = new System.Drawing.Size(17, 17);
            this.cornerBR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.cornerBR.TabIndex = 2;
            this.cornerBR.TabStop = false;
            // 
            // cornerTR
            // 
            this.cornerTR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cornerTR.BackColor = System.Drawing.Color.Transparent;
            this.cornerTR.Image = ((System.Drawing.Image)(resources.GetObject("cornerTR.Image")));
            this.cornerTR.Location = new System.Drawing.Point(221, 8);
            this.cornerTR.Name = "cornerTR";
            this.cornerTR.Size = new System.Drawing.Size(17, 17);
            this.cornerTR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.cornerTR.TabIndex = 3;
            this.cornerTR.TabStop = false;
            // 
            // cornerBL
            // 
            this.cornerBL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cornerBL.BackColor = System.Drawing.Color.Transparent;
            this.cornerBL.Image = ((System.Drawing.Image)(resources.GetObject("cornerBL.Image")));
            this.cornerBL.Location = new System.Drawing.Point(8, 108);
            this.cornerBL.Name = "cornerBL";
            this.cornerBL.Size = new System.Drawing.Size(17, 17);
            this.cornerBL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.cornerBL.TabIndex = 4;
            this.cornerBL.TabStop = false;
            // 
            // IndicatorPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(4)))), ((int)(((byte)(4)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(249, 127);
            this.Controls.Add(this.cornerBL);
            this.Controls.Add(this.cornerTR);
            this.Controls.Add(this.cornerBR);
            this.Controls.Add(this.cornerTL);
            this.Controls.Add(this.lblLockText);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IndicatorPopup";
            this.Opacity = 0.75D;
            this.Padding = new System.Windows.Forms.Padding(8);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IndicatorPopup";
            this.TransparencyKey = System.Drawing.Color.Black;
            ((System.ComponentModel.ISupportInitialize)(this.cornerTL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cornerBR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cornerTR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cornerBL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLockText;
        private System.Windows.Forms.Timer hideTimer;
        private System.Windows.Forms.PictureBox cornerTL;
        private System.Windows.Forms.PictureBox cornerBR;
        private System.Windows.Forms.PictureBox cornerTR;
        private System.Windows.Forms.PictureBox cornerBL;
    }
}