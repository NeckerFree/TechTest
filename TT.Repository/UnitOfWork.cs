using TT.DataAccess.Data;
using TT.Domain.Interfaces;

namespace TT.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GamesContext _dbContext;
        
        public IGameRepository Games { get; }

        public IMoveRepository Moves { get; }

        public UnitOfWork(GamesContext dbContext,
                            IGameRepository gamesRepository,
                            IMoveRepository movesRepository)
        {
            this._dbContext = dbContext;
            this.Games = gamesRepository;
            this.Moves = movesRepository;
        }

        
       
        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            if(disposing)
            {
                _dbContext.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
