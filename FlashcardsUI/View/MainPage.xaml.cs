using CommunityToolkit.Maui.Views;
using FlashcardsCommon.Models;
using FlashcardsAPI.Processors;
using FlashcardsUI.View;
using FlashcardsAPI.Controllers;

namespace FlashcardsUI;

public partial class MainPage : ContentPage
{
	private readonly FlashcardsProcessor flashcardsProcessor;
    private readonly AccountCacheProcessor accountCacheProcessor;
    private readonly UserConfigurationController userConfigurationController;

    public MainPage(FlashcardsProcessor flashcardsProcessor, AccountCacheProcessor accountCacheProcessor, UserConfigurationController userConfigurationController)
	{
        this.flashcardsProcessor = flashcardsProcessor;
        this.accountCacheProcessor = accountCacheProcessor;
        this.userConfigurationController = userConfigurationController;

        InitializeComponent();
        InitializeComponentData();
    }

    private void InitializeComponentData()
    {
        LanguageComboBox.ItemsSource = Enum.GetValues(typeof(Languages));
        LanguageComboBox.SelectedItem = accountCacheProcessor.GetDefaultLanguage();
        SetFlagImage((Languages)LanguageComboBox.SelectedItem, LanguageImg);

        LearningLanguageComboBox.ItemsSource = Enum.GetValues(typeof(Languages));
        LearningLanguageComboBox.SelectedItem = accountCacheProcessor.GetCurrentLearningLanguage();
        SetFlagImage((Languages)LearningLanguageComboBox.SelectedItem, LearningLanguageImg);
    }

	private async void AddFlashcardClicked(object sender, EventArgs e)
	{
        var addCardPopup = new AddFlashcard();

        var reasult = await this.ShowPopupAsync(addCardPopup);
		var newFlashcard = reasult as Flashcard;

		if (newFlashcard != null)
		{
			var response = flashcardsProcessor.AddFlashcard(newFlashcard);
            
            if (response != null)
            {
                PrepareLabelAsMessage(DebugLabel);
                DebugLabel.Text = response.ToString();
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

    private void LearningLanguageComboBoxSelectionChanged(object sender, EventArgs e)
    {
        var selectedLanguage = (Languages)LearningLanguageComboBox.SelectedItem;
        SetFlagImage(selectedLanguage, LearningLanguageImg);
        userConfigurationController.SetCurrentLearningLanguage(selectedLanguage);
    }
}

