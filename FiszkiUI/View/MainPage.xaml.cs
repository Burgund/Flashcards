using CommunityToolkit.Maui.Views;
using FiszkiUI.Models;
using FiszkiUI.View;

namespace FiszkiUI;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void AddCardClicked(object sender, EventArgs e)
	{
        var addCardPopup = new AddCard();

        var reasult = await this.ShowPopupAsync(addCardPopup);
		var newCard = reasult as CardModel;

		if (newCard != null)
		{
			CardBtn.Text = newCard.Name;
			SemanticScreenReader.Announce(CardBtn.Text);
		}
	}
}

