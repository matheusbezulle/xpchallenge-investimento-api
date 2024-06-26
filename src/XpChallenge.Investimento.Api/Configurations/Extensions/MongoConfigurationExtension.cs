﻿using MongoDB.Driver;
using XpChallenge.Investimento.Infra.Mongo.Ioc;

namespace XpChallenge.Investimento.Api.Configurations.Extensions
{
    public static class MongoConfigurationExtension
    {
        public static void AddMongo(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoSettings = configuration.GetSection(nameof(MongoConfiguration)).Get<MongoConfiguration>();

            if (mongoSettings != null && !string.IsNullOrEmpty(mongoSettings.ConnectionString))
            {
                var connectionString = string.Format(mongoSettings.ConnectionString,
                    mongoSettings.DatabaseName);

                services.AddSingleton<IMongoClient>(_ => new MongoClient(mongoSettings.ConnectionString));
                services.AddScoped(serviceProvider =>
                {
                    var mongoClient = serviceProvider.GetService<IMongoClient>();

                    if (mongoClient != null)
                        return mongoClient.GetDatabase(mongoSettings.DatabaseName);

                    throw new ArgumentException("Não foi possível obter o mongoClient no serviceProvider.");
                });
            }

            services.AddInfraMongo();
        }
    }
}
