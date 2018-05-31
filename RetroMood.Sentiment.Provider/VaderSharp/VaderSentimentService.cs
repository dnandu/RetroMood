using System.Threading.Tasks;
using RetroMood.Sentiment.Provider.ViewModels;
using VaderSharp;

namespace RetroMood.Sentiment.Provider.VaderSharp
{
    public class VaderSentimentService : ISentimentService
    {
        private readonly SentimentIntensityAnalyzer sentimentAnalyzer;

        public VaderSentimentService()
        {
            this.sentimentAnalyzer = new SentimentIntensityAnalyzer();
        }

        public Task<SentimentViewModel> Get(string content)
        {
            var sentimentAnalysisResults = this.sentimentAnalyzer.PolarityScores(content);
            var viewModel = SentimentMapper.Map(sentimentAnalysisResults);

            return Task.FromResult(viewModel);
        }
    }
}
