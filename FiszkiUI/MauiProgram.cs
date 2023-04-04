using CommunityToolkit.Maui;
using FlashcardsUI.Controllers;
using FlashcardsUI.Processors;
using Microsoft.Extensions.Logging;

namespace FlashcardsUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddTransient<MainPage>();
        builder.Services.AddSingleton<FlashcardsController>();
        builder.Services.AddSingleton<FlashcardsProcessor>();
        //TODO temporary service
        builder.Services.AddSingleton<DataFileProcessor>();

        var app = builder.Build();

        //TODO temporary service
        app.Services.GetRequiredService<DataFileProcessor>().CreateDataFile();

		return app;
	}
}
