using BlackJack.DAL.Configuration;
using BlackJack.BL.Services;
using BlackJack.BL.Services.Api;
using BlackJack.BL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJack.BL.Configuration
{
    public static class BLConfig
    {
        public static IServiceCollection AddServicesFromBL(this IServiceCollection services, string connectionString)
        {
            services.AddDapper(connectionString);
            //services.AddEF(connectionString);
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<ICardService, CardService>();
            services.AddTransient<IRoundService, RoundService>();
            services.AddTransient<IGameApiService, GameApiService>();
            services.AddTransient<IGameMenuService, GameMenuService>();
            //...
            return services;
        }
    }
}