using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace LogiLockLED
{
    class LogiLockLEDApp : ApplicationContext
    {
        private readonly LedThread ledThread;
        private readonly NotifyIcon notifyIcon;
        private readonly ConfigurationForm configWindow;
        private readonly LedSettings ledSettings;

        private readonly MenuItem configEnableItem;

        public LogiLockLEDApp()
        {
            ledSettings = new LedSettings();
            ledSettings.LoadSettings();

            ledThread = new LedThread(ref ledSettings);
            ledThread.StartThread();

            configWindow = new ConfigurationForm(ref ledSettings);
            configWindow.SettingsUpdated += ConfigWindow_OnSettingsUpdated;

            configEnableItem = new MenuItem("Enabled", new EventHandler(ToggleEnabled));
            configEnableItem.Checked = ledSettings.EnableKeyLockLEDs;
            MenuItem configMenuItem = new MenuItem("Configuration", new EventHandler(ShowConfig));
            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));

            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Properties.Resources.appicon;
            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[]
                { configEnableItem, configMenuItem, exitMenuItem });
            notifyIcon.DoubleClick += ShowConfig;
            notifyIcon.Visible = true;

            SystemEvents.PowerModeChanged += OnPowerModeChange;
        }        
        

        private void ConfigWindow_OnSettingsUpdated(object sender, EventArgs e)
        {
            ledThread.UpdateSettings(ledSettings);
        }

        private void ShowConfig(object sender, EventArgs e)
        {
            // If we are already showing the window, merely focus it.
            if (configWindow.Visible)
            {
                configWindow.Activate();
            }
            else
            {
                configWindow.ShowDialog();
            }
        }

        private void ToggleEnabled(object sender, EventArgs e)
        {
            ledSettings.EnableKeyLockLEDs = !ledSettings.EnableKeyLockLEDs;
            ledSettings.SaveSettings();
            ledThread.UpdateSettings(ledSettings);
            configEnableItem.Checked = ledSettings.EnableKeyLockLEDs;
        }

        private void Exit(object sender, EventArgs e)
        {
            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            notifyIcon.Visible = false;
            configWindow.Close();
            ledThread.StopThread();            

            this.ExitThread();
            Application.Exit();
        }
        
        private void OnPowerModeChange(object s, PowerModeChangedEventArgs e)
        {
            if (e.Mode == PowerModes.Resume)
            {                
                ledThread.RestartThread();                
            }
        }

    }
}
