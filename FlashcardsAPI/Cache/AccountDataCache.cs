using FlashcardsCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashcardsAPI.Cache
{
    public class AccountDataCache
    {
        public string UserName { get; set; }
        public Languages Language { get; set; }
        public List<Languages> LearningLanguages { get; set; }
        public Languages CurrentLearningLanguage { get; set; }
    }
}
