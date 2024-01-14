using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.AspNetCore;
using MessageSender.Api.Extensions;
using MessageSender.Api.Filters;
using MessageSender.Application.Sms.Extensions;
using MessageSender.Application.Sms.Models;
using MessageSender.MagtiIntegration.Extensions;
using MessageSender.PelekaIntegration.Extensions;
using MessageSender.Persistence.Context;
using MessageSender.Persistence.Extensions;
using MessageSender.SilknetIntegration.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services
        .AddControllers(options => options.Filters.Add<ApiKeyAuthFilter>())
        .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter()));

    builder.Logging.ClearProviders();

    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    
    builder.Host.UseNLog();
    
    builder.Services.AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
    });

    builder.Services.AddVersionedApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VV";
        options.SubstituteApiVersionInUrl = true;
    });

    builder.Services.AddDbContext<AppDbContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), c => 
                    c.MigrationsAssembly(nameof(MessageSender.Persistence))));

    builder.Services.AddFluentValidationAutoValidation();
    builder.Services.AddValidatorsFromAssemblyContaining<SendSmsRequestValidator>();
    builder.Services.AddHttpClient();
    builder.AddSmsServices();
    builder.AddRepositoryServices();
    builder.AddMagtiIntegration();
    builder.AddSilknetIntegration();
    builder.AddPelekaIntegration();
    builder.AddSwaggerWithApiKeySecurity();

    var app = builder.Build();
    var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

    app.UseRouting();

    app.MapControllers();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            }
        });
    }

    app.Run();

}
catch (Exception ex)
{
    logger.Fatal(ex, "Application failed");
    throw;
}
finally
{
    LogManager.Shutdown();
}