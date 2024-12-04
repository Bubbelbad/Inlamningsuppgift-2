using Microsoft.Extensions.DependencyInjection;
using Application.Queries.UserQueries.Helpers;
namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
            services.AddAutoMapper(assembly); // Specify the assembly to resolve ambiguity
            services.AddScoped<TokenHelper>();

            return services;

            // services.AddValidatorsFromAssembly(assembly);
            // services.AddSungelton(FakeDatabase)
        }
    }
}
