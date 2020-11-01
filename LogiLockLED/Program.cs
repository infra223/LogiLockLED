using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogiLockLED
{
    static class Program
    {
        private static Guid appGuid = new Guid("fcb10e99-94cd-4cb1-8bea-b092c9aec878");
        private static Mutex singleInstanceMutex;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (singleInstanceMutex = new Mutex(false, appGuid.ToString()))
            {
                if (!singleInstanceMutex.WaitOne(5000, false))
                {
                    MessageBox.Show("Another instance of LogiLockLED is already running.");
                    return;
                }

                Application.Run(new LogiLockLEDApp());
                GC.KeepAlive(singleInstanceMutex);
            }

        }

        
     
    }
}
