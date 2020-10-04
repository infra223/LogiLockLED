using LedCSharp;
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
        private LedSettings ledSettings;
        private Thread thread;
        private bool stopThread;
        private bool refreshRequired = false;
        public event EventHandler KeylockUpdated;

        bool _ledApiInit;

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);

        public LedThread(ref LedSettings settings)
        {
            ledSettings = settings;
            
        }

        public void RestartThread()
        {
            StopThread();
            StartThread();
        }

        public void StartThread()
        {
            if (ledSettings.EnableKeyLockLEDs)
            {
                _ledApiInit = LogitechGSDK.LogiLedInit();
                LogitechGSDK.LogiLedSetTargetDevice(LogitechGSDK.LOGI_DEVICETYPE_PERKEY_RGB);
                LogitechGSDK.LogiLedSaveCurrentLighting();
                LogitechGSDK.LogiLedStopEffects();

                if (thread == null || thread.ThreadState != ThreadState.Running)
                {
                    thread = new Thread(ThreadMain);
                    stopThread = false;
                    thread.Start();
                }                
            }
        }

        public void StopThread()
        {
            stopThread = true;
            thread?.Abort();
            if (_ledApiInit)
            {
                LogitechGSDK.LogiLedRestoreLighting();
                LogitechGSDK.LogiLedShutdown();
                _ledApiInit = false;
            }
            
        }

        public void UpdateSettings(LedSettings settings)
        {
            ledSettings = settings;
            if (ledSettings.EnableKeyLockLEDs)
            {                
                refreshRequired = true;
                if(thread == null || thread.ThreadState != ThreadState.Running)
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

            while (!stopThread)
            { 
                bool CapsLock = (((ushort)GetKeyState(0x14)) & 0xffff) != 0;
                bool NumLock = (((ushort)GetKeyState(0x90)) & 0xffff) != 0;
                bool ScrollLock = (((ushort)GetKeyState(0x91)) & 0xffff) != 0;

                if ((refreshRequired || prevNumLock != NumLock))
                {                    
                    prevNumLock = NumLock;

                    if(!firstLoop)
                        KeylockUpdated?.Invoke(this, new KeylockChangeArgs(LockKey.Num, NumLock));
                    
                    if (ledSettings.EnableNum)
                    {
                        if (NumLock)
                            LogiLedSetLightingForKeyWithKeyName(keyboardNames.NUM_LOCK, ledSettings.NumOnColor);
                        else
                            LogiLedSetLightingForKeyWithKeyName(keyboardNames.NUM_LOCK, ledSettings.NumOffColor);
                    }
                }

                if ((refreshRequired || prevCapsLock != CapsLock))
                {
                    prevCapsLock = CapsLock;

                    if (!firstLoop)
                        KeylockUpdated?.Invoke(this, new KeylockChangeArgs(LockKey.Caps, CapsLock));

                    if (ledSettings.EnableCaps)
                    {
                        if (CapsLock)
                            LogiLedSetLightingForKeyWithKeyName(keyboardNames.CAPS_LOCK, ledSettings.CapsOnColor);
                        else
                            LogiLedSetLightingForKeyWithKeyName(keyboardNames.CAPS_LOCK, ledSettings.CapsOffColor);
                    }
                }

                if ((refreshRequired || prevScrollLock != ScrollLock))
                {
                    prevScrollLock = ScrollLock;

                    if (!firstLoop)
                        KeylockUpdated?.Invoke(this, new KeylockChangeArgs(LockKey.Scroll, ScrollLock));

                    if (ledSettings.EnableScroll)
                    {
                        if (ScrollLock)
                            LogiLedSetLightingForKeyWithKeyName(keyboardNames.SCROLL_LOCK, ledSettings.ScrollOnColor);
                        else
                            LogiLedSetLightingForKeyWithKeyName(keyboardNames.SCROLL_LOCK, ledSettings.ScrollOffColor);
                    }
                }
                refreshRequired = false;
                firstLoop = false;
                Thread.Sleep(75);                              
            }           
            
        }

        private static bool LogiLedSetLightingForKeyWithKeyName(keyboardNames keyCode, System.Drawing.Color color)
        {
            return LogitechGSDK.LogiLedSetLightingForKeyWithKeyName(keyCode, color.R * 100 / 255, color.G * 100 / 255, color.B * 100 / 255);
        }
    }

    public enum LockKey { Caps, Num, Scroll};

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
