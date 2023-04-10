using FlashcardsAPI.Cache;
using FlashcardsAPI.Controllers;
using FlashcardsCommon.Models;

namespace FlashcardsAPI.Processors
{
    public class FlashcardsProcessor
    {
        private readonly FlashcardsController flashcardsController;
        private readonly FlashcardsCacheProcessor flashcardsCacheProcessor;

        public FlashcardsProcessor(FlashcardsController flashcardsController, FlashcardsCacheProcessor flashcardsCacheProcessor) 
        { 
            this.flashcardsController = flashcardsController;
            this.flashcardsCacheProcessor = flashcardsCacheProcessor;
        }

        public Flashcard AddFlashcard(Flashcard flashcard)
        {
            if (flashcard == null) 
            {
                //TODO validation message
                //throw new NotImplementedException();
                Console.WriteLine("AddFlashcard: Flashcard can't be null");
                return null;
            }

            if (string.IsNullOrWhiteSpace(flashcard.Name))
            {
                //TODO validation message
                //throw new NotImplementedException();
                Console.WriteLine("AddFlashcard: Flashcard name can't be empty");
                return null;
            }

            if (string.IsNullOrWhiteSpace(flashcard.LearningName))
            {
                //TODO validation message
                //throw new NotImplementedException();
                Console.WriteLine("AddFlashcard: Flashcard learning name can't be empty");
                return null;
            }

            flashcardsController.AddFlashcard(flashcard);
            flashcardsCacheProcessor.AddFlashcard(flashcard);

            var result = flashcardsCacheProcessor.TakeLastFlashcard();

            if(result == null)
            {
                return new Flashcard();
            }

            return result;
        }
    }
}
