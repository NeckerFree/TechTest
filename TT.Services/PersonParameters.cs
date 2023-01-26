namespace TT.Services
{
    public class GameParameters : QueryStringParameters
    {
        public string? GamerName { get; set; }
        public int? GameId { get; internal set; } = 0;
    }
}
