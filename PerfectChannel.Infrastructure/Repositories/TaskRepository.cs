
using System.Collections.Generic;
using PerfectChannel.Domain.DTO;
using PerfectChannel.Domain.Interfaces;

namespace PerfectChannel.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public TasksResponseDTO GetTasks()
        {
            return new TasksResponseDTO{
                Tasks = new List<TaskDTO>()
            };
        }
    }
}