using BlackJack.BL.Services;
using BlackJack.BL.Services.Api;
using BlackJack.BL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJack.BL.Configuration
{
    public static class BLConfig
    {
        public static IServiceCollection AddServicesBL(this IServiceCollection services)
        {
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<ICardService, CardService>();
            services.AddTransient<IRoundService, RoundService>();
            services.AddTransient<IGameApiService, GameApiService>();
            //...
            return services;
        }
    }
}