using PerfectChannel.Domain.DTO;
using PerfectChannel.Domain.Interfaces;
using PerfectChannel.Domain.Interfaces.Services;

namespace PerfectChannel.Domain.Services
{

    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public TasksResponseDTO GetTasks()
        {
            return _taskRepository.GetTasks();
        }
    }
}