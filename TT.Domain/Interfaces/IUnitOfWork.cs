using TT.Models;

namespace TT.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGameRepository Games { get; }
        
        IMoveRepository Moves { get; }

        int Complete();
    }
}

