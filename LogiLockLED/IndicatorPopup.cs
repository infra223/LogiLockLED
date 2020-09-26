using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogiLockLED
{
    public partial class IndicatorPopup : Form
    {
        public OSDPosition Position { get; private set; }
        public int OuterMargin { get; private set; }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }


        public IndicatorPopup()
        {
            InitializeComponent();
            IntPtr dummy = this.Handle; //Force form to load without showing
        }    
        
        private void hideTimer_Tick(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                lblLockText.Text = "           ";
                this.Hide();
                hideTimer.Stop();                
            }
        }

        public void ShowLockState(LockKey lockKey, bool state)
        {
            //cornerTR.Location = new Point(0, 0);
            //cornerBR.Location = new Point(0, 0);

            lblLockText.Text = lockKey.ToString() + ": " + (state ? "On" : "Off");
            //lblLockText.AutoSize = false;
            //lblLockText.Width = 50;
            //this.Width = 50;
            //lblLockText.AutoSize = true;
            

            cornerTL.Location = new Point(0, 0);
            cornerBL.Location = new Point(0,  this.Height-cornerBL.Height);
            cornerTR.Location = new Point(this.Width - cornerTR.Width, 0);
            cornerBR.Location = new Point(this.Width - cornerBR.Width, this.Height - cornerBR.Height);


            MoveIntoPosition();
            
            ShowInactiveTopmost(this);            
            hideTimer.Stop();
            hideTimer.Start();
        }

        private void MoveIntoPosition()
        {
            var area = Screen.PrimaryScreen.WorkingArea;

            if (Position == OSDPosition.Centre)
            {
                this.Left = (area.X + area.Width - this.Width) / 2;
                this.Top = (area.Y + area.Height - this.Height) / 2;
            }
            else
            {
                if (Position == OSDPosition.Bottom_Right || Position == OSDPosition.Bottom_Left)                
                    this.Top = area.Y + area.Height - this.Height - OuterMargin;
                else
                    this.Top = OuterMargin;

                if(Position == OSDPosition.Bottom_Right || Position == OSDPosition.Top_Right)
                    this.Left = area.X + area.Width - this.Width - OuterMargin;
                else
                    this.Left = OuterMargin;

            }
        }

        public void Configure(LedSettings settings)
        {
            lblLockText.Font = settings.OsdFont;

            cornerTL.Visible = settings.OsdRoundedCorners;
            cornerTR.Visible = settings.OsdRoundedCorners;
            cornerBL.Visible = settings.OsdRoundedCorners;
            cornerBR.Visible = settings.OsdRoundedCorners;

            Position = settings.OsdPosition;
            this.Padding = new Padding(settings.OsdPadding, settings.OsdPadding, settings.OsdPadding, (int)(settings.OsdPadding)+4);
            this.OuterMargin = settings.OsdMargin;

            lblLockText.ForeColor = settings.OsdTextColour;
            this.BackColor = settings.OsdBackColour;
            this.Opacity = settings.OsdOpacity / 100d;
            hideTimer.Interval = settings.OsdDuration;
        }

        /// <summary>
        /// Hide Show method. Consumer should use ShowLockState.
        /// </summary>
        new protected void Show()
        {
            base.Show();
        }

        #region DLLImports        
        private const int SW_SHOWNOACTIVATE = 4;
        private const int HWND_TOPMOST = -1;
        private const uint SWP_NOACTIVATE = 0x0010;

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern bool SetWindowPos(
             int hWnd,             // Window handle
             int hWndInsertAfter,  // Placement-order handle
             int X,                // Horizontal position
             int Y,                // Vertical position
             int cx,               // Width
             int cy,               // Height
             uint uFlags);         // Window positioning flags

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        static void ShowInactiveTopmost(Form frm)
        {
            ShowWindow(frm.Handle, SW_SHOWNOACTIVATE);
            SetWindowPos(frm.Handle.ToInt32(), HWND_TOPMOST,
            frm.Left, frm.Top, frm.Width, frm.Height,
            SWP_NOACTIVATE);
        }
        #endregion
    }
}
