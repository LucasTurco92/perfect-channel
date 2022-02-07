namespace PerfectChannel.Domain.DTO
{
    public class PendingDTO : IStateDTO
    {
        public string GetTaskType()
        {
            return "Pending";
        }

        public IStateDTO Handle()
        {
            return new PendingDTO();
        }
    }
}