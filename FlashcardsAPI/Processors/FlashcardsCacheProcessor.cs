using FlashcardsAPI.Cache;
using FlashcardsCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashcardsAPI.Processors
{
    public class FlashcardsCacheProcessor
    {
        private readonly FlashcardsDataCache flashcardsDataCache;
        private readonly DataFileProcessor dataFileProcessor;

        public FlashcardsCacheProcessor(FlashcardsDataCache flashcardsDataCache, DataFileProcessor dataFileProcessor)
        {
            this.flashcardsDataCache = flashcardsDataCache;
            this.dataFileProcessor = dataFileProcessor;
        }

        public void InitializeCache()
        {
            var appData = dataFileProcessor.GetData();

            flashcardsDataCache.Flashcards = appData.Flashcards;
        }

        public void AddFlashcard(Flashcard flashcard)
        {
            flashcardsDataCache.Flashcards.Add(flashcard);
        }

        public Flashcard TakeLastFlashcard()
        {
            return flashcardsDataCache.Flashcards.LastOrDefault();
        }
    }
}
