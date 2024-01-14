using MessageSender.Domain.Entities;
using MessageSender.Domain.Enums;

namespace MessageSender.Application.Sms.Contracts;

public interface ISmsServiceRepositoryFacade
{
    public Task<GreyList?> GetGreyListContactAsync(string phoneNumber, CancellationToken cancellationToken = default);
    public Task<Country?> GetCountryAsync(string countryCode, CancellationToken cancellationToken = default);
    public Task<List<CountryProvider>> GetCountryProvidersOrderedByPriorityAsync(string alpha2Code, CancellationToken cancellationToken = default);
    public Task<Provider?> GetProviderAsync(string providerName, CancellationToken cancellationToken = default);
    public Task<List<Provider>> GetGlobalProvidersOrderedByPriorityAsync(CancellationToken cancellationToken = default);
    Task<long> InsertSmsAsync(Guid clientId, string phoneNumber, CancellationToken cancellationToken = default);
    Task<long> InsertMessageDeliveryAsync(long smsId, MessageDeliveryStatus status, int? providerId = null,
        string? statusNote = null, CancellationToken cancellationToken = default);
    Task UpdateMessageDeliveryRecordAsync(long messageDeliveryId, MessageDeliveryStatus status, string? statusNote,
        string? providerMessageId, CancellationToken cancellationToken = default);
    Task<MessageDeliveryStatus> GetSmsStatusAsync(long smsId, CancellationToken cancellationToken = default);
    Task<Client?> GetClientAsync(Guid clientId, CancellationToken cancellationToken = default);
}