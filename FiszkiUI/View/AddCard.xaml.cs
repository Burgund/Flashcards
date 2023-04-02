using CommunityToolkit.Maui.Views;
using FiszkiUI.Models;

namespace FiszkiUI.View;

public partial class AddCard : Popup
{
	public AddCard()
	{
		InitializeComponent();
	}

    void OnCancelButtonClicked(object? sender, EventArgs e) => Close();

    void OnConfirmButtonClicked(object sender, EventArgs e)
    {
        var result = new CardModel(NameEntry.Text, LearningNameEntry.Text, Languages.Polish, Languages.English, DescriptionEditor.Text);
        Close(result);
    }
}