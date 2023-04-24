using FlashcardsCommon.Models;

namespace FlashcardsCommon.ViewModels
{
    public class AppDataViewModel
    {
        public string UserName { get; set; }
        public Languages Language { get; set; }
        public List<Languages> LearningLanguages { get; set; }
        public Languages CurrentLearningLanguage { get; set; }
        public List<Flashcard> Flashcards { get; set; }
    }
}
