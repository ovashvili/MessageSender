using MessageSender.IntegrationsCommon.Contracts;
using Microsoft.AspNetCore.Builder;
using MessageSender.PelekaIntegration.Configurations;
using Microsoft.Extensions.DependencyInjection;
using MessageSender.PelekaIntegration.Services;

namespace MessageSender.PelekaIntegration.Extensions;

public static class PelekaIntegrationExtensions
{
    public static WebApplicationBuilder AddPelekaIntegration(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<PelekaOptions>(builder.Configuration.GetSection(PelekaOptions.SectionName));
        builder.Services.AddScoped<ISmsIntegrationService, PelekaIntegrationService>();
        
        return builder;
    }
}