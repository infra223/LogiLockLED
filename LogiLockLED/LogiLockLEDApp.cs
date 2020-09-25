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
        private readonly IndicatorPopup popupWindow;
        private readonly LedSettings ledSettings;        
        private readonly MenuItem configEnableItem;

        public LogiLockLEDApp()
        {
            ledSettings = new LedSettings();
            ledSettings.LoadSettings();

            configWindow = new ConfigurationForm(ref ledSettings);
            configWindow.SettingsUpdated += ConfigWindow_OnSettingsUpdated;
            popupWindow = new IndicatorPopup();
            popupWindow.Configure(ledSettings);
            //popupWindow.LoadForm();

            ledThread = new LedThread(ref ledSettings);
            ledThread.KeylockUpdated += ledThread_OnKeylockUpdated;
            ledThread.StartThread();            

            configEnableItem = new MenuItem("Enabled", new EventHandler(ToggleEnabled)) { 
                Checked = ledSettings.EnableKeyLockLEDs };
            
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Properties.Resources.appicon;
            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[]{ 
                new MenuItem("LogiLockLED") { Enabled = false}, 
                new MenuItem("-"), 
                configEnableItem, 
                new MenuItem("Configuration", new EventHandler(ShowConfig)),
                new MenuItem("Exit", new EventHandler(Exit))
            });
            notifyIcon.DoubleClick += ShowConfig;
            notifyIcon.Visible = true;

            SystemEvents.PowerModeChanged += OnPowerModeChange;            
        }

        private void ledThread_OnKeylockUpdated(object sender, EventArgs e)
        {
            var args = (e as KeylockChangeArgs);
            if (ledSettings.OsdEnabled)
            {
                popupWindow.Invoke(new Action<LockKey, bool>(popupWindow.ShowLockState), args.LockKey, args.IsOn);
            }
        }

        private void ConfigWindow_OnSettingsUpdated(object sender, EventArgs e)
        {
            popupWindow.Configure(ledSettings);
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
