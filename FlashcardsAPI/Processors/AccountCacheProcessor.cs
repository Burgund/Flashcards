using FlashcardsAPI.Cache;
using FlashcardsCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashcardsAPI.Processors
{
    public class AccountCacheProcessor
    {
        private readonly AccountDataCache accountDataCache;
        private readonly DataFileProcessor dataFileProcessor;

        public AccountCacheProcessor(AccountDataCache accountDataCache, DataFileProcessor dataFileProcessor)
        {
            this.accountDataCache = accountDataCache;
            this.dataFileProcessor = dataFileProcessor;
        }

        public void InitializeCache()
        {
            var appData = dataFileProcessor.GetData();
            accountDataCache.UserName = appData.UserName;
            accountDataCache.CurrentLearningLanguage = appData.CurrentLearningLanguage;
            accountDataCache.LearningLanguages = appData.LearningLanguages;
            accountDataCache.Language = appData.Language;
        }

        public Languages GetDefaultLanguage()
        {
            return accountDataCache.Language;
        }

        public Languages GetCurrentLearningLanguage()
        {
            return accountDataCache.CurrentLearningLanguage;
        }

        public void SetCurrentLearningLanguage(Languages language)
        {
            accountDataCache.CurrentLearningLanguage = language;
        }
    }
}
