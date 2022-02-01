using System;

namespace PerfectChannel.Domain.DTO
{
    public class TaskDTO
    {
        private Guid _id;
        public TaskDTO(){
            _id = Guid.NewGuid();
        }
        public string State { get; set; }
        public string Description { get; set; }
        public Guid Id { get{ return _id;} }
    }
}