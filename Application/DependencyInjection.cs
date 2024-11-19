using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Infrastructure.Database;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

            // services.AddValidatorsFromAssembly(assembly);

            return services;

           // services.AddSungelton(FakeDatabase)
        }
        
    }
}
