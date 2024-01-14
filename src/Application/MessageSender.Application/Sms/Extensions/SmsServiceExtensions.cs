using MessageSender.Application.Sms.Contracts;
using MessageSender.Application.Sms.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MessageSender.Application.Sms.Services;

namespace MessageSender.Application.Sms.Extensions;

public static class SmsServiceExtensions
{
    public static WebApplicationBuilder AddSmsServices(this WebApplicationBuilder builder)
    {
        // builder.Services.AddTransient<IFireForgetSmsRepositoryHandler, FireForgetSmsRepositoryHandler>();
        builder.Services.AddScoped<ISmsService, SmsService>();
        // builder.Services.AddSingleton<IPhoneNumberHelperService, PhoneNumberHelperService>();
        builder.Services.AddScoped<ISmsIntegrationFactory, SmsIntegrationFactory>();
        builder.Services.AddScoped<ISmsServiceRepositoryFacade, SmsServiceRepositoryFacade>();
        
        return builder;
    }
}