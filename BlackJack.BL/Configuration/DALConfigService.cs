using BlackJack.DAL.EF;
using BlackJack.DAL.Interfaces;
using BlackJack.DAL.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using System.Data.SqlClient;

namespace BlackJack.BL.Configuration
{
    public static class DALConfigService
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<DbConnection>(provider => new SqlConnection(connectionString));
            services.AddDbContext<BlackJackContext>();

            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<IGameRepository, GameRepository>();
            //...
            return services;
        }
    }
}
