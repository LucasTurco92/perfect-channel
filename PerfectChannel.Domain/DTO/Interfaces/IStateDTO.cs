namespace PerfectChannel.Domain.DTO
{
    public interface IStateDTO
    {
        IStateDTO Handle();
        string GetTaskType();
    }
}