using FlashcardsAPI.Controllers;
using FlashcardsCommon.Models;

namespace FlashcardsAPI.Processors
{
    public class FlashcardsProcessor
    {
        private readonly FlashcardsController flashcardsController;

        public FlashcardsProcessor(FlashcardsController flashcardsController) 
        { 
            this.flashcardsController = flashcardsController;
        }

        public Flashcard AddFlashcard(Flashcard flashcard)
        {
            if (flashcard == null) 
            {
                //TODO validation message
                throw new NotImplementedException();
            }

            if (string.IsNullOrWhiteSpace(flashcard.Name))
            {
                //TODO validation message
                throw new NotImplementedException();
            }

            if (string.IsNullOrWhiteSpace(flashcard.LearningName))
            {
                //TODO validation message
                throw new NotImplementedException();
            }

            flashcardsController.AddFlashcard(flashcard);

            var result = flashcardsController.TakeLastFlashcard();
            return result;
        }
    }
}
