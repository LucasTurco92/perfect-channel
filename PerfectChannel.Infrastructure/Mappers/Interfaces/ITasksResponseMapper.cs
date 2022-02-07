using System.Collections.Generic;
using PerfectChannel.Domain.DTO;
using PerfectChannel.Infrastructure.Entities;

namespace PerfectChannel.Infrastructure.Services.Mappers.Interfaces
{
    public interface ITasksResponseMapper
    {
        TaskResponseDTO Map(List<TaskDTO> Tasks);
        List<Task> Map(TaskResponseDTO TaskResponse);  
    }
}