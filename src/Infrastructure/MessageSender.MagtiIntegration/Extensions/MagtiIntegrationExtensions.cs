using MessageSender.IntegrationsCommon.Contracts;
using MessageSender.MagtiIntegration.Configurations;
using MessageSender.MagtiIntegration.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MessageSender.MagtiIntegration.Extensions;

public static class MagtiIntegrationExtensions
{
    public static WebApplicationBuilder AddMagtiIntegration(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<MagtiOptions>(builder.Configuration.GetSection(MagtiOptions.SectionName));
        builder.Services.AddScoped<ISmsIntegrationService, MagtiIntegrationService>();

        return builder;
    }
}