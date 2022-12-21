using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace LogiLockLED
{
    public class LedThread
    {
        private LedSettings _ledSettings;
        private Thread _thread;
        private bool _stopThread;
        private bool _refreshRequired = false;
        private ILedController _ledController;
        private bool _ledApiInit;
        private System.Timers.Timer _refreshTimer;

        public event EventHandler KeylockUpdated;        

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);

        public LedThread(ref LedSettings settings)
        {
            _ledSettings = settings;
            _refreshTimer = new System.Timers.Timer(1000);
            _refreshTimer.Elapsed += refreshTimerEvent;
            _refreshTimer.Start();
        }

        private void refreshTimerEvent(object sender, ElapsedEventArgs e)
        {
            Refresh();
        }

        public void RestartThread()
        {
            StopThread();
            StartThread();
        }

        public void StartThread()
        {
            _ledController = createLedController();

            if (_ledSettings.EnableKeyLockLEDs)
            {
                _ledApiInit = _ledController.Initialise();

                if (_thread == null || _thread.ThreadState != ThreadState.Running)
                {
                    _thread = new Thread(ThreadMain);
                    _stopThread = false;
                    _thread.Start();
                }                
            }
        }

        private ILedController createLedController()
        {
            if (_ledSettings.LedController == "OpenRGB")
                return new OpenRgbController();
            if (_ledSettings.LedController == "Logitech G HUB")
                return new LogitechSDKController();
            
            return new DisabledController();            
        }

        public void StopThread()
        {
            _stopThread = true;
            _thread?.Abort();
            if (_ledApiInit)
            {
                _ledController.Shutdown();
                _ledApiInit = false;
            }
            
        }

        public void UpdateSettings(LedSettings settings)
        {
            _ledSettings = settings;
            if (_ledSettings.EnableKeyLockLEDs)
            {                
                if (_thread == null || _thread.ThreadState != ThreadState.Running)
                {
                    StartThread();
                }
                Refresh();
            }
            else
            {
                StopThread();
            }
        }

        public void Refresh()
        {
            _refreshRequired = true;
        }

        private void ThreadMain()
        {
            bool prevCapsLock = (((ushort)GetKeyState(0x14)) & 0xffff) == 0;
            bool prevNumLock = (((ushort)GetKeyState(0x90)) & 0xffff) == 0;
            bool prevScrollLock = (((ushort)GetKeyState(0x91)) & 0xffff) == 0;
            bool firstLoop = true;

            while (!_stopThread)
            { 
                bool CapsLock = (((ushort)GetKeyState(0x14)) & 0xffff) != 0;
                bool NumLock = (((ushort)GetKeyState(0x90)) & 0xffff) != 0;
                bool ScrollLock = (((ushort)GetKeyState(0x91)) & 0xffff) != 0;

                if ((_refreshRequired || prevNumLock != NumLock))
                {                    
                    prevNumLock = NumLock;

                    if(!firstLoop && !_refreshRequired)
                        KeylockUpdated?.Invoke(this, new KeylockChangeArgs(LockKey.Num, NumLock));
                    
                    if (_ledSettings.EnableNum)
                    {
                        var col = NumLock ? _ledSettings.NumOnColor : _ledSettings.NumOffColor;
                        setKeyColor(LockKey.Num, col, _refreshRequired);                        
                    }
                }

                if ((_refreshRequired || prevCapsLock != CapsLock))
                {
                    prevCapsLock = CapsLock;

                    if (!firstLoop && !_refreshRequired)
                        KeylockUpdated?.Invoke(this, new KeylockChangeArgs(LockKey.Caps, CapsLock));

                    if (_ledSettings.EnableCaps)
                    {                        
                        var col = CapsLock ? _ledSettings.CapsOnColor : _ledSettings.CapsOffColor;
                        setKeyColor(LockKey.Caps, col, _refreshRequired);
                    }
                }

                if ((_refreshRequired || prevScrollLock != ScrollLock))
                {
                    prevScrollLock = ScrollLock;

                    if (!firstLoop && !_refreshRequired)
                        KeylockUpdated?.Invoke(this, new KeylockChangeArgs(LockKey.Scroll, ScrollLock));

                    if (_ledSettings.EnableScroll)
                    {
                        var col = ScrollLock ? _ledSettings.ScrollOnColor : _ledSettings.ScrollOffColor;
                        setKeyColor(LockKey.Scroll, col, _refreshRequired);
                    }
                }

                _refreshRequired = false;
                firstLoop = false;
                Thread.Sleep(50);                              
            }           
            
        }

        private bool setKeyColor(LockKey key, System.Drawing.Color col, bool forceSet = true)
        {            
            if (forceSet)
            {
                var adj = col.B > 128 ? -5 : 5;
                var col_adj = System.Drawing.Color.FromArgb(col.A, col.R, col.G, col.B + adj); 
                _ledController.SetLockKeyColor(key, col_adj);
                Thread.Sleep(50);
            }
            return _ledController.SetLockKeyColor(key, col);
        }

        
    }

    

    public class KeylockChangeArgs : EventArgs
    {
        public LockKey LockKey { get; set; }
        public bool IsOn { get; set; }

        public KeylockChangeArgs(LockKey lockKey, bool isOn)
        {
            this.LockKey = lockKey;
            this.IsOn = isOn;
        }

    }

}
