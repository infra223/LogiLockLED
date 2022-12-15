using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LedCSharp;

namespace LogiLockLED
{
    public class DisabledController : ILedController
    {
        public bool Initialise()
        {           
            return true;
        }

        public void Shutdown()
        {
        }

        public bool SetLockKeyColor(LockKey key, System.Drawing.Color color)
        {
            return false;
        }
       
    }
}
