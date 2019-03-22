using Microsoft.Extensions.DependencyInjection;
using BlackJack.DAL.Interfaces;
using BlackJack.DAL.Repository;
using BlackJack.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.BL.Configuration
{
    public static class DALConfigService
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BlackJackContext>(c => c.UseSqlServer(connectionString));
            services.AddTransient<IPlayerRepository>(provider =>
            {
                var context = provider.GetService<BlackJackContext>();
                return new PlayerRepository(context);
            });
            //services.AddTransient<IPlayerRepository, PlayerRepository>();
            //...
            return services;
        }
    }
}
