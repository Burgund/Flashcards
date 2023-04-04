using FlashcardsUI.Models;
using FlashcardsUI.Processors;
using FlashcardsUI.ViewModels;
using Newtonsoft.Json;

namespace FlashcardsUI.Controllers
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
            var response = dataFileProcessor.GetData();

            if (string.IsNullOrWhiteSpace(response))
                throw new Exception("FlashcardsUI.Controllers.FlashcardsController.AddFlashcard: empty response");

            var existingAppData = JsonConvert.DeserializeObject<AppDataViewModel>(response);

            existingAppData.Flashcards.Add(flashcard);
            var newDataFile = JsonConvert.SerializeObject(existingAppData);

            dataFileProcessor.AddOrUpdateDataFile(newDataFile);
        }

        public Flashcard TakeLastFlashcard()
        {
            var response = dataFileProcessor.GetData();

            if (string.IsNullOrWhiteSpace(response))
                throw new Exception("FlashcardsUI.Controllers.FlashcardsController.AddFlashcard: empty response");

            var existingAppData = JsonConvert.DeserializeObject<AppDataViewModel>(response);
            return existingAppData.Flashcards.Last();
        }
    }
}
