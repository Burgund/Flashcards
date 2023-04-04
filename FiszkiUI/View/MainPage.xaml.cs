﻿using CommunityToolkit.Maui.Views;
using FlashcardsUI.Models;
using FlashcardsUI.Processors;
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

		if (newFlashcard == null)
			throw new Exception("MainPage.AddFlashcardClicked: newFlashcard is null");

		var response = flashcardsProcessor.AddFlashcard(newFlashcard);

		DebugLabel.Text = response.ToString();
		SemanticScreenReader.Announce(DebugLabel.Text);
    }
}

