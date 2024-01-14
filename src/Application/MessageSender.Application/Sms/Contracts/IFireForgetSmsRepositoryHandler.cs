namespace MessageSender.Application.Sms.Contracts;

public interface IFireForgetSmsRepositoryHandler
{
    void Execute(long smsId,  string content, CancellationToken cancellationToken = default);
}