using System.Collections.Generic;
using PerfectChannel.Domain.DTO;
using PerfectChannel.Domain.Interfaces;
using Xunit;

namespace PerfectChannel.Infrastructure.Repositories
{
    public class TaskRepositoryTest
    {
        private ITaskRepository _taskRepository;
        public TaskRepositoryTest(){
            _taskRepository = new TaskRepository();
        }
        
        [Fact]
        public void When_It_Calls_The_GetTasks_Method_Should_Return_A_Valid_TaskResponseDTO() {
        
        #region Given

        var taskResponse = new TasksResponseDTO{
            Tasks = new List<TaskDTO>()
        };

        #endregion
        
        #region When
        
        var validTaskResponseDTO = _taskRepository.GetTasks();
            
        #endregion

        #region Then

        Assert.NotNull(validTaskResponseDTO);
        
        #endregion
        }
    }
}