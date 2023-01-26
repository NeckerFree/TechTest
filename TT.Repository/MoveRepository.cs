using TT.DataAccess.Data;
using TT.Domain.Interfaces;
using TT.Models;

namespace TT.Repository
{
    public class MoveRepository : GenericRepository<Move>, IMoveRepository
    {
        public MoveRepository(GamesContext context) : base(context)
        {
        }
    }
    
}
