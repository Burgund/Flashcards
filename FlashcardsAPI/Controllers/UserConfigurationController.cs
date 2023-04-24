using FlashcardsAPI.Processors;
using FlashcardsCommon.Models;

namespace FlashcardsAPI.Controllers
{
    public class UserConfigurationController
    {
        private readonly UserConfigurationProcessor userConfigurationProcessor;

        public UserConfigurationController(UserConfigurationProcessor userConfigurationProcessor)
        {
            this.userConfigurationProcessor = userConfigurationProcessor;
        }

        public void SetCurrentLearningLanguage(Languages language)
        {
            userConfigurationProcessor.SetCurrentLearningLanguage(language);
        }
    }
}
