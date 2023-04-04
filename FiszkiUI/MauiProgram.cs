using CommunityToolkit.Maui;
using FlashcardsUI.Controllers;
using FlashcardsUI.Models;
using FlashcardsUI.Processors;
using FlashcardsUI.ViewModels;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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

        SeedData(app);

        return app;
	}

    private static void SeedData(MauiApp app)
    {
        var dataFileProcessor = app.Services.GetRequiredService<DataFileProcessor>();
        if (!dataFileProcessor.FileExists())
        {
            dataFileProcessor.AddOrUpdateDataFile(JsonConvert.SerializeObject(new AppDataViewModel()
            {
                Flashcards = new List<Flashcard>(),
                LearningLanguages = new List<Languages>(),
                UserName = "default",
                Language = Languages.English
            }));
        }
    }
}
