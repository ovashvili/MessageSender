using MediatR;
using MessageSender.Domain.Enums;
using MessageSender.Service.Common.Models;

namespace MessageSender.Application.Sms.Queries.GetSmsStatus;

public class GetSmsStatusQuery : IRequest<Result<MessageDeliveryStatus>>
{
    public long Id { get; set; }
}