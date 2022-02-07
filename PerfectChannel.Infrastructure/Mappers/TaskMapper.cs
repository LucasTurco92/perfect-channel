using PerfectChannel.Domain.DTO;
using PerfectChannel.Domain.DTO.Interfaces;
using PerfectChannel.Infrastructure.Entities;
using PerfectChannel.Infrastructure.Services.Mappers.Interfaces;

namespace PerfectChannel.Infrastructure.Services.Mappers
{
    public class TaskMapper : ITaskMapper
    {
        public readonly IStateFactory _stateFactory;
        public TaskMapper(IStateFactory stateFactory){
            _stateFactory = stateFactory;
        }

        public Task Map(TaskDTO task)
        {
            return new Task{
                Id = task.Id,
                Description = task.Description,
                State = task.StateDescription
            };
        }

        public TaskDTO Map(Task task)
        {
            var state = _stateFactory.CreateState(task.State);

            return new TaskDTO(task.Id,task.Description,state);
        }
    }
}