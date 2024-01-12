using MessageSender.Domain.Contracts;
using MessageSender.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MessageSender.Persistence.Extensions;

public static class RepositoryServiceExtensions
{
    public static WebApplicationBuilder AddRepositoryServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IClientRepository, ClientRepository>();
        builder.Services.AddScoped<ICountryRepository, CountryRepository>();
        builder.Services.AddScoped<IGreyListRepository, GreyListRepository>();
        builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
        builder.Services.AddScoped<ISmsRepository, SmsRepository>();
        builder.Services.AddScoped<IMessageDeliveryRepository, MessageDeliveryRepository>();
        return builder;
    }
}