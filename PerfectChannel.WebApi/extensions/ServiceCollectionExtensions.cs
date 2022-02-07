using Microsoft.Extensions.DependencyInjection;
using PerfectChannel.Domain.DTO.Interfaces;
using PerfectChannel.Domain.Interfaces;
using PerfectChannel.Domain.Interfaces.Services;
using PerfectChannel.Domain.Services;
using PerfectChannel.Infrastructure.Repositories;
using PerfectChannel.Infrastructure.Services.Mappers;
using PerfectChannel.Infrastructure.Services.Mappers.Interfaces;

namespace PerfectChannel.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddContainer(this IServiceCollection services)
        {
            ConfigureWebModule(services);
            ConfigureInfraestructureModule(services);
            ConfigureDomainModule(services);
        }

        private static void ConfigureWebModule(IServiceCollection services)
        {
           
        }
        private static void ConfigureInfraestructureModule(IServiceCollection services)
        {
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskMapper, TaskMapper>();
            services.AddScoped<ITasksResponseMapper, TasksResponseMapper>();
            services.AddScoped<IStateFactory, StateFactory>();
        }
        public static void ConfigureDomainModule(IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskService>();
        }

    }
}