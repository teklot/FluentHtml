using System.ComponentModel.DataAnnotations;

namespace FluentHtml.Samples.Pages;

public class CreateUserModel
{
    [Required(ErrorMessage = "Name is required")]
    [Display(Name = "Full Name")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    [Display(Name = "Email Address")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
    [Display(Name = "Password")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please select a role")]
    [Display(Name = "Role")]
    public string Role { get; set; } = string.Empty;

    [Display(Name = "Bio")]
    public string? Bio { get; set; }

    [Display(Name = "I agree to the terms")]
    public bool Terms { get; set; }
}
