using Microsoft.Extensions.Options;
using Vonage;
using Vonage.Request;
using Wetrip.Service.IServices;
using Wetrip.Services.Helpers;

namespace Wetrip.Service.Services;

public class SmsService : ISmsService
{
    private readonly SmsSettings _smsSettings;
    private readonly SpeedSMSApiSettings _speedSmsApiSettings;

    public SmsService(IOptions<SmsSettings> smsSettings, IOptions<SpeedSMSApiSettings> speedSmsApiSettings)
    {
        _smsSettings = smsSettings.Value;
        _speedSmsApiSettings = speedSmsApiSettings.Value;
    }
    
    public async Task SendSms(string otpCode, string phoneNumber)
    {
        var credentials = Credentials.FromApiKeyAndSecret(
            _smsSettings.APIkey,
            _smsSettings.APISecret
        );

        var vonageClient = new VonageClient(credentials);

        var response = await vonageClient.SmsClient.SendAnSmsAsync(new Vonage.Messaging.SendSmsRequest()
        {
            To = phoneNumber,
            From = "WeTrip application",
            Text = $"Your OTP code is: {otpCode}. Please do not share this code with anyone.",
        });
    }

    public string SpeedSMSApi(string otpCode, string phoneNumber)
    {
        SpeedSMSAPI api  = new SpeedSMSAPI(_speedSmsApiSettings.APIKey);
        String[] phones = new String[] { phoneNumber };
        String content = otpCode;
        int type = 1;
        String sender = "";
        string response = api.sendSMS(phones, content, type, sender);
        return response;
    }
}