using MessageSender.Application.Sms.Contracts;

namespace MessageSender.Application.Sms.Services;

public class PhoneNumberHelperService : IPhoneNumberHelperService
{
    public string FormatPhoneNumber(short dialCode, string number)
    {
       return $"+{dialCode}{number}";
    }
}