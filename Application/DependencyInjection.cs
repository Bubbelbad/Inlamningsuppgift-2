using Microsoft.Extensions.DependencyInjection;
using Application.Queries.UserQueries.Helpers;
using Application.Interfaces.ServiceInterfaces;
using Application.Services.PasswordEncryption;
using Application.Mappings;
using MediatR;
using FluentValidation.AspNetCore;
using Application.Commands.AuthorCommands.AddAuthor;
using FluentValidation;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
            services.AddAutoMapper(assembly); // Specify the assembly to resolve ambiguity

            // Register services
            services.AddScoped<TokenHelper>();
            services.AddScoped<IPasswordEncryptionService, PasswordEncryptionService>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // Mapping profiles
            services.AddAutoMapper(typeof(UserMappingProfiles).Assembly);
            services.AddAutoMapper(typeof(BookMappingProfiles).Assembly);
            services.AddAutoMapper(typeof(BookCopyMappingProfiles).Assembly);

            // Register validators
            services.AddValidatorsFromAssemblyContaining<AddAuthorCommandValidator>();
            services.AddFluentValidationAutoValidation();

            return services;
        }
    }
}
