using CommunityToolkit.Maui.Views;
using FlashcardsUI.Models;
using FlashcardsUI.View;

namespace FlashcardsUI;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void AddCardClicked(object sender, EventArgs e)
	{
        var addCardPopup = new AddFlashcard();

        var reasult = await this.ShowPopupAsync(addCardPopup);
		var newFlashcard = reasult as Flashcard;

		if (newFlashcard != null)
		{
			DebugLabel.Text = newFlashcard.ToString();
			SemanticScreenReader.Announce(DebugLabel.Text);
		}
	}
}

