using MessageSender.IntegrationsCommon.Contracts;
using MessageSender.NexmoIntegration.Configurations;
using MessageSender.NexmoIntegration.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MessageSender.NexmoIntegration.Extensions;

public static class NexmoIntegrationExtensions
{
    public static WebApplicationBuilder AddNexmoIntegration(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<NexmoOptions>(builder.Configuration.GetSection(NexmoOptions.SectionName));
        builder.Services.AddScoped<ISmsIntegrationService, NexmoIntegrationService>();

        return builder;
    }
}