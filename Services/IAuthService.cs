namespace MonkeyFinderHybrid.Services;

public interface IAuthService
{
    Task<AuthResult> LoginAsync(LoginInputModel model, CancellationToken cancellationToken = default);
    Task<AuthResult> RegisterAsync(RegisterInputModel model, CancellationToken cancellationToken = default);
}
