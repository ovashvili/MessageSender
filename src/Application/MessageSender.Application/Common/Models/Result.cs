using MessageSender.Application.Common.Enums;

namespace MessageSender.Application.Common.Models;

public class Result<TData>
{
    public Result(StatusCodes statusCode, string? message = null, TData? data = default)
    {
        StatusCode = statusCode;
        Message = message;
        Data = data;
    }

    public StatusCodes StatusCode { get; set; }
    public string? Message { get; set; }
    public TData? Data { get; set; }
}