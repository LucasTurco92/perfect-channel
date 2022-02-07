using System;
namespace PerfectChannel.Infrastructure.Entities
{
    public class Task
    {
        public string State { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
    }
}

