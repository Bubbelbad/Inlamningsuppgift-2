using Application;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                    name: "LocalHostReactApp",
                    policyBuilder =>
                    {
                        policyBuilder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
                    });
            });

            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            byte[] secretKey = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]!);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey)
                };
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                {
                    policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireAuthenticatedUser();
                });
            });

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Victor Ivarson", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Authorize with your bearer token that generates when you login",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

                c.EnableAnnotations();
            });

            builder.Services.AddControllers(options =>
            {
                options.CacheProfiles.Add("DefaultCache",
                    new CacheProfile()
                    {
                        Duration = 60,
                        Location = ResponseCacheLocation.Any,
                    });
            });

            builder.Services.AddMemoryCache();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddApplication(); // Adds MediatR from Application to API
            builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("DefaultConnection")!);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    c.RoutePrefix = "swagger";  // Set Swagger UI at the app's root
                });
                app.UseDeveloperExceptionPage();
                builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
            }

            app.UseCors("LocalHostReactApp");
            app.UseHttpsRedirection();

            app.UseAuthentication(); // Ensure this is added before UseAuthorization
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
