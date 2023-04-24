using FlashcardsAPI.Cache;
using FlashcardsCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashcardsAPI.Processors
{
    public class UserConfigurationProcessor
    {
        private readonly AccountCacheProcessor accountCacheProcessor;
        private readonly DataFileProcessor dataFileProcessor;

        public UserConfigurationProcessor(AccountCacheProcessor accountCacheProcessor, DataFileProcessor dataFileProcessor)
        {
            this.accountCacheProcessor = accountCacheProcessor;
            this.dataFileProcessor = dataFileProcessor;
        }

        public void SetCurrentLearningLanguage(Languages language)
        {
            accountCacheProcessor.SetCurrentLearningLanguage(language);
            dataFileProcessor.SetCurrentLearningLanguage(language);
        }
    }
}
