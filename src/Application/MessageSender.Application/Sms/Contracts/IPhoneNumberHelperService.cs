namespace MessageSender.Application.Sms.Contracts;

public interface IPhoneNumberHelperService
{
    public string FormatPhoneNumber(short dialCode, string number);
}