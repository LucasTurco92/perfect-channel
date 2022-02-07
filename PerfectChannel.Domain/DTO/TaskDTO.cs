using System;

namespace PerfectChannel.Domain.DTO
{
    public class TaskDTO
    {
        public TaskDTO(string description){
            Id = Guid.NewGuid();
            Description = description;
            _state = new PendingDTO();
        }
          public TaskDTO(Guid  id, string description, IStateDTO state){
            Id = id;
            Description = description;
            _state = state;
        }
        private IStateDTO _state { get; set; }
        public string StateDescription { get {return _state.GetTaskType();} }
        public string Description { get; set; }
        public Guid Id { get;set; }

        public void ChangeState() {
            _state.Handle();
        }
    }
}