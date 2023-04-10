using CommunityToolkit.Maui.Views;
using FlashcardsCommon.Models;
using FlashcardsAPI.Processors;
using FlashcardsUI.View;

namespace FlashcardsUI;

public partial class MainPage : ContentPage
{
	private readonly FlashcardsProcessor flashcardsProcessor;

	public MainPage(FlashcardsProcessor flashcardsProcessor)
	{
		InitializeComponent();
		this.flashcardsProcessor = flashcardsProcessor;
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
}

