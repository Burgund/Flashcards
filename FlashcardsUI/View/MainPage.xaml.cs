using CommunityToolkit.Maui.Views;
using FlashcardsCommon.Models;
using FlashcardsAPI.Processors;
using FlashcardsUI.View;
using FlashcardsAPI.Controllers;
using System.Collections.ObjectModel;

namespace FlashcardsUI;

public partial class MainPage : ContentPage
{
	private readonly FlashcardsProcessor flashcardsProcessor;
    private readonly AccountCacheProcessor accountCacheProcessor;
    private readonly UserConfigurationController userConfigurationController;
    private readonly FlashcardsCacheProcessor flashcardsCacheProcessor;

    public ObservableCollection<Flashcard> SelectedFlashcards { get; set; }

    public MainPage(FlashcardsProcessor flashcardsProcessor, 
        AccountCacheProcessor accountCacheProcessor, 
        UserConfigurationController userConfigurationController,
        FlashcardsCacheProcessor flashcardsCacheProcessor)
	{
        this.flashcardsProcessor = flashcardsProcessor;
        this.accountCacheProcessor = accountCacheProcessor;
        this.userConfigurationController = userConfigurationController;
        this.flashcardsCacheProcessor = flashcardsCacheProcessor;

        InitializeComponent();
        InitializeComponentData();
    }

    private void InitializeComponentData()
    {
        var learningLanguage = accountCacheProcessor.GetCurrentLearningLanguage();

        SelectedFlashcards = new ObservableCollection<Flashcard>();
        BindingContext = this;
        LoadFlashcardsList(learningLanguage);

        LanguagePicker.ItemsSource = Enum.GetValues(typeof(Languages));
        LanguagePicker.SelectedItem = accountCacheProcessor.GetLanguage();
        SetFlagImage((Languages)LanguagePicker.SelectedItem, LanguageImg);

        LearningLanguagePicker.ItemsSource = Enum.GetValues(typeof(Languages));
        LearningLanguagePicker.SelectedItem = learningLanguage;
        SetFlagImage((Languages)LearningLanguagePicker.SelectedItem, LearningLanguageImg);
    }

    private async void AddFlashcardClicked(object sender, EventArgs e)
	{
        var addCardPopup = new AddFlashcard(accountCacheProcessor);

        var reasult = await this.ShowPopupAsync(addCardPopup);
		var newFlashcard = reasult as Flashcard;

		if (newFlashcard != null)
		{
			var responseFlashcard = flashcardsProcessor.AddFlashcard(newFlashcard);
            
            if (responseFlashcard != null)
            {
                PrepareLabelAsMessage(DebugLabel);
                DebugLabel.Text = responseFlashcard.ToString();

                if(responseFlashcard.LearningLanguage == accountCacheProcessor.GetCurrentLearningLanguage())
                    SelectedFlashcards.Add(responseFlashcard);
            }
            else
            {
                PrepareLabelAsError(DebugLabel);
                DebugLabel.Text = "ERROR - Can't add empty flashcard!";
            }

            AnnounceDebugLabel();
        }
    }

    private void CloseAppClicked(object sender, EventArgs e)
    {
        Application.Current.Quit();
    }

    private void RandomFishcardClicked(object sender, EventArgs e)
    {
        PrepareLabelAsError(DebugLabel);
        DebugLabel.Text = new NotImplementedException().Message;
        AnnounceDebugLabel();
    }

    private void LearnClicked(object sender, EventArgs e)
    {
        PrepareLabelAsError(DebugLabel);
        DebugLabel.Text = new NotImplementedException().Message;
        AnnounceDebugLabel();
    }

    private void PrepareLabelAsError(Label label)
    {
        DebugLabel.TextColor = Colors.DarkRed;
        DebugLabel.FontAttributes = FontAttributes.Bold;
    }

    private void PrepareLabelAsMessage(Label label)
    {
        DebugLabel.TextColor = Colors.Indigo;
        DebugLabel.FontAttributes = FontAttributes.None;
    }

    private void AnnounceDebugLabel()
    {
        SemanticScreenReader.Announce(DebugLabel.Text);
        DebugLabel.IsVisible = true;
    }

    private void SetFlagImage(Languages language, Image image)
    {
        if (language == Languages.English)
            image.Source = "fla_gbr.png";
        else if (language == Languages.German)
            image.Source = "fla_ger.png";
        else if (language == Languages.Polish)
            image.Source = "fla_pl.png";
    }

    private void LearningLanguagePickerSelectionChanged(object sender, EventArgs e)
    {
        var selectedLanguage = (Languages)LearningLanguagePicker.SelectedItem;
        SetFlagImage(selectedLanguage, LearningLanguageImg);
        userConfigurationController.SetCurrentLearningLanguage(selectedLanguage);

        LoadFlashcardsList(selectedLanguage);
    }

    private void LoadFlashcardsList(Languages language)
    {
        SelectedFlashcards.Clear();

        var selectedFlashcardsFromCache = flashcardsCacheProcessor.GetFlashcardsForLearningLanguage(language);
        foreach (var selectedFlashcard in selectedFlashcardsFromCache)
            SelectedFlashcards.Add(selectedFlashcard);
    }
}

