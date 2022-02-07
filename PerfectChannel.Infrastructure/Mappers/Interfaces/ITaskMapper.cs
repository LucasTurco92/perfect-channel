using PerfectChannel.Domain.DTO;
using PerfectChannel.Infrastructure.Entities;

namespace PerfectChannel.Infrastructure.Services.Mappers.Interfaces
{
    public interface ITaskMapper
    {
        TaskDTO Map(Task Task);
        Task Map(TaskDTO Task);  
    }
}