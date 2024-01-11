using MediatR;
using MessageSender.Service.Common.Models;

namespace MessageSender.Application.Sms.Commands.SendSmsWithCountryCode;

public class SendSmsWithCountryCodeCommandHandler : IRequestHandler<SendSmsWithCountryCodeCommand, Result<long>>
{
    public Task<Result<long>> Handle(SendSmsWithCountryCodeCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}