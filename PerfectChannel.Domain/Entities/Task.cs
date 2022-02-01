using System;
namespace PerfectChannel.Domain.Entities
{
    public class Task
    {
        public string State { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
    }
}

