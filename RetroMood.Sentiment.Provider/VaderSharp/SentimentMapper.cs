using RetroMood.Sentiment.Provider.ViewModels;
using VaderSharp;

namespace RetroMood.Sentiment.Provider.VaderSharp
{
    public class SentimentMapper
    {
        public static SentimentViewModel Map(SentimentAnalysisResults result)
        {
            return new SentimentViewModel
            {
                Positive = result.Positive,
                Negative = result.Negative,
                Neutral = result.Neutral,
                Compound = result.Compound
            };
        }
    }
}
