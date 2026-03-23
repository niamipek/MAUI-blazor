using Microsoft.Extensions.Logging;

namespace MonkeyFinderHybrid;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
        builder.Services.AddSingleton<MonkeyService>();
		builder.Services.AddScoped<IAuthService, AuthService>();
		builder.Services.AddScoped<AuthStateContainer>();
		builder.Services.AddSingleton<IMap>(sp => Map.Default);

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
