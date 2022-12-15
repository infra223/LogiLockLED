using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiLockLED
{
    public enum LockKey { Caps, Num, Scroll };
    
    interface ILedController
    {
        bool Initialise();
        void Shutdown();

        bool SetLockKeyColor(LockKey key, System.Drawing.Color color);
        
    }
}
