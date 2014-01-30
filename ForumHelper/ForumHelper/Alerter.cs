using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ForumHelper
{
    static class Alerter
    {
        internal static void Beep()
        {
            Console.Beep();
        }
        internal static void ShowToast()
        {
            ToastForm toast = new ToastForm();
            Thread newThread = new Thread(() => { toast.ShowDialog(); });

            newThread.SetApartmentState(ApartmentState.STA);
            newThread.Start();
            while (toast == null || toast.IsHandleCreated == false)
            {
                Thread.Sleep(3000);
            }
        }
    }
}
