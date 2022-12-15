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
        private LedSettings _ledSettings;
        private readonly NotifyIcon _numNotifyIcon;
        private readonly NotifyIcon _capsNotifyIcon;
        private readonly NotifyIcon _scrollNotifyIcon;
        ContextMenu _contextMenu;

        private Icon _numIconOn;
        private Icon _numIconOff;
        private Icon _capsIconOn;
        private Icon _capsIconOff;
        private Icon _scrollIconOn;
        private Icon _scrollIconOff;

        public TrayManager (LedSettings settinhgs, ContextMenu contextMenu)
        {
            _ledSettings = settinhgs;
            _contextMenu = contextMenu;

            _numNotifyIcon = new NotifyIcon();
            _numNotifyIcon.ContextMenu = _contextMenu;
            _capsNotifyIcon = new NotifyIcon();
            _capsNotifyIcon.ContextMenu = _contextMenu;
            _scrollNotifyIcon = new NotifyIcon();
            _scrollNotifyIcon.ContextMenu = _contextMenu;

            ApplySettings();
            
        }

        private void ApplySettings()
        {
            DisposeIcons();

            _numIconOn = CreateTextIcon("1", _ledSettings.TrayOnColor, _ledSettings.TrayOnBackColor, _ledSettings.TrayOnBorder, 1);
            _numIconOff = CreateTextIcon("1", _ledSettings.TrayOffColor, _ledSettings.TrayOffBackColor, _ledSettings.TrayOffBorder, 1);
            _capsIconOn = CreateTextIcon("A", _ledSettings.TrayOnColor, _ledSettings.TrayOnBackColor, _ledSettings.TrayOnBorder);
            _capsIconOff = CreateTextIcon("a", _ledSettings.TrayOffColor, _ledSettings.TrayOffBackColor, _ledSettings.TrayOffBorder, 1);
            _scrollIconOn = CreateTextIcon("ᛨ", _ledSettings.TrayOnColor, _ledSettings.TrayOnBackColor, _ledSettings.TrayOnBorder, 1);
            _scrollIconOff = CreateTextIcon("ᛨ", _ledSettings.TrayOffColor, _ledSettings.TrayOffBackColor, _ledSettings.TrayOffBorder, 1);                     

            UpdateIndicators();
            if (_ledSettings.EnableKeyLockLEDs)
            {
                _numNotifyIcon.Visible = _ledSettings.TrayShowNum;
                _capsNotifyIcon.Visible = _ledSettings.TrayShowCaps;
                _scrollNotifyIcon.Visible = _ledSettings.TrayShowScroll;
            }
            else
            {
                HideAll();
            }
        }

        private void DisposeIcons()
        {
            _numIconOn?.Dispose();
            _numIconOff?.Dispose();
            _capsIconOn?.Dispose();
            _capsIconOff?.Dispose();
            _scrollIconOn?.Dispose();
            _scrollIconOff?.Dispose();
        }

        public void UpdateSettings(LedSettings settings)
        {
            _ledSettings = settings;            
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

            _numNotifyIcon.Icon = numLock ? _numIconOn : _numIconOff;
            _capsNotifyIcon.Icon = capsLock ? _capsIconOn : _capsIconOff;
            _scrollNotifyIcon.Icon = scrollLock ? _scrollIconOn : _scrollIconOff;
        }

        ~TrayManager()
        {
            HideAll();
            DisposeIcons();
        }

        public void HideAll()
        {
            _numNotifyIcon.Visible = false;
            _capsNotifyIcon.Visible = false;
            _scrollNotifyIcon.Visible = false;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);


    }
}
