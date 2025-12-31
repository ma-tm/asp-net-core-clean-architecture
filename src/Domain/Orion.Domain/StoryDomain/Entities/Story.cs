using Orion.Domain.SeedWork;

namespace Orion.Domain.StoryDomain.Entities
{
    // [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Story : Entity
    {
        // [JsonProperty("id")]
        // public Guid Id { get; set; }

        // [JsonProperty("text")]
        public string Text { get; private set; }

        // [JsonProperty("images")]
        public string[] Images { get; private set; }

        public Story(string text, string[] images)
        {
            Text = DoesTextContainBadWords(text) 
                ? throw new BusinessRuleValidationException(ErrorMessages.DetectedBadWordsInText) 
                : text; 
            Images = images;
        }

        public void UpdateText(string newText)
        {
            Text = DoesTextContainBadWords(newText) 
                ? throw new BusinessRuleValidationException(ErrorMessages.DetectedBadWordsInText) 
                : newText;
        }

        private bool DoesTextContainBadWords(string text)
        {
            // Placeholder implementation for bad word detection
            var badWords = new List<string> { "badword1", "badword2", "badword3" };
            return badWords.Any(badWord => text.Contains(badWord, StringComparison.OrdinalIgnoreCase));
        }
    }
}
