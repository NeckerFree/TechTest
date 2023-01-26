using TT.Models;

namespace TT.Services.Interfaces
{
    public  interface IGameService
    {
        Task<Game> StartGame(string gamerName);
        Task<Move> MakeMove(byte movement, int idGame);
        Task<IEnumerable<Statistics>?> EndGame();
        PagedList<Statistics> HistoricResults(GameParameters gameParameters);
        Game? GetCurrentGame();
    }
    
}
