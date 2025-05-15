using System.ComponentModel.DataAnnotations;
using Wetrip.Services.Enum;

namespace Wetrip.Services.DTO.RequestDTO.UserModel;

public class RequestRegisterAccount
{
    [RegularExpression(@"^0\d{9}$", ErrorMessage = "Phone must be 10 digits and start with 0.")]
    public string? Phone { get; set; } = string.Empty;
    
    [EmailAddress(ErrorMessage = "Must be a valid email address")]
    public string? EmailAddress { get; set; } = string.Empty;  
    
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
    
    [Required(ErrorMessage = "Gender is required")]
    public GenderEnum Gender { get; set; }

    [Required(ErrorMessage = "Birthday is required")]
    public DateOnly? Birthday { get; set; }
    
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; }
}