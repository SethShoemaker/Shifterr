using Microsoft.Extensions.Logging;

namespace mauiclient;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

		builder.UseMauiApp<App>();

		builder.ConfigureFonts(fonts => {
			fonts.AddFont("RedHatText-Light.ttf", "RedHatTextLight");
            fonts.AddFont("RedHatText-Regular.ttf", "RedHatTextRegular");
            fonts.AddFont("RedHatText-Medium.ttf", "RedHatTextMedium");
            fonts.AddFont("RedHatText-Bold.ttf", "RedHatTextBold");

        });
		
		builder.Services.ConfigureServices();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}