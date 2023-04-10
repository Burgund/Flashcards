using FlashcardsCommon.Models;
using FlashcardsAPI.Processors;
using FlashcardsCommon.ViewModels;
using Newtonsoft.Json;

namespace FlashcardsAPI.Controllers
{
    public class FlashcardsController
    {
        //TODO temporary service
        private readonly DataFileProcessor dataFileProcessor;

        public FlashcardsController(DataFileProcessor dataFileProcessor)
        {
            this.dataFileProcessor = dataFileProcessor;
        }

        public void AddFlashcard(Flashcard flashcard)
        {
            dataFileProcessor.AddFlashcard(flashcard);
        }

        public Flashcard TakeLastFlashcard()
        {
            var existingAppData = dataFileProcessor.GetData();
            return existingAppData.Flashcards.Last();
        }
    }
}
