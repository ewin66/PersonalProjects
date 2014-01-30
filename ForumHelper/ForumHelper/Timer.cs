using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ForumHelper
{
    class Timer
    {
        public event EventHandler<URLEventArgs> OnTick;
        uint interval;


        uint Interval
        {
            get { return this.interval; }
            set { this.interval = value; }
        }

        public Timer(uint interval)
        {
            this.Interval = interval;
        }


       public  void Tick(URLEventArgs e)
        {
            if (OnTick != null)
            {
                Thread thread = new Thread(() =>
                    {
                        while (true)
                        {
                            OnTick(this, e);
                            Thread.Sleep((int)this.Interval);
                        }
                    });
                thread.Start();
            }
        }
    }
}
