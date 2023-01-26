using TT.DataAccess;
using TT.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TT.DataAccess.Data;

namespace TT.Repository
{
    public static class DependencyInjection 
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<GamesContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<IMoveRepository, MoveRepository>();

            return services;
        }
    }
    
}
