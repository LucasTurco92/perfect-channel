using System;
using System.Collections.Generic;
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

        public TaskDTO AddNewTask(LastDescriptionDTO description)
        {
            var newTask = new TaskDTO(description.Description);

            _taskRepository.AddNewTask(newTask);
        
            return newTask;
        }

        public TaskResponseDTO GetTasks()
        {
            return _taskRepository.GetTasks();
        }
    }
}