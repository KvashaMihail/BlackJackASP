using BlackJack.DAL.Configuration;
using BlackJack.BL.Services.Helpers;
using BlackJack.BL.Services.Api;
using BlackJack.BL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace BlackJack.BL.Configuration
{
    public static class BLConfig
    {
        public static IServiceCollection AddServicesFromBL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDapper(configuration);
            //services.AddEF(configuration);
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<ICardService, CardService>();
            services.AddTransient<IRoundService, RoundService>();
            services.AddTransient<IGameApiService, GameApiService>();
            services.AddTransient<IGameMenuService, GameMenuService>();
            return services;
        }
    }
}