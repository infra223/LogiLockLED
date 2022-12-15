using OpenRGB.NET;
using OpenRGB.NET.Enums;
using OpenRGB.NET.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiLockLED
{
    public class OpenRgbController : ILedController, IDisposable
    {
        private OpenRGBClient _client;

        public bool Initialise()
        {
            try
            {
                _client = new OpenRGBClient(name: "LogiLockLED");
            }
            catch(Exception e)
            {
                return false;
            }

            return true;
        }

        public bool SetLockKeyColor(LockKey key, System.Drawing.Color color)
        {
            try
            {
                if (_client == null)
                    _client = new OpenRGBClient(name: "LogiLockLED");

                int controllerCount = _client.GetControllerCount();
                for (int i = 0; i < controllerCount; i++)
                {
                    Device device = _client.GetControllerData(i);
                    if (device.Type == DeviceType.Keyboard)
                    {
                        Console.WriteLine(device.Name);
                        string keyName = string.Empty;
                        switch (key)
                        {
                            case LockKey.Num:
                                keyName = "Key: Num Lock";
                                break;

                            case LockKey.Caps:
                                keyName = "Key: Caps Lock";
                                break;

                            case LockKey.Scroll:
                                keyName = "Key: Scroll Lock";
                                break;

                        }

                        var ledNumIndex = device.Leds.ToList().FindIndex(a => a.Name == keyName);
                        if (ledNumIndex == -1)
                            continue;

                        var ledColors = device.Colors;
                        ledColors[ledNumIndex] = new OpenRGB.NET.Models.Color(color.R, color.G, color.B);
                        device.Update(ledColors);

                    }

                }
            }
            catch
            {
                return false;
            }

            return true;

        }

        public void Shutdown()
        {
            _client.Disconnect();
        }

        public void Dispose()
        {
            _client.Dispose();            
        }
    }
}
