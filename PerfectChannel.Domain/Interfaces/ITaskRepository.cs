using System;
using PerfectChannel.Domain.DTO;

namespace PerfectChannel.Domain.Interfaces
{
    public interface ITaskRepository
    {
        TaskResponseDTO GetTasks();
        void AddNewTask(TaskDTO task);
    }
}

