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
            thread.Abort();
            try
            {
                LogitechGSDK.LogiLedShutdown();
            }
            catch { }
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
            LogitechGSDK.LogiLedInit();
            bool prevCapsLock = (((ushort)GetKeyState(0x14)) & 0xffff) == 0;
            bool prevNumLock = (((ushort)GetKeyState(0x90)) & 0xffff) == 0;
            bool prevScrollLock = (((ushort)GetKeyState(0x91)) & 0xffff) == 0;

            while (!stopThread)
            {

                bool CapsLock = (((ushort)GetKeyState(0x14)) & 0xffff) != 0;
                bool NumLock = (((ushort)GetKeyState(0x90)) & 0xffff) != 0;
                bool ScrollLock = (((ushort)GetKeyState(0x91)) & 0xffff) != 0;

                if ((refreshRequired || prevNumLock != NumLock) && ledSettings.EnableNum)
                {
                    prevNumLock = NumLock;
                    if (NumLock)
                        LogiLedSetLightingForKeyWithKeyName(keyboardNames.NUM_LOCK, ledSettings.NumOnColour);
                    else
                        LogiLedSetLightingForKeyWithKeyName(keyboardNames.NUM_LOCK, ledSettings.NumOffColour);
                }

                if ((refreshRequired || prevCapsLock != CapsLock) && ledSettings.EnableCaps)
                {
                    prevCapsLock = CapsLock;
                    if (CapsLock)
                        LogiLedSetLightingForKeyWithKeyName(keyboardNames.CAPS_LOCK, ledSettings.CapsOnColour);
                    else
                        LogiLedSetLightingForKeyWithKeyName(keyboardNames.CAPS_LOCK, ledSettings.CapsOffColour);
                }

                if ((refreshRequired || prevScrollLock != ScrollLock) && ledSettings.EnableScroll)
                {
                    prevScrollLock = ScrollLock;
                    if (ScrollLock)
                        LogiLedSetLightingForKeyWithKeyName(keyboardNames.SCROLL_LOCK, ledSettings.ScrollOnColour);
                    else
                        LogiLedSetLightingForKeyWithKeyName(keyboardNames.SCROLL_LOCK, ledSettings.ScrollOffColour);
                }
                refreshRequired = false;
                Thread.Sleep(100);                              
            }

            LogitechGSDK.LogiLedShutdown();
        }

        private static bool LogiLedSetLightingForKeyWithKeyName(keyboardNames keyCode, System.Drawing.Color color)
        {
            return LogitechGSDK.LogiLedSetLightingForKeyWithKeyName(keyCode, color.R * 100 / 255, color.G * 100 / 255, color.B * 100 / 255);
        }
    }
}
