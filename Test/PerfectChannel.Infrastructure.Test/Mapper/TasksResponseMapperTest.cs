using System.Collections.Generic;
using PerfectChannel.Domain.DTO;
using PerfectChannel.Infrastructure.Entities;
using PerfectChannel.Infrastructure.Services.Mappers.Interfaces;

namespace PerfectChannel.Infrastructure.Services.Mappers
{
    public class TasksResponseMapper: ITasksResponseMapper
    {
        public List<Task> Map(TaskResponseDTO TaskResponse)
        {
            throw new System.NotImplementedException();
        }

        public TaskResponseDTO Map(List<TaskDTO> Tasks)
        {
            return new TaskResponseDTO{
                Tasks = Tasks
            };
        }
    }
}