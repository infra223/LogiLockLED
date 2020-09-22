using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogiLockLED
{
    class LogiLockLEDApp : ApplicationContext
    {
        private readonly LedThread ledThread;
        private readonly NotifyIcon notifyIcon;
        private readonly ConfigurationForm configWindow;
        private readonly LedSettings ledSettings;

        public LogiLockLEDApp()
        {
            ledSettings = new LedSettings();
            ledSettings.LoadSettings();
            ledThread = new LedThread(ref ledSettings);
            ledThread.StartThread();

            configWindow = new ConfigurationForm(ref ledSettings);
            configWindow.SettingsUpdated += ConfigWindow_OnSettingsUpdated;

            MenuItem configMenuItem = new MenuItem("Configuration", new EventHandler(ShowConfig));
            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));

            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Properties.Resources.appicon;
            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[]
                { configMenuItem, exitMenuItem });
            notifyIcon.DoubleClick += ShowConfig;
            notifyIcon.Visible = true;

        }

        private void ConfigWindow_OnSettingsUpdated(object sender, EventArgs e)
        {
            ledThread.UpdateSettings(ledSettings);
        }

        void ShowConfig(object sender, EventArgs e)
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

        void Exit(object sender, EventArgs e)
        {
            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            notifyIcon.Visible = false;
            configWindow.Close();
            ledThread.StopThread();            

            this.ExitThread();
            Application.Exit();
        }

    }
}
