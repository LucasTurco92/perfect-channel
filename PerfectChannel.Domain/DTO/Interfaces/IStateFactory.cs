namespace PerfectChannel.Domain.DTO.Interfaces
{
    public interface IStateFactory
    {
        IStateDTO CreateState(string state);
    }
}