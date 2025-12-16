using FluentValidation;
using FluentValidation.AspNetCore;
using Gerenciador.Credito.Application.Commands.IntegrarCredito;
using Gerenciador.Credito.Domain.Interfaces;
using Gerenciador.Credito.Infrastructure.Context;
using Gerenciador.Credito.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador.Credito.Api.Extensions
{
    public static class ApiBuilderExtensions
    {
        public static void AddDatabaseConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<CreditoDbContext>(options =>
            {
                options.UseNpgsql(
                    builder.Configuration.GetConnectionString("Postgres"),
                    npgsql =>
                    {
                        npgsql.MigrationsAssembly("Credit.Infrastructure");
                        npgsql.EnableRetryOnFailure();
                    });
            });
        }

        public static void AddMediatRConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(IntegrarCreditoCommand).Assembly);
            });
        }

        public static void AddFluentValidationConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssembly(typeof(IntegrarCreditoCommandValidator).Assembly);
        }

        public static void AddRepositoriesConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICreditoRepository, CreditoRepository>();
        }

        public static void AddHealthChecksConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddHealthChecks().AddDbContextCheck<CreditoDbContext>();
        }
    }
}
