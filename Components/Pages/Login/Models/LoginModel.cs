using System.ComponentModel.DataAnnotations;

namespace BlazorAuthDemo.Components.Pages.Login.Models;

public class LoginModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter User Name")]
    public string? Username { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Password")]
    public string? Password { get; set; }
}
