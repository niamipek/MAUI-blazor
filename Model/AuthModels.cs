using System.ComponentModel.DataAnnotations;

namespace MonkeyFinderHybrid.Model;

public sealed class LoginInputModel
{
    [Required(ErrorMessage = "Email là b?t bu?c")]
    [EmailAddress(ErrorMessage = "Email không h?p l?")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "M?t kh?u là b?t bu?c")]
    [MinLength(8, ErrorMessage = "M?t kh?u ph?i có ít nh?t 8 ký t?")]
    public string Password { get; set; } = string.Empty;

    public bool RememberMe { get; set; }
}

public sealed class RegisterInputModel
{
    [Required(ErrorMessage = "H? và tên là b?t bu?c")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email là b?t bu?c")]
    [EmailAddress(ErrorMessage = "Email không h?p l?")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "M?t kh?u là b?t bu?c")]
    [MinLength(8, ErrorMessage = "M?t kh?u ph?i có ít nh?t 8 ký t?")]
    public string Password { get; set; } = string.Empty;
}

public sealed record AuthResult(bool IsSuccess, string Message);
