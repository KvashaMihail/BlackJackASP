﻿using BlackJack.DAL.EF;
using BlackJack.DAL.Interfaces;
using BlackJack.DAL.Repository.EntityFramework;
using BlackJack.DAL.Repository.Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using System.Data.SqlClient;

namespace BlackJack.DAL.Configuration
{
    public static class DALConfig
    {
        public static IServiceCollection AddEF(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<DbConnection>(provider => new SqlConnection(connectionString));
            services.AddDbContext<BlackJackContext>(c => c.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddTransient<IPlayerRepository, Repository.EntityFramework.PlayerRepository>();
            services.AddTransient<IGameRepository, Repository.EntityFramework.GameRepository>();
            services.AddTransient<IRoundRepository, Repository.EntityFramework.RoundRepository>();
            services.AddTransient<IRoundPlayerRepository, Repository.EntityFramework.RoundPlayerRepository>();
            services.AddTransient<IRoundPlayerCardRepository, Repository.EntityFramework.RoundPlayerCardRepository>();
            services.AddTransient<ICardRepository, Repository.EntityFramework.CardRepository>();

            return services;
        }

        public static IServiceCollection AddDapper(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<DbConnection>(provider => new SqlConnection(connectionString));

            services.AddTransient<IPlayerRepository, Repository.Dapper.PlayerRepository>();
            services.AddTransient<IGameRepository, Repository.Dapper.GameRepository>();
            services.AddTransient<IRoundRepository, Repository.Dapper.RoundRepository>();
            services.AddTransient<IRoundPlayerRepository, Repository.Dapper.RoundPlayerRepository>();
            services.AddTransient<IRoundPlayerCardRepository, Repository.Dapper.RoundPlayerCardRepository>();
            services.AddTransient<ICardRepository, Repository.Dapper.CardRepository>();

            return services;
        }
    }
}
