using System.Linq.Dynamic.Core;
using TT.Domain.Interfaces;
using TT.Models;
using TT.Services.Interfaces;

namespace TT.Services
{
    public class GameService : IGameService
    {
        public IUnitOfWork _unitOfWork;

        public GameService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Game> StartGame(string gamerName)
        {
            Game game = new Game()
            {
                GamerName = gamerName,
                StartDate = DateTime.Now,
                Name = $"{gamerName} vs DeepBlue",
            };
            _unitOfWork.Games.Add(game);
            _unitOfWork.Complete();
            return Task.FromResult(game);
        }
        public Task<Move> MakeMove(byte movement, int idCurrentGame)
        {
                            var computerMove = DeepBlue.GenerateMove();
                Move move = new Move()
                {
                    HumanMove = movement,
                    ComputerMove = computerMove,
                    ExecutionDate = DateTime.Now,
                    Winner = DeepBlue.CalculateWinner(movement, computerMove),
                    GameId = idCurrentGame
                };
                _unitOfWork.Moves.Add(move);
            _unitOfWork.Complete();
            return Task.FromResult(move);
           
        }

        

        public Task<IEnumerable<Statistics>?> EndGame()
        {
            IEnumerable<Statistics>? statisticsResult = new List<Statistics>();
            Game? lastGame = GetCurrentGame();
            if (lastGame != null)
            {
                lastGame.EndDate = DateTime.Now;
                lastGame.ComputerWins = (from mv in lastGame.Moves
                                         where mv.Winner == true
                                         select mv).Count();
                lastGame.HumanWins = (from mv in lastGame.Moves
                                      where mv.Winner == false
                                      select mv).Count();
                _unitOfWork.Games.Update(lastGame);
                _unitOfWork.Complete();
                statisticsResult = GetStatistics(lastGame.GamerName).Result;
            }
            return Task.FromResult(statisticsResult);
        }

        public Game? GetCurrentGame()
        {
            var games = _unitOfWork.Games.GetAll();
            Game? lastGame = games.Result.LastOrDefault();
            return lastGame;
        }

        public PagedList<Statistics> HistoricResults(GameParameters gameParameters)
        {
            //var games = await _unitOfWork.Games.GetAll();
           IQueryable<Statistics>? allStatistics = GetStatistics(gameParameters.GamerName).Result;
            if (gameParameters.GameId!=null && gameParameters.GameId!=0)
            {
                allStatistics = (from st in allStatistics where st.GameId == gameParameters.GameId select st);
            }
            //GameInfo? gameInfo = (from g in games
            //                where g.GamerName == gameParameters.GamerName
            //                select
            //                new GameInfo()
            //                {
            //                    Name = g.Name,
            //                    GamerName = g.GamerName,
            //                    StartDate = g.StartDate,
            //                    EndDate = g.EndDate,
            //                    HumanWins = g.HumanWins,
            //                    ComputerWins = g.ComputerWins,
            //                    GameWinner = (g.HumanWins > g.ComputerWins) ? g.GamerName : (g.ComputerWins > g.HumanWins) ? "DeepBlue" : "A tie"
            //                }).FirstOrDefault();

            
            var pagedData= PagedList<Statistics>.ToPagedList(allStatistics, gameParameters.PageNumber, gameParameters.PageSize);
            
            return pagedData;
        }

        
        public async Task<IQueryable<Statistics>?> GetStatistics(string? gamerName)
        {
            var games = await _unitOfWork.Games.GetAll();
            var movements = await _unitOfWork.Moves.GetAll();

            var statistics = (from g in games
                          join m in movements on g.Id equals m.GameId
                          where g.GamerName == gamerName
                          select new Statistics
                          {
                            GameId= m.GameId,
                            ExecutionDate = m.ExecutionDate, 
                            ComputerMove = Enum.GetName(typeof(Enumerations.EnumPlays), m.ComputerMove),
                            HumanMove= Enum.GetName(typeof(Enumerations.EnumPlays), m.HumanMove),
                            Winner = (m.Winner==true) ? "DeepBlue": g.GamerName 
                          }).AsQueryable<Statistics>();
            
            return statistics;
        }


        


    }
}
