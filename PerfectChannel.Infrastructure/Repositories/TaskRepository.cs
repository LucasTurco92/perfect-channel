using PerfectChannel.Domain.Interfaces;
using PerfectChannel.Infrastructure.Context;
using PerfectChannel.Domain.DTO;
using PerfectChannel.Infrastructure.Services.Mappers.Interfaces;
using System;
using System.Linq;

namespace PerfectChannel.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApiContext _context;
        private readonly ITaskMapper _taskMapper;
        private readonly ITasksResponseMapper _tasksResponseMapper;

        public TaskRepository(ApiContext context,ITaskMapper taskMapper,ITasksResponseMapper tasksResponseMapper){
            _context = context;
            _taskMapper = taskMapper;
            _tasksResponseMapper = tasksResponseMapper;
        }

        public void AddNewTask(TaskDTO newTask)
        {
            var task = _taskMapper.Map(newTask);

            _context.Task.Add(task);

            _context.SaveChangesAsync();
        }

        public TaskResponseDTO GetTasks()
        {
            var tasks = _context.Task.Select(taskEntity => _taskMapper.Map(taskEntity)).ToList();

            return _tasksResponseMapper.Map(tasks);
        }
    }
}