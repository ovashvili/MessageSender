using MediatR;
using MessageSender.Domain.Enums;
using MessageSender.Service.Common.Models;

namespace MessageSender.Application.Sms.Queries.GetSmsStatus;

public class GetSmsStatusQueryHandler : IRequestHandler<GetSmsStatusQuery, Result<MessageDeliveryStatus>>
{
    public Task<Result<MessageDeliveryStatus>> Handle(GetSmsStatusQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}