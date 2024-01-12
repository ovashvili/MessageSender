using MessageSender.IntegrationsCommon.Contracts;
using MessageSender.SilknetIntegration.Configurations;
using MessageSender.SilknetIntegration.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MessageSender.SilknetIntegration.Extensions;

public static class SilknetIntegrationExtensions
{
    public static WebApplicationBuilder AddSilknetIntegration(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<SilknetOptions>(builder.Configuration.GetSection(SilknetOptions.SectionName));
        builder.Services.AddScoped<ISmsIntegrationService, SilknetIntegrationService>();

        return builder;
    }
}