using CommunityToolkit.Maui.Views;
using FlashcardsAPI.Processors;
using FlashcardsCommon.Models;

namespace FlashcardsUI.View;

public partial class AddFlashcard : Popup
{
    private readonly AccountCacheProcessor accountCacheProcessor;

    public AddFlashcard(AccountCacheProcessor accountCacheProcessor)
	{
        this.accountCacheProcessor = accountCacheProcessor;

        InitializeComponent();
        InitializeComponentData();

    }

    private void InitializeComponentData()
    {
        LearningLanguagePicker.ItemsSource = Enum.GetValues(typeof(Languages));
        LearningLanguagePicker.SelectedItem = accountCacheProcessor.GetCurrentLearningLanguage();

        LanguagePicker.ItemsSource = Enum.GetValues(typeof(Languages));
        LanguagePicker.SelectedItem = accountCacheProcessor.GetLanguage();
    }

    void OnCancelButtonClicked(object? sender, EventArgs e) => Close();

    void OnConfirmButtonClicked(object sender, EventArgs e)
    {
        var name = NameEntry.Text;
        var learningName = LearningNameEntry.Text;
        var language = Languages.Polish;
        var learningLanguage = (Languages)LearningLanguagePicker.SelectedItem;
        var description = DescriptionEditor.Text;

        var result = new Flashcard(name, learningName, language, learningLanguage, description);
        Close(result);
    }
}