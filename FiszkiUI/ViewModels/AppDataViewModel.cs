using FlashcardsUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashcardsUI.ViewModels
{
    public class AppDataViewModel
    {
        public string UserName { get; set; }
        public Languages Language { get; set; }
        public List<Languages> LearningLanguages { get; set; }
        public List<Flashcard> Flashcards { get; set; }
    }
}
