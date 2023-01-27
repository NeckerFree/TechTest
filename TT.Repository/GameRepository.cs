using TT.DataAccess.Data;
using TT.Domain.Interfaces;
using TT.Models;

namespace TT.Repository
{
    public class GameRepository : GenericRepository<Game>, IGameRepository
    {
        public GameRepository(GamesContext context) : base(context)
        {
        }
    }
}
