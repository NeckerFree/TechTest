namespace TT.Services
{
    public class Statistics
    {
        public DateTime ExecutionDate { get; internal set; }
        public string? ComputerMove { get; internal set; }
        public string? HumanMove { get; internal set; }
        public string? Winner { get; internal set; }
        public int GameId { get; internal set; }
    }
}
