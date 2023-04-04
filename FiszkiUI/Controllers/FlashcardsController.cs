using FlashcardsUI.Models;
using FlashcardsUI.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
            var stringJsonFlashcard = JsonSerializer.Serialize<Flashcard>(flashcard);

            dataFileProcessor.AddData(stringJsonFlashcard);
        }
    }
}
