using CommunityToolkit.Maui;
using FlashcardsAPI.Controllers;
using FlashcardsCommon.Models;
using FlashcardsAPI.Processors;
using FlashcardsCommon.ViewModels;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FlashcardsAPI.Cache;
using Microsoft.Maui.LifecycleEvents;
using Microsoft.UI.Windowing;
using Microsoft.UI;

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

#if WINDOWS
        builder.ConfigureLifecycleEvents(events =>
        {
            events.AddWindows(windowsLifecycleBuilder =>
            {
                windowsLifecycleBuilder.OnWindowCreated(window =>
                {
                    window.ExtendsContentIntoTitleBar = false;
                    var handle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                    var id = Win32Interop.GetWindowIdFromWindow(handle);
                    var appWindow = AppWindow.GetFromWindowId(id);
                    switch (appWindow.Presenter)
                    {
                        case OverlappedPresenter overlappedPresenter:
                            overlappedPresenter.SetBorderAndTitleBar(false, false);
                            overlappedPresenter.Maximize();
                            break;
                    }
                });
            });
        });
#endif

        builder.Services.AddTransient<MainPage>();

        builder.Services.AddSingleton<FlashcardsController>();

        builder.Services.AddSingleton<FlashcardsProcessor>();
        builder.Services.AddSingleton<DataFileProcessor>();
        builder.Services.AddSingleton<AccountCacheProcessor>();
        builder.Services.AddSingleton<FlashcardsCacheProcessor>();

        builder.Services.AddSingleton<FlashcardsDataCache>();
        builder.Services.AddSingleton<AccountDataCache>();

        var app = builder.Build();

        SeedData(app);
        InitializeCache(app);

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

    private static void InitializeCache(MauiApp app)
    {
        var accountCacheProcessor = app.Services.GetRequiredService<AccountCacheProcessor>();
        var flashcardsCacheProcessor = app.Services.GetRequiredService<FlashcardsCacheProcessor>();

        accountCacheProcessor.InitializeCache();
        flashcardsCacheProcessor.InitializeCache();
    }
}
