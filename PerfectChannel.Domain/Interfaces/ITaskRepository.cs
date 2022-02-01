using PerfectChannel.Domain.DTO;

namespace PerfectChannel.Domain.Interfaces
{
    public interface ITaskRepository
    {
        TasksResponseDTO GetTasks();
    }
}

