using PerfectChannel.Domain.DTO;

namespace PerfectChannel.Domain.Interfaces.Services
{
    public interface ITaskService
    {
        TasksResponseDTO GetTasks();
    }
}