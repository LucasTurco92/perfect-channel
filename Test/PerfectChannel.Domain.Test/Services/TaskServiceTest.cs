using System;
using System.Collections.Generic;
using Moq;
using PerfectChannel.Domain.DTO;
using PerfectChannel.Domain.Interfaces;
using PerfectChannel.Domain.Interfaces.Services;
using PerfectChannel.Domain.Services;
using Xunit;

namespace Test.PerfectChannel.Services
{
    public class TaskServiceTest
    {
        private ITaskService _taskService;
        private readonly Mock<ITaskRepository> _taskRepository;
        public TaskServiceTest(){
            _taskRepository = new Mock<ITaskRepository>();
            _taskService = new TaskService(_taskRepository.Object);
        }

        [Fact]
        public void When_It_Calls_The_Get_Method_Should_Return_A_Valid_TaskResponse() {
        
        #region Given

        var taskResponse = new TaskResponseDTO{
            Tasks = new List<TaskDTO>()
        };
        
         _taskRepository.Setup(x => x.GetTasks())
            .Returns(taskResponse)
            .Verifiable();
        #endregion
        
        #region When
        
        
        var validTaskResponse = _taskService.GetTasks();
            
        #endregion

        #region Then

        Assert.NotNull(validTaskResponse);
        Assert.Equal(taskResponse.Tasks.Count, validTaskResponse.Tasks.Count);
        _taskRepository.Verify(x=>x.GetTasks(), Times.Once);
        
        #endregion
        }

        [Fact]
        public void When_It_Calls_The_AddNewTask_Method_Should_Return_A_Valid_New_TaskDTO()
        {
        
        #region Given

        var id = Guid.NewGuid();

        var taskResponse = new TaskResponseDTO{
            Tasks = new List<TaskDTO>()
        };
        var description = new LastDescriptionDTO{
            Description = "Description"
        };
        var task = new TaskDTO(id,description.Description,new PendingDTO());

        _taskRepository.Setup(x => x.AddNewTask(It.IsAny<TaskDTO>()))
        .Verifiable();

        #endregion
        
        #region When
        
        var validTaskResponse = _taskService.AddNewTask(description);
            
        #endregion

        #region Then

        Assert.NotNull(validTaskResponse.Id);
        Assert.Equal(task.Description, validTaskResponse.Description);
        Assert.Equal(task.StateDescription, validTaskResponse.StateDescription);
        
        #endregion
        }
    } 
}