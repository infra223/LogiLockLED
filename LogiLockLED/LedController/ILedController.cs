using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiLockLED
{
    public enum LockKey { Caps, Num, Scroll, Mute, PrtSc, F12, Num_Asterisk};
    
    interface ILedController
    {
        bool Initialise();
        void Shutdown();

        bool SetLockKeyColor(LockKey key, System.Drawing.Color color);
        
    }
}
