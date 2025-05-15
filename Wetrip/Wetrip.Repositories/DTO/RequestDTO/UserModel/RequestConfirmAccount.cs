namespace Wetrip.Services.DTO.RequestDTO.UserModel;

public class RequestConfirmAccount
{
    public string RequestId { get; set; } = string.Empty;
    public string OtpCode { get; set; } = string.Empty;
}