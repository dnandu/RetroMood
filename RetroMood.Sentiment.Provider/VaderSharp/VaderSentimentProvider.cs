using System.Threading.Tasks;
using RetroMood.Sentiment.Provider.ViewModels;
using VaderSharp;

namespace RetroMood.Sentiment.Provider.VaderSharp
{
    public class VaderSentimentProvider : ISentimentProvider
    {
        private readonly SentimentIntensityAnalyzer _sentimentAnalyzer;

        public VaderSentimentProvider()
        {
            _sentimentAnalyzer = new SentimentIntensityAnalyzer();
        }

        public SentimentViewModel Get(string content)
        {
            var sentimentAnalysisResults = _sentimentAnalyzer.PolarityScores(content);
            var viewModel = SentimentMapper.Map(sentimentAnalysisResults);

            return viewModel;
        }
    }
}
