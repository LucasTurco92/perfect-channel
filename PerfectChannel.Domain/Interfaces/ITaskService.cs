using PerfectChannel.Domain.DTO;

namespace PerfectChannel.Domain.Interfaces.Services
{
    public interface ITaskService
    {
        TaskResponseDTO GetTasks();
        TaskDTO AddNewTask(LastDescriptionDTO description);
    }
}