using Microsoft.Win32;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogiLockLED
{
    class LogiLockLEDApp : ApplicationContext
    {
        private readonly LedThread ledThread;
        private readonly NotifyIcon notifyIcon;
        
        private readonly ConfigurationForm configWindow;
        private readonly ContextMenu contextMenu;
        private readonly IndicatorPopup popupWindow;
        private readonly LedSettings ledSettings;        
        private readonly MenuItem configEnableItem;
        private readonly TrayManager trayManager;
        private SynchronizationContext appCon;

        public LogiLockLEDApp()
        {
            appCon = new SynchronizationContext();

            ledSettings = new LedSettings();
            ledSettings.LoadSettings();

            configWindow = new ConfigurationForm(ref ledSettings);
            configWindow.SettingsUpdated += ConfigWindow_OnSettingsUpdated;
            popupWindow = new IndicatorPopup();
            popupWindow.Configure(ledSettings);

            ledThread = new LedThread(ref ledSettings);
            ledThread.KeylockUpdated += ledThread_OnKeylockUpdated;
            ledThread.StartThread();            

            configEnableItem = new MenuItem("Enabled", new EventHandler(ToggleEnabled)) { 
                Checked = ledSettings.EnableKeyLockLEDs };
            
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Properties.Resources.appicon;
            contextMenu = new ContextMenu(new MenuItem[]{
                new MenuItem("LogiLockLED") { Enabled = false},
                new MenuItem("-"),
                configEnableItem,
                new MenuItem("Configuration", new EventHandler(ShowConfig)),
                new MenuItem("Exit", new EventHandler(Exit))
            });
            notifyIcon.ContextMenu = contextMenu;
            notifyIcon.DoubleClick += ShowConfig;
            notifyIcon.Visible = true;

            trayManager = new TrayManager(ledSettings);


            SystemEvents.PowerModeChanged += OnPowerModeChange;            
        }

       
        private void ledThread_OnKeylockUpdated(object sender, EventArgs e)
        {
            var args = (e as KeylockChangeArgs);
            if (ledSettings.OsdEnabled)
            {
                popupWindow.Invoke(new Action<LockKey, bool>(popupWindow.ShowLockState), args.LockKey, args.IsOn);                
            }

            appCon.Post(new SendOrPostCallback((o) => {
                trayManager.UpdateIndicators(); 
            }), null);

        }

        private void ConfigWindow_OnSettingsUpdated(object sender, EventArgs e)
        {
            PropagateSettings();
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
            PropagateSettings();            
            configEnableItem.Checked = ledSettings.EnableKeyLockLEDs;
            popupWindow.ShowMessage((ledSettings.EnableKeyLockLEDs ? "Enabled" : "Disabled"));
        }

        private void PropagateSettings()
        {
            ledThread.UpdateSettings(ledSettings);
            popupWindow.Configure(ledSettings);            
            trayManager.UpdateSettings(ledSettings);
        }


        private void Exit(object sender, EventArgs e)
        {
            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            notifyIcon.Visible = false;
            trayManager.HideAll();
            
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
