using System.Collections.Generic;
using Moq;
using PerfectChannel.Domain.DTO;
using PerfectChannel.Domain.Entities;
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
        }

        [Fact]
        public void When_It_Calls_The_Get_Method_Should_Return_A_Valid_TaskResponse() {
        
        #region Given

        var taskResponse = new TasksResponseDTO{
            Tasks = new List<TaskDTO>()
        };
        
         _taskRepository.Setup(x => x.GetTasks())
            .Returns(taskResponse)
            .Verifiable();
        #endregion
        
        #region When
        
        _taskService = new TaskService(_taskRepository.Object);
        var validTaskResponse = _taskService.GetTasks();
            
        #endregion

        #region Then

        Assert.NotNull(validTaskResponse);
        Assert.Equal(taskResponse.Tasks.Count, validTaskResponse.Tasks.Count);
        _taskRepository.Verify(x=>x.GetTasks(), Times.Once);
        
        #endregion
        }
    } 
}