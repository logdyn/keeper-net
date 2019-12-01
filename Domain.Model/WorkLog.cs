using System;
using Logdyn.Keeper.Domain.Logic;

namespace Logdyn.Keeper.Domain
{
    public class WorkLog
    {
        public string Comment { get; }
        public WorkTimer Timer { get; }

        internal WorkLog() : this((DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond), 
                0, "") {}
        
        internal WorkLog(long start, long duration, string comment)
        {
            Comment = comment;
            Timer = new WorkTimer(start, duration);
        }
    }
}