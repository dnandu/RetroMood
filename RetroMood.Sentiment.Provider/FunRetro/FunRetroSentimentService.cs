using RetroMood.Sentiment.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RetroMood.Sentiment.Provider.FunRetro;
using RetroMood.Sentiment.Provider.ViewModels;

namespace RetroMood.Sentiment.Provider.FunRetro
{
    public class FunRetroSentimentService
    {
        private readonly ISentimentService _sentimentService;
        private readonly RetroBoardCsvProvider _retroBoardCsvProvider;

        public FunRetroSentimentService(ISentimentService sentimentService)
        {
            _sentimentService = sentimentService;
            _retroBoardCsvProvider = new RetroBoardCsvProvider();
        }

        public IEnumerable<AuthorMessagesViewModel> GetAuthorMessagesWithSentimentFromCsv(string fullFilePath)
        {
            // read csv 
            var retroBoardCsvProvider = new RetroBoardCsvProvider();
            var flatContent = retroBoardCsvProvider.ReadFile(fullFilePath);
            var retroMessages = retroBoardCsvProvider.GetRetroMessagesFromFlatContent(flatContent);

            // run the sentiment analysis on the retro items and return a grouped list of messages by author
            var model = _sentimentService.GetAuthorMessagesWithSentiment(retroMessages);

            return model;
        }
    }
}
