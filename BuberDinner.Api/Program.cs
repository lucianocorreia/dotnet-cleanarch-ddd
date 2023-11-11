
using BuberDinner.Api;
using BuberDinner.Api.Common.Errors;
using BuberDinner.Api.Filters;
using BuberDinner.Api.Middleware;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder);

var app = builder.Build();

ConfigureApp(app);

app.Run();

static void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

static void ConfigureApp(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //app.UseMiddleware<ErrorHandlingMiddleware>();

    app.UseExceptionHandler("/error");
    // app.Map("/error", (HttpContext httpContext) =>
    // {
    //     Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
    //     return Results.Problem(detail: exception?.Message);
    // });

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
}
