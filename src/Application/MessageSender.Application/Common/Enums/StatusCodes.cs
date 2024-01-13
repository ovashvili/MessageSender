namespace MessageSender.Application.Common.Enums;

public enum StatusCodes : short
{
    Success = 200,
    BadRequest = 400,
    Unauthorized = 401,
    NotFound = 404,
    GenericFailedError = 500
}