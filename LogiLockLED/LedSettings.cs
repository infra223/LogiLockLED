using System.Windows.Forms;
using System.Drawing;
using Microsoft.Win32;

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
