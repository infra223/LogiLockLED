using System.Windows.Forms;
using System.Drawing;
using Microsoft.Win32;
using System;

namespace LogiLockLED
{
    public class LedSettings
    {
        public bool AutoStartApp { get; set; }        
        public bool EnableKeyLockLEDs { get; set; }
        public bool EnableCaps { get; set; }
        public bool EnableNum { get; set; }
        public bool EnableScroll { get; set; }

        public Color CapsOnColor { get; set; }
        public Color CapsOffColor { get; set; }
        public Color NumOnColor { get; set; }
        public Color NumOffColor { get; set; }
        public Color ScrollOnColor { get; set; }
        public Color ScrollOffColor { get; set; }

        public bool OsdEnabled { get; set; }
        public Font OsdFont { get; set; }
        public OSDPosition OsdPosition  { get; set; }
        public int OsdPadding { get; set; }
        public int OsdMargin { get; set; }
        public bool OsdRoundedCorners { get; set; }
        public Color OsdTextColor { get; set; }
        public Color OsdBackColor { get; set; }
        public int OsdOpacity { get; set; }
        public int OsdDuration { get; set; }
        public bool OsdShowNum { get; set; }
        public bool OsdShowCaps { get; set; }
        public bool OsdShowScroll { get; set; }


        public bool TrayShowCaps { get; set; }
        public bool TrayShowNum { get; set; }
        public bool TrayShowScroll { get; set; }
        public Color TrayOnColor { get; set; }
        public Color TrayOnBackColor { get; set; }
        public bool TrayOnBorder { get; set; }
        public Color TrayOffColor { get; set; }
        public Color TrayOffBackColor { get; set; }
        public bool TrayOffBorder { get; set; }

        public string LedController { get; set; }

        private const string appRegKeyName = "LogiLockLED";

        public void LoadSettings()
        {
            
            EnableKeyLockLEDs = Properties.Settings.Default.EnableKeyLockLEDs;
            EnableCaps = Properties.Settings.Default.EnableCaps;
            EnableNum =Properties.Settings.Default.EnableNum;
            EnableScroll = Properties.Settings.Default.EnableScroll;

            CapsOnColor = Properties.Settings.Default.CapsOnColour;
            CapsOffColor = Properties.Settings.Default.CapsOffColour;
            NumOnColor = Properties.Settings.Default.NumOnColour;
            NumOffColor = Properties.Settings.Default.NumOffColour;
            ScrollOnColor = Properties.Settings.Default.ScrollOnColour;
            ScrollOffColor = Properties.Settings.Default.ScrollOffColour;

            AutoStartApp = GetAutoStartSetting();
            OsdEnabled = Properties.Settings.Default.OsdEnabled;
            OsdFont = Properties.Settings.Default.OsdFont;
            OSDPosition tmpOsdPosition;
            if (Enum.TryParse(Properties.Settings.Default.OsdPosition, out tmpOsdPosition))
                OsdPosition = tmpOsdPosition;
            OsdPadding = Properties.Settings.Default.OsdPadding;
            OsdMargin = Properties.Settings.Default.OsdMargin;
            OsdRoundedCorners = Properties.Settings.Default.OsdRoundedCorners;
            OsdTextColor = Properties.Settings.Default.OsdTextColour;
            OsdBackColor = Properties.Settings.Default.OsdBackColour;
            OsdOpacity = Properties.Settings.Default.OsdOpacity;
            OsdDuration = Properties.Settings.Default.OsdDuration;
            OsdShowNum = Properties.Settings.Default.OsdShowNum;
            OsdShowCaps = Properties.Settings.Default.OsdShowCaps;
            OsdShowScroll = Properties.Settings.Default.OsdShowScroll;

            TrayShowCaps = Properties.Settings.Default.TrayShowCaps;
            TrayShowNum = Properties.Settings.Default.TrayShowNum;
            TrayShowScroll = Properties.Settings.Default.TrayShowScroll;
            TrayOnColor = Properties.Settings.Default.TrayOnColor;
            TrayOnBackColor = Properties.Settings.Default.TrayOnBackColor;
            TrayOnBorder = Properties.Settings.Default.TrayOnBorder;
            TrayOffColor = Properties.Settings.Default.TrayOffColor;
            TrayOffBackColor = Properties.Settings.Default.TrayOffBackColor;
            TrayOffBorder = Properties.Settings.Default.TrayOffBorder;
            LedController = Properties.Settings.Default.LedController;

    }

        public void SaveSettings()
        {
            Properties.Settings.Default.EnableKeyLockLEDs = EnableKeyLockLEDs;
            Properties.Settings.Default.EnableCaps = EnableCaps;
            Properties.Settings.Default.EnableNum = EnableNum;
            Properties.Settings.Default.EnableScroll = EnableScroll;

            Properties.Settings.Default.CapsOnColour = CapsOnColor;
            Properties.Settings.Default.CapsOffColour = CapsOffColor;
            Properties.Settings.Default.NumOnColour = NumOnColor; 
            Properties.Settings.Default.NumOffColour = NumOffColor;
            Properties.Settings.Default.ScrollOnColour = ScrollOnColor;
            Properties.Settings.Default.ScrollOffColour = ScrollOffColor;

            Properties.Settings.Default.OsdEnabled = OsdEnabled;
            Properties.Settings.Default.OsdFont = OsdFont;
            Properties.Settings.Default.OsdPosition = OsdPosition.ToString();
            Properties.Settings.Default.OsdPadding = OsdPadding;
            Properties.Settings.Default.OsdMargin = OsdMargin;
            Properties.Settings.Default.OsdRoundedCorners = OsdRoundedCorners;
            Properties.Settings.Default.OsdTextColour = OsdTextColor;
            Properties.Settings.Default.OsdBackColour = OsdBackColor;
            Properties.Settings.Default.OsdOpacity = OsdOpacity;
            Properties.Settings.Default.OsdDuration = OsdDuration;
            Properties.Settings.Default.OsdShowNum = OsdShowNum;
            Properties.Settings.Default.OsdShowCaps  = OsdShowCaps;
            Properties.Settings.Default.OsdShowScroll = OsdShowScroll;

            Properties.Settings.Default.TrayShowCaps = TrayShowCaps;
            Properties.Settings.Default.TrayShowNum = TrayShowNum;
            Properties.Settings.Default.TrayShowScroll = TrayShowScroll;
            Properties.Settings.Default.TrayOnColor = TrayOnColor;
            Properties.Settings.Default.TrayOnBackColor = TrayOnBackColor;
            Properties.Settings.Default.TrayOnBorder = TrayOnBorder;
            Properties.Settings.Default.TrayOffColor = TrayOffColor;
            Properties.Settings.Default.TrayOffBackColor = TrayOffBackColor;
            Properties.Settings.Default.TrayOffBorder = TrayOffBorder;
            Properties.Settings.Default.LedController = LedController;

            Properties.Settings.Default.Save();

            SaveAutoStartSetting();

        }

        private void SaveAutoStartSetting()
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (AutoStartApp)
            {
                reg.SetValue(appRegKeyName, Application.ExecutablePath);
            }
            else
            {
                reg.DeleteValue(appRegKeyName, false);
            }
        }

        private bool GetAutoStartSetting()
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            return reg.GetValue(appRegKeyName, null) != null;
        }
    }
}
