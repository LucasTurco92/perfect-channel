using Moq;
using System.Collections.Generic;
using PerfectChannel.Domain.DTO;
using PerfectChannel.Domain.Interfaces;
using Xunit;
using PerfectChannel.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using PerfectChannel.Infrastructure.Services.Mappers.Interfaces;
using PerfectChannel.Infrastructure.Entities;
using Task = PerfectChannel.Infrastructure.Entities.Task;
using System;
using System.Linq;

namespace PerfectChannel.Infrastructure.Repositories
{
    public class TaskRepositoryTest
    {
        private readonly DbContextOptionsBuilder<ApiContext> _options;  
        private readonly Mock<ITaskMapper> _taskMapper;    
        private readonly Mock<ITasksResponseMapper> _tasksResponseMapper;    
        private readonly ApiContext _apiContext;    
        private ITaskRepository _taskRepository;
        public TaskRepositoryTest(){
            var options = new DbContextOptionsBuilder<ApiContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;
            _apiContext = new ApiContext(options);
            _taskMapper = new Mock<ITaskMapper>();
            _tasksResponseMapper = new Mock<ITasksResponseMapper>();
            _taskRepository = new TaskRepository(_apiContext, _taskMapper.Object, _tasksResponseMapper.Object);
        }
        
        [Fact]
        public void When_It_Calls_The_GetTasks_Method_Should_Return_A_Valid_TaskResponseDTO() {
        
        #region Given

        var guid = Guid.NewGuid();
        var task = new TaskDTO(guid, "description", new PendingDTO());
        var taskEntity = new Task{
            Id = guid,
            Description = "description",
            State = "Pending"
        };

        var taskResponse = new TaskResponseDTO{
            Tasks = new List<TaskDTO>{
                new TaskDTO(guid, "description", new PendingDTO())
            }
        };
        _apiContext.Task.Add(taskEntity);
        _apiContext.SaveChanges();

        _taskMapper.Setup(x => x.Map(It.IsAny<Task>()))
            .Returns(task)
            .Verifiable();

        _tasksResponseMapper.Setup(x => x.Map(It.IsAny<List<TaskDTO>>()))
            .Returns(taskResponse)
            .Verifiable();

        #endregion
        
        #region When
        
        var validTaskResponseDTO = _taskRepository.GetTasks();
            
        #endregion

        #region Then

        Assert.NotNull(validTaskResponseDTO);
        Assert.Equal(1,validTaskResponseDTO.Tasks.Count);
        _taskMapper.Verify(x=>x.Map(It.IsAny<Task>()), Times.Once);
        _tasksResponseMapper.Verify(x=>x.Map(It.IsAny<List<TaskDTO>>()), Times.Once);

        
        #endregion
        }

        [Fact]
        public void When_It_Calls_The_AddNewTask_Method_Should_Save_It_Properly() {
        #region Given

        var guid = Guid.NewGuid();
        var task = new TaskDTO(guid, "description", new PendingDTO());
        var taskEntity = new Task{
            Id = guid,
            Description = "description",
            State = "Pending"
        };

        _apiContext.Task.Add(taskEntity);
        _apiContext.SaveChanges();

        _taskMapper.Setup(x => x.Map(task))
            .Returns(taskEntity)
            .Verifiable();

        var savedItem = _apiContext.Task.Select(x=> x);

        #endregion
        
        #region When
        
        _taskRepository.AddNewTask(task);    

        #endregion

        #region Then

        Assert.Equal(taskEntity.Id,savedItem.FirstOrDefault().Id);
        _taskMapper.Verify(x=>x.Map(task), Times.Once);
       
        #endregion
        }
    }
}