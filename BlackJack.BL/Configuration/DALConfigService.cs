using Microsoft.Extensions.DependencyInjection;
using BlackJack.DAL.Interfaces;
using BlackJack.DAL.Repository;
using BlackJack.DAL.EF;
using Microsoft.EntityFrameworkCore;
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
            //...
            return services;
        }
    }
}
