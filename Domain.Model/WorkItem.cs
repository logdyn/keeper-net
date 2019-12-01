using System;

namespace Logdyn.Keeper.Domain
{
    public class WorkItem
    {
        public string Id { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Uri Url { get; set; }
        public WorkLog WorkLog { get; set; } = new WorkLog();
    }
}