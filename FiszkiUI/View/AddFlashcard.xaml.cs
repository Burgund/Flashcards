using CommunityToolkit.Maui.Views;
using FlashcardsUI.Models;

namespace FlashcardsUI.View;

public partial class AddFlashcard : Popup
{
	public AddFlashcard()
	{
		InitializeComponent();
	}

    void OnCancelButtonClicked(object? sender, EventArgs e) => Close();

    void OnConfirmButtonClicked(object sender, EventArgs e)
    {
        var result = new Flashcard(NameEntry.Text, LearningNameEntry.Text, Languages.Polish, Languages.English, DescriptionEditor.Text);
        Close(result);
    }
}