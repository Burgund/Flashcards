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

			DebugLabel.Text = response.ToString();
			SemanticScreenReader.Announce(DebugLabel.Text);
		}
    }
}

