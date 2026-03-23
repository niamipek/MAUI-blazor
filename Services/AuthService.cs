using Microsoft.Extensions.Logging;

namespace MonkeyFinderHybrid.Services;

public sealed class AuthService(ILogger<AuthService> logger) : IAuthService
{
    public async Task<AuthResult> LoginAsync(LoginInputModel model, CancellationToken cancellationToken = default)
    {
        try
        {
            await Task.Delay(350, cancellationToken);

            if (string.Equals(model.Email, "admin@example.com", StringComparison.OrdinalIgnoreCase) &&
                model.Password == "12345678")
            {
                return new AuthResult(true, "??ng nh?p thành công.");
            }

            return new AuthResult(false, "Email ho?c m?t kh?u ch?a ?úng.");
        }
        catch (OperationCanceledException)
        {
            logger.LogWarning("Login request was canceled for {Email}", model.Email);
            return new AuthResult(false, "??ng nh?p ?ã b? h?y.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected error while logging in for {Email}", model.Email);
            return new AuthResult(false, "Có l?i x?y ra trong quá trình ??ng nh?p.");
        }
    }

    public async Task<AuthResult> RegisterAsync(RegisterInputModel model, CancellationToken cancellationToken = default)
    {
        try
        {
            await Task.Delay(450, cancellationToken);

            return new AuthResult(true, $"T?o tài kho?n thành công cho {model.FullName}.");
        }
        catch (OperationCanceledException)
        {
            logger.LogWarning("Register request was canceled for {Email}", model.Email);
            return new AuthResult(false, "??ng ký ?ã b? h?y.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected error while registering for {Email}", model.Email);
            return new AuthResult(false, "Có l?i x?y ra trong quá trình ??ng ký.");
        }
    }
}
