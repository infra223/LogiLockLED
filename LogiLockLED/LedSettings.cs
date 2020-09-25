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

        public Color CapsOnColour { get; set; }
        public Color CapsOffColour { get; set; }
        public Color NumOnColour { get; set; }
        public Color NumOffColour { get; set; }
        public Color ScrollOnColour { get; set; }
        public Color ScrollOffColour { get; set; }

        public bool OsdEnabled { get; set; }
        public Font OsdFont { get; set; }
        public OSDPosition OsdPosition  { get; set; }
        public int OsdPadding { get; set; }
        public int OsdMargin { get; set; }
        public bool OsdRoundedCorners { get; set; }
        public Color OsdTextColour { get; set; }
        public Color OsdBackColour { get; set; }
        public int OsdOpacity { get; set; }

        private const string appRegKeyName = "LogiLockLED";

        public void LoadSettings()
        {
            
            EnableKeyLockLEDs = Properties.Settings.Default.EnableKeyLockLEDs;
            EnableCaps = Properties.Settings.Default.EnableCaps;
            EnableNum =Properties.Settings.Default.EnableNum;
            EnableScroll = Properties.Settings.Default.EnableScroll;

            CapsOnColour = Properties.Settings.Default.CapsOnColour;
            CapsOffColour = Properties.Settings.Default.CapsOffColour;
            NumOnColour = Properties.Settings.Default.NumOnColour;
            NumOffColour = Properties.Settings.Default.NumOffColour;
            ScrollOnColour = Properties.Settings.Default.ScrollOnColour;
            ScrollOffColour = Properties.Settings.Default.ScrollOffColour;

            AutoStartApp = GetAutoStartSetting();
            OsdEnabled = Properties.Settings.Default.OsdEnabled;
            OsdFont = Properties.Settings.Default.OsdFont;
            OSDPosition tmpOsdPosition;
            if (Enum.TryParse(Properties.Settings.Default.OsdPosition, out tmpOsdPosition))
                OsdPosition = tmpOsdPosition;
            OsdPadding = Properties.Settings.Default.OsdPadding;
            OsdMargin = Properties.Settings.Default.OsdMargin;
            OsdRoundedCorners = Properties.Settings.Default.OsdRoundedCorners;
            OsdTextColour = Properties.Settings.Default.OsdTextColour;
            OsdBackColour = Properties.Settings.Default.OsdBackColour;
            OsdOpacity = Properties.Settings.Default.OsdOpacity;
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.EnableKeyLockLEDs = EnableKeyLockLEDs;
            Properties.Settings.Default.EnableCaps = EnableCaps;
            Properties.Settings.Default.EnableNum = EnableNum;
            Properties.Settings.Default.EnableScroll = EnableScroll;

            Properties.Settings.Default.CapsOnColour = CapsOnColour;
            Properties.Settings.Default.CapsOffColour = CapsOffColour;
            Properties.Settings.Default.NumOnColour = NumOnColour; 
            Properties.Settings.Default.NumOffColour = NumOffColour;
            Properties.Settings.Default.ScrollOnColour = ScrollOnColour;
            Properties.Settings.Default.ScrollOffColour = ScrollOffColour;

            Properties.Settings.Default.OsdEnabled = OsdEnabled;
            Properties.Settings.Default.OsdFont = OsdFont;
            Properties.Settings.Default.OsdPosition = OsdPosition.ToString();
            Properties.Settings.Default.OsdPadding = OsdPadding;
            Properties.Settings.Default.OsdMargin = OsdMargin;
            Properties.Settings.Default.OsdRoundedCorners = OsdRoundedCorners;
            Properties.Settings.Default.OsdTextColour = OsdTextColour;
            Properties.Settings.Default.OsdBackColour = OsdBackColour;
            Properties.Settings.Default.OsdOpacity = OsdOpacity;

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
