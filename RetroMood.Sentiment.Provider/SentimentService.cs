using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetroMood.Sentiment.Provider.Models;
using RetroMood.Sentiment.Provider.ViewModels;

namespace RetroMood.Sentiment.Provider
{
    public class SentimentService : ISentimentService
    {
        private readonly ISentimentProvider _sentimentProvider;

        public SentimentService(ISentimentProvider sentimentProvider)
        {
            _sentimentProvider = sentimentProvider;
        }

        public MessageViewModel GetMessageSentimentResultViewModel(RetroMessage message)
        {
            var messageSentiment = _sentimentProvider.Get(message.Content);
            var messageWithSentiment = new MessageViewModel()
            {
                Content = message.Content,
                Sentiment = messageSentiment
            };

            return messageWithSentiment;
        }

        public IEnumerable<MessageViewModel> GetMessagesWithSentiment(IEnumerable<RetroMessage> messages)
        {
            return messages.Select(x => this.GetMessageSentimentResultViewModel(x));
        }

        public IEnumerable<MessageViewModel> GetMessagesWithSentimentFilterBy(IEnumerable<RetroMessage> messages, Func<MessageViewModel, bool> filter)
        {
            return this.GetMessagesWithSentiment(messages).Where(filter);
        }

        public IEnumerable<AuthorMessagesViewModel> GetAuthorMessagesWithSentiment(IEnumerable<RetroMessage> messages)
        {
            var authorMessages =  messages.GroupBy(x => x.Author).Select(y => new AuthorMessagesViewModel() {Author = y.Key, Messages = this.GetMessagesWithSentiment(y)});
            return authorMessages;
        }
    }
}
