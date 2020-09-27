using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogiLockLED
{
    public class TrayManager
    {
        private LedSettings ledSettings;
        private readonly NotifyIcon numNotifyIcon;
        private readonly NotifyIcon capsNotifyIcon;
        private readonly NotifyIcon scrollNotifyIcon;

        private Icon numIconOn;
        private Icon numIconOff;
        private Icon capsIconOn;
        private Icon capsIconOff;
        private Icon scrollIconOn;
        private Icon scrollIconOff;

        public TrayManager (LedSettings settinhgs)
        {
            ledSettings = settinhgs;

            numNotifyIcon = new NotifyIcon();
            capsNotifyIcon = new NotifyIcon();
            scrollNotifyIcon = new NotifyIcon();

            ApplySettings();
            
        }

        private void ApplySettings()
        {
            DisposeIcons();

            numIconOn = CreateTextIcon("1", ledSettings.TrayOnColor, ledSettings.TrayOnBackColor, ledSettings.TrayOnBorder, 1);
            numIconOff = CreateTextIcon("1", ledSettings.TrayOffColor, ledSettings.TrayOffBackColor, ledSettings.TrayOffBorder, 1);
            capsIconOn = CreateTextIcon("A", ledSettings.TrayOnColor, ledSettings.TrayOnBackColor, ledSettings.TrayOnBorder);
            capsIconOff = CreateTextIcon("a", ledSettings.TrayOffColor, ledSettings.TrayOffBackColor, ledSettings.TrayOffBorder, 1);
            scrollIconOn = CreateTextIcon("ᛨ", ledSettings.TrayOnColor, ledSettings.TrayOnBackColor, ledSettings.TrayOnBorder, 1);
            scrollIconOff = CreateTextIcon("ᛨ", ledSettings.TrayOffColor, ledSettings.TrayOffBackColor, ledSettings.TrayOffBorder, 1);                     

            UpdateIndicators();
            if (ledSettings.EnableKeyLockLEDs)
            {
                numNotifyIcon.Visible = ledSettings.TrayShowNum;
                capsNotifyIcon.Visible = ledSettings.TrayShowCaps;
                scrollNotifyIcon.Visible = ledSettings.TrayShowScroll;
            }
            else
            {
                HideAll();
            }
        }

        private void DisposeIcons()
        {
            numIconOn?.Dispose();
            numIconOff?.Dispose();
            capsIconOn?.Dispose();
            capsIconOff?.Dispose();
            scrollIconOn?.Dispose();
            scrollIconOff?.Dispose();
        }

        public void UpdateSettings(LedSettings settings)
        {
            ledSettings = settings;            
            ApplySettings();
        }

        protected Icon CreateTextIcon(string str, Color fgColor, Color bgColor, bool drawBorder, int xAdj = 0, int yAdj = 0)
        {
            Font font = new Font(new Font("Arial", 14, FontStyle.Regular, GraphicsUnit.Pixel), FontStyle.Bold );

            Brush fgBrush = new SolidBrush(fgColor);
            Bitmap bitmap = new Bitmap(16, 16);
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            IntPtr hIcon;

            g.Clear(bgColor);
            //g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            g.DrawString(str, font, fgBrush, 1 + xAdj, 0 + yAdj);
            if (drawBorder)
            {
                if(bgColor == Color.Transparent)
                    g.DrawRectangle(new Pen(fgBrush) { Width = 1 }, new Rectangle(0, 0, 15, 15));
                else
                    g.DrawRectangle(new Pen(fgBrush) { Width = 1 }, new Rectangle(1, 1, 13, 13));
            }
            hIcon = (bitmap.GetHicon());
            var icon = System.Drawing.Icon.FromHandle(hIcon);

            return icon;
        }

        public void UpdateIndicators()
        {
            bool numLock = (((ushort)GetKeyState(0x90)) & 0xffff) != 0;
            bool capsLock = (((ushort)GetKeyState(0x14)) & 0xffff) != 0;            
            bool scrollLock = (((ushort)GetKeyState(0x91)) & 0xffff) != 0;

            numNotifyIcon.Icon = numLock ? numIconOn : numIconOff;
            capsNotifyIcon.Icon = capsLock ? capsIconOn : capsIconOff;
            scrollNotifyIcon.Icon = scrollLock ? scrollIconOn : scrollIconOff;
        }

        ~TrayManager()
        {
            HideAll();
            DisposeIcons();
        }

        public void HideAll()
        {
            numNotifyIcon.Visible = false;
            capsNotifyIcon.Visible = false;
            scrollNotifyIcon.Visible = false;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);


    }
}
