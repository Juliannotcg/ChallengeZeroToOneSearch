﻿using AutoMapper;
using Challenge.Domain.Interfaces;
using Challenge.Domain.Commands.CategoryCommands;
using Challenge.Domain.Commands.ProductCommands;
using Challenge.Domain.Core.Notifications;
using Challenge.Infra.Data.Repository;

using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Challenge.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterProductCommand>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProductCommand>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveProductCommand>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<RegisterCategoryCommand>, CategoryCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCategoryCommand>, CategoryCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCategoryCommand>, CategoryCommandHandler>();

            // Domain - Eventos
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
          
            // Infra - Data
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrganizadorRepository, OrganizadorRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<EventosContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

        }
    }
}