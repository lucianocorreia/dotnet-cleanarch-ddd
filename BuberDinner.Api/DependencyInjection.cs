using System.Reflection;
using BuberDinner.Api.Common.Errors;
using BuberDinner.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
        services.AddControllers();

        services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddMappings();

        return services;
    }
}
