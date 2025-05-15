namespace Wetrip.Service.IServices;

public interface ISmsService
{
    public Task SendSms(string otpCode, string phoneNumber);
    public string SpeedSMSApi(string otpCode, string phoneNumber);
}