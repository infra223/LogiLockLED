using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public event EventHandler KeylockUpdated;        

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);

        public LedThread(ref LedSettings settings)
        {
            _ledSettings = settings;           
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
                _refreshRequired = true;
                if(_thread == null || _thread.ThreadState != ThreadState.Running)
                {
                    StartThread();
                }
            }
            else
            {
                StopThread();
            }
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

                    if(!firstLoop)
                        KeylockUpdated?.Invoke(this, new KeylockChangeArgs(LockKey.Num, NumLock));
                    
                    if (_ledSettings.EnableNum)
                    {
                        _ledController.SetLockKeyColor(LockKey.Num, NumLock ? _ledSettings.NumOnColor : _ledSettings.NumOffColor);
                    }
                }

                if ((_refreshRequired || prevCapsLock != CapsLock))
                {
                    prevCapsLock = CapsLock;

                    if (!firstLoop)
                        KeylockUpdated?.Invoke(this, new KeylockChangeArgs(LockKey.Caps, CapsLock));

                    if (_ledSettings.EnableCaps)
                    {
                        _ledController.SetLockKeyColor(LockKey.Caps, CapsLock ? _ledSettings.CapsOnColor : _ledSettings.CapsOffColor);
                    }
                }

                if ((_refreshRequired || prevScrollLock != ScrollLock))
                {
                    prevScrollLock = ScrollLock;

                    if (!firstLoop)
                        KeylockUpdated?.Invoke(this, new KeylockChangeArgs(LockKey.Scroll, ScrollLock));

                    if (_ledSettings.EnableScroll)
                    {
                        _ledController.SetLockKeyColor(LockKey.Scroll, ScrollLock ? _ledSettings.ScrollOnColor : _ledSettings.ScrollOffColor);                       
                    }
                }
                _refreshRequired = false;
                firstLoop = false;
                Thread.Sleep(75);                              
            }           
            
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
