using MessageSender.Application.Common.Enums;

namespace MessageSender.Application.Common.Models;

public class Result<TData>(StatusCodes statusCode, string? message = null, TData? data = default)
{
    public StatusCodes StatusCode { get; set; } = statusCode;
    public string? Message { get; set; } = message;
    public TData? Data { get; set; } = data;
}