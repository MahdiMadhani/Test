using Application.Guarantees.EventHandlers;
using Application.Guarantees.Queries.Get;
using DataAccess;
using DataAccess.DataAccess;
using DayanaCore.Infrastructure.Messaging;
using Domain;
using DotNetCore.CAP;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    public static class Startup
    {
        public static IServiceCollection AddStartupConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMessagingStartupModule(configuration);

            services.AddScoped<IPubMessageHandler, PubMessageHandler>();

            services.Scan(scan => scan  
                .FromAssemblyOf<CreateGuaranteeEventHandler>()
                .AddClasses(classes => classes.AssignableTo<ICapSubscribe>())
                .AsSelf()
                .WithScopedLifetime());
            // services.AddMediatR(typeof(Startup).Assembly);
            services.AddMediatR(typeof(GuaranteeQuery).Assembly);
              services
                    .AddTransient<IReadUnitOfWork, ReadUnitOfWork>()
                    .AddTransient<IWriteUnitOfWork, WriteUnitOfWork>();
            return services;


        }

    }
}
