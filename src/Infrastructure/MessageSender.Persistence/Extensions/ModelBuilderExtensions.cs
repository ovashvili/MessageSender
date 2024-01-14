using MessageSender.Domain.Enums;

namespace MessageSender.Persistence.Extensions;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().HasData(
            new Client
            {
                ClientId = Guid.NewGuid(),
                Secret = Guid.NewGuid(),
                Config = "{\"SmsFrom\": \"OTP\", \"field2\": \"value2\"}",
                IsActive = true
            },
            new Client
            {
                ClientId = Guid.NewGuid(),
                Secret = Guid.NewGuid(),
                Config = "{\"field1\": \"value1\", \"field2\": \"value2\"}",
                IsActive = false
            }
        );
        
        modelBuilder.Entity<GreyList>().HasData(
            new GreyList
            {
                ContactIdentifier = "555444333",
                Status = ContactStatus.Black,
                StatusNote = "Blocked",
                IsActive = true
            }
        );
        
        modelBuilder.Entity<Provider>().HasData(
            new Provider
            {
                ProviderId = 1,
                Name = "Magti",
                Priority = 1,
                Config = "{\"provider-specific-field\": \"value1\"}",
                IsGlobal = false,
                IsActive = true
            },
            new Provider
            {
                ProviderId = 2,
                Name = "Silknet",
                Priority = 2,
                Config = "{\"provider-specific-field\": \"value2\"}",
                IsGlobal = false,
                IsActive = true
            },
            new Provider
            {
                ProviderId = 3,
                Name = "Peleka",
                Priority = 3,
                Config = "{\"provider-specific-field\": \"value3\"}",
                IsGlobal = false,
                IsActive = true
            },
            new Provider
            {
                ProviderId = 4,
                Name = "Nexmo",
                Priority = 1,
                Config = "{\"provider-specific-field\": \"value4\"}",
                IsGlobal = true,
                IsActive = true
            }
        );
        
        modelBuilder.Entity<Country>().HasData(
            new Country
            {
                Alpha2Code = "GE",
                DialCode = 995,
                IsActive = true
            },              
            new Country
            {
                Alpha2Code = "AM",
                DialCode = 374,
                IsActive = true
            },
            new Country
            {
                Alpha2Code = "US",
                DialCode = 1,
                IsActive = true
            }
        );
        
        modelBuilder.Entity<CountryProvider>().HasData(
            new CountryProvider
            {
                CountryProviderId = 1,
                ProviderId = 1,
                Alpha2Code = "GE",
                Priority = 1,
                IsActive = true
            },
            new CountryProvider
            {
                CountryProviderId = 2,
                ProviderId = 2,
                Alpha2Code = "GE",
                Priority = 2,
                IsActive = true
            },
            new CountryProvider
            {
                CountryProviderId = 3,
                ProviderId = 3,
                Alpha2Code = "AM",
                Priority = 1,
                IsActive = true
            },
            new CountryProvider
            {
                CountryProviderId = 4,
                ProviderId = 4,
                Alpha2Code = "US",
                Priority = 1,
                IsActive = true
            }
        );
    }
}