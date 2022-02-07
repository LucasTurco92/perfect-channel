using PerfectChannel.Domain.DTO;
using PerfectChannel.Domain.DTO.Interfaces;
using PerfectChannel.Infrastructure.Entities;
using Moq;
using Xunit;
using System;

namespace PerfectChannel.Infrastructure.Services.Mappers
{
    public class TaskMapperTest
    {
        public readonly Mock<IStateFactory> _stateFactory;
        public readonly TaskMapper _taskMapper;
        public TaskMapperTest(){
            _stateFactory = new Mock<IStateFactory>();
            _taskMapper = new TaskMapper(_stateFactory.Object);
        }

        [Fact]
        public void When_It_Calls_The_Map_Method_Should_Return_A_Valid_Task_To_Store()
        {
            #region Given

            var id = Guid.NewGuid();

            var task = new Task{
                Id = id,
                Description = "Description",
                State = "Pending"
            };

            var taskDTO = new TaskDTO(task.Id,task.Description,new PendingDTO());

            #endregion

            #region When
        
            var validTaskResult = _taskMapper.Map(taskDTO);
                
            #endregion

            #region Then
        
             Assert.Equal(task.Id,validTaskResult.Id);
             Assert.Equal(task.Description,validTaskResult.Description);
             Assert.Equal(task.State,validTaskResult.State);
                
            #endregion
        }

        [Fact]
        public void When_It_Calls_The_Map_Method_Should_Return_A_Valid_Task_From_Stored()
        {
            #region Given

            var id = Guid.NewGuid();

            var task = new Task{
                Id = id,
                Description = "Description",
                State = "Pending"
            };

            var taskDTO = new TaskDTO(task.Id,task.Description,new PendingDTO());

            _stateFactory.Setup(x=> x.CreateState(task.State))
            .Returns(new PendingDTO());

            #endregion

            #region When
        
            var validTaskResult = _taskMapper.Map(task);
                
            #endregion

            #region Then
        
             Assert.Equal(taskDTO.Id,validTaskResult.Id);
             Assert.Equal(taskDTO.Description,validTaskResult.Description);
             Assert.Equal(taskDTO.StateDescription,validTaskResult.StateDescription);
                
            #endregion

        }
    }

}