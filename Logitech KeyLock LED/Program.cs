using System;
using System.Runtime.InteropServices;
using System.Threading;
using LedCSharp;

namespace Logitech_KeyLock_LED
{
    class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);

        static void Main(string[] args)
        {
            
            LogitechGSDK.LogiLedInit();
            //LogitechGSDK.LogiLedSaveCurrentLighting();
            //LogitechGSDK.LogiLedSetLighting(100, 100, 0);
            //LogitechGSDK.LogiLedRestoreLighting();
            //LogitechGSDK.LogiLedSaveLightingForKey(keyboardNames.NUM_LOCK);
            //LogitechGSDK.LogiLedSetLightingForKeyWithKeyName(keyboardNames.CAPS_LOCK, 100, 80, 70);
            //LogitechGSDK.LogiLedSaveLightingForKey(keyboardNames.CAPS_LOCK);

            bool prevCapsLock = (((ushort)GetKeyState(0x14)) & 0xffff) == 0;
            bool prevNumLock = (((ushort)GetKeyState(0x90)) & 0xffff) == 0;
            bool prevScrollLock = (((ushort)GetKeyState(0x91)) & 0xffff) == 0;


            char key = char.MinValue;
            
            while (char.ToLower(key) != 'x' )
            {

                bool CapsLock = (((ushort)GetKeyState(0x14)) & 0xffff) != 0;
                bool NumLock = (((ushort)GetKeyState(0x90)) & 0xffff) != 0;
                bool ScrollLock = (((ushort)GetKeyState(0x91)) & 0xffff) != 0;
                bool updateUI = false;

                if (prevNumLock != NumLock)
                {
                    prevNumLock = NumLock;
                    if (NumLock)
                        LogitechGSDK.LogiLedSetLightingForKeyWithKeyName(keyboardNames.NUM_LOCK, 100, 0, 0);
                    else
                        LogitechGSDK.LogiLedSetLightingForKeyWithKeyName(keyboardNames.NUM_LOCK, 0, 0, 0);
                    updateUI = true;
                }

                if (prevCapsLock != CapsLock)
                {
                    prevCapsLock = CapsLock;
                    if (CapsLock)
                        LogitechGSDK.LogiLedSetLightingForKeyWithKeyName(keyboardNames.CAPS_LOCK, 100, 0, 0);
                    else
                        LogitechGSDK.LogiLedSetLightingForKeyWithKeyName(keyboardNames.CAPS_LOCK, 0, 0, 0);
                    updateUI = true;
                }

                if (prevScrollLock != ScrollLock)
                {
                    prevScrollLock = ScrollLock;
                    //if (ScrollLock)
                    //    LogitechGSDK.LogiLedSetLightingForKeyWithKeyName(keyboardNames.SCROLL_LOCK, 100, 0, 0);
                    //else
                    //    LogitechGSDK.LogiLedSetLightingForKeyWithKeyName(keyboardNames.SCROLL_LOCK, 0, 0, 0);
                    updateUI = true;
                }

                Thread.Sleep(100);

                if (updateUI)                
                    printUI(CapsLock, NumLock, ScrollLock);
                

                if (Console.KeyAvailable)
                    key = Console.ReadKey(true).KeyChar;
            }

            LogitechGSDK.LogiLedShutdown();
        }

        private static void printUI(bool caps, bool num, bool scroll)
        {
            Console.Clear();
            Console.WriteLine("KeyLock LED Inddicator ");
            Console.WriteLine("---------------------- \n");
            Console.WriteLine($"Caps Lock   :  {(caps?"on":"off")} ");
            Console.WriteLine($"Num Lock    :  {(num ? "on":"off")} ");
            Console.WriteLine($"Scroll Lock :  {(scroll ? "on":"off")} ");
            Console.WriteLine("\n\n\nPress 'x' to exit");
            
        }

    }
}
