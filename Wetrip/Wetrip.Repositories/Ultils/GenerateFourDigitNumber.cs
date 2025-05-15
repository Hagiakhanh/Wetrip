namespace Wetrip.Services.Ultils;

public class GenerateFourDigitNumber
{
    public static string GenerateNumber()
    {
        Random random = new Random();
        int number = random.Next(1000, 9999);
        return number.ToString();
    }
}