using FluentValidation.Results;
using LeadManagement.Application.Interfaces;
using LeadManagement.Application.Services;
using LeadManagement.Domain.CommandHandlers;
using LeadManagement.Domain.Commands.Lead;
using LeadManagement.Domain.Core.Bus;
using LeadManagement.Domain.Core.Events;
using LeadManagement.Domain.EventHandlers;
using LeadManagement.Domain.Events.Lead;
using LeadManagement.Domain.Interfaces;
using LeadManagement.Infra.CrossCutting.Bus;
using LeadManagement.Infra.Data.Context;
using LeadManagement.Infra.Data.EventSourcing;
using LeadManagement.Infra.Data.Repository;
using LeadManagement.Infra.Data.Repository.EventSourcing;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LeadManagement.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<ILeadAppService, LeadAppService>();

            // Domain - Events

            // Lead
            services.AddScoped<INotificationHandler<LeadRegisteredEvent>, LeadEventHandler>();
            services.AddScoped<INotificationHandler<LeadRemovedEvent>, LeadEventHandler>();
            services.AddScoped<INotificationHandler<LeadAcceptedEvent>, LeadEventHandler>();
            services.AddScoped<INotificationHandler<LeadDeclinedEvent>, LeadEventHandler>();

            // Domain - Commands

            // Lead
            services.AddScoped<IRequestHandler<RegisterNewLeadCommand, object>, LeadCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveLeadCommand, ValidationResult>, LeadCommandHandler>();
            services.AddScoped<IRequestHandler<AcceptLeadCommand, ValidationResult>, LeadCommandHandler>();
            services.AddScoped<IRequestHandler<DeclineLeadCommand, ValidationResult>, LeadCommandHandler>();

            // Infra - Data
            services.AddScoped<ILeadRepository, LeadRepository>();
            services.AddScoped<LeadManagementContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();
        }
    }
}