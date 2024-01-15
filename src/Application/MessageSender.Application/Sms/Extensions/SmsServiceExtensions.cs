using MessageSender.Application.Sms.Contracts;
using MessageSender.Application.Sms.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MessageSender.Application.Sms.Extensions;

public static class SmsServiceExtensions
{
    public static WebApplicationBuilder AddSmsServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ISmsService, SmsService>();
        builder.Services.AddScoped<ISmsIntegrationFactory, SmsIntegrationFactory>();
        builder.Services.AddSingleton<IPhoneNumberHelperService, PhoneNumberHelperService>();
        builder.Services.AddScoped<ISmsServiceRepositoryFacade, SmsServiceRepositoryFacade>();
        builder.Services.AddTransient<IFireForgetSmsRepositoryHandler, FireForgetSmsRepositoryHandler>();

        return builder;
    }
}