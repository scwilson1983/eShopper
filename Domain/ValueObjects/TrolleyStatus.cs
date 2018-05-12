namespace Domain.ValueObjects
{
    public class TrolleyStatus
    {
        public static TrolleyStatus Open => new TrolleyStatus(nameof(Open));
        public static TrolleyStatus Purchased => new TrolleyStatus(nameof(Purchased));
        public static TrolleyStatus Abandoned => new TrolleyStatus(nameof(Abandoned));

        public string Status { get; }

        public TrolleyStatus(string status)
        {
            Status = status;
        }
    }
}
