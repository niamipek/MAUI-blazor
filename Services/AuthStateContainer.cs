using Microsoft.Extensions.Logging;

namespace MonkeyFinderHybrid.Services;

public sealed class AuthStateContainer(IAuthService authService, ILogger<AuthStateContainer> logger)
{
    public LoginInputModel LoginModel { get; } = new();
    public RegisterInputModel RegisterModel { get; } = new();

    public bool ShowPassword { get; private set; }
    public bool IsBusy { get; private set; }
    public string StatusMessage { get; private set; } = string.Empty;
    public bool IsError { get; private set; }

    public event Action? OnChange;

    public async Task LoginAsync()
    {
        try
        {
            IsBusy = true;
            NotifyStateChanged();

            var result = await authService.LoginAsync(LoginModel);
            SetStatus(result.Message, !result.IsSuccess);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception in LoginAsync");
            SetStatus("Có l?i không xác ??nh trong lúc ??ng nh?p.", true);
        }
        finally
        {
            IsBusy = false;
            NotifyStateChanged();
        }
    }

    public async Task RegisterAsync()
    {
        try
        {
            IsBusy = true;
            NotifyStateChanged();

            var result = await authService.RegisterAsync(RegisterModel);
            SetStatus(result.Message, !result.IsSuccess);

            if (result.IsSuccess)
            {
                LoginModel.Email = RegisterModel.Email;
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception in RegisterAsync");
            SetStatus("Có l?i không xác ??nh trong lúc ??ng ký.", true);
        }
        finally
        {
            IsBusy = false;
            NotifyStateChanged();
        }
    }

    public void TogglePassword()
    {
        ShowPassword = !ShowPassword;
        NotifyStateChanged();
    }

    public void SetStatus(string message, bool isError)
    {
        StatusMessage = message;
        IsError = isError;
        NotifyStateChanged();
    }

    public void ClearStatus()
    {
        StatusMessage = string.Empty;
        IsError = false;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
