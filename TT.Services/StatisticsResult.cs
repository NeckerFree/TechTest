namespace TT.Services
{
    public class StatisticsResult
    {
        public GameInfo? GameInfo { get;  set; }
        public PagedList<Statistics>? Statistics { get; internal set; }
    }
}
