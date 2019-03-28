using BlackJack.BL.Services;
using BlackJack.BL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJack.BL.Configuration
{
    public static class BLConfigService
    {
        public static IServiceCollection AddServicesBL(this IServiceCollection services)
        {
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<ICardService, CardService>();
            services.AddTransient<IRoundService, RoundService>();
            //...
            return services;
        }
    }
}