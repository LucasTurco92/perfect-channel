using Moq;
using PerfectChannel.Domain.DTO;
using PerfectChannel.Domain.Interfaces.Services;
using PerfectChannel.WebApi.Controllers;
using Xunit;

namespace Test.PerfectChannel.WebApi.Controllers
{
    public class TaskControllerTest
    {
       private readonly Mock<ITaskService> _taskService;
       private TaskController _taskController;
        public TaskControllerTest()
        {
            _taskService = new Mock<ITaskService>();
        }

        [Fact]
        public void When_It_Calls_The_Get_Method_Should_Verify_The_Use_Of_The_TaskService() {
        
        #region Given

        _taskService.Setup(x => x.GetTasks())
            .Returns(It.IsAny<TasksResponseDTO>())
            .Verifiable();
        
        #endregion
        
        #region When
        
        _taskController = new TaskController(_taskService.Object);

        var result = _taskController.Get();
            
        #endregion

        #region Then

        _taskService.Verify(x=>x.GetTasks(), Times.Once);

        #endregion
        }
    }
}