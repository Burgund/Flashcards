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
        LearningLanguageComboBox.ItemsSource = Enum.GetValues(typeof(Languages));
        LearningLanguageComboBox.SelectedItem = accountCacheProcessor.GetCurrentLearningLanguage();

        LanguageComboBox.ItemsSource = Enum.GetValues(typeof(Languages));
        LanguageComboBox.SelectedItem = accountCacheProcessor.GetLanguage();
    }

    void OnCancelButtonClicked(object? sender, EventArgs e) => Close();

    void OnConfirmButtonClicked(object sender, EventArgs e)
    {
        var name = NameEntry.Text;
        var learningName = LearningNameEntry.Text;
        var language = Languages.Polish;
        var learningLanguage = (Languages)LearningLanguageComboBox.SelectedItem;
        var description = DescriptionEditor.Text;

        var result = new Flashcard(name, learningName, language, learningLanguage, description);
        Close(result);
    }
}