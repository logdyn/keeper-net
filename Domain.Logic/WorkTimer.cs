using System;

namespace Logdyn.Keeper.Domain.Logic
{
    public class WorkTimer
    {
        public long Init => _init;
        private long _start;
        private long _duration;
        private long _init;

        public WorkTimer(long start, long duration = 0)
        {
            _init = start;
            _start = start;
            _duration = duration;
        }

        public long GetDuration()
        {
            return _duration + GetSinceStarted();
        }

        public bool IsStopped()
        {
            return _start == -1;
        }

        public long Start()
        {
            _duration += GetSinceStarted();
            _start = CurrentTimeMillis();
            if (_init == -1)
                _init = _start;

            return _start;
        }

        public long Stop()
        {
            _duration += GetSinceStarted();
            _start = -1;
            return _duration;
        }

        public long AddMillis(long millis)
        {
            _start -= millis;
            return _duration;
        }

        private long CurrentTimeMillis() => DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;

        private long GetSinceStarted()
        {
            return IsStopped() ? 0 : CurrentTimeMillis() - _start;
        }
    }
}