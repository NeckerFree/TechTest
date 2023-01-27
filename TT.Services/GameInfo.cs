namespace TT.Services
{
    public class GameInfo
    {
        public string? Name { get; internal set; }
        public string? GamerName { get; internal set; }
        public DateTime StartDate { get; internal set; }
        public DateTime? EndDate { get; internal set; }
        public int? HumanWins { get; internal set; }
        public int? ComputerWins { get; internal set; }
        public string? GameWinner { get; internal set; }
    }
}