using MessageSender.Application.Sms.Contracts;
using MessageSender.Domain.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MessageSender.Application.Sms.Services;

public class FireForgetSmsRepositoryHandler : IFireForgetSmsRepositoryHandler
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<FireForgetSmsRepositoryHandler> _logger;

    public FireForgetSmsRepositoryHandler(IServiceScopeFactory serviceScopeFactory, ILogger<FireForgetSmsRepositoryHandler> logger)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _logger = logger;
    }

    public void Execute(long smsId, string content, CancellationToken cancellationToken = default)
    {
        Task.Run(async () =>
        {
            try
            {
                using var scope = _serviceScopeFactory.CreateScope();

                var smsRepository = scope.ServiceProvider.GetRequiredService<ISmsRepository>();

                await smsRepository.UpdateSmsContentAsync(smsId, content, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                if (_logger.IsEnabled(LogLevel.Critical))
                    _logger.LogCritical(e, "An error occurred while updating the sms table: {ErrorMessage}", e.Message);
            }
        }, cancellationToken);
    }
}