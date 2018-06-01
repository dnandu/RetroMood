using System;
using System.Collections.Generic;
using RetroMood.Sentiment.Provider.Models;
using RetroMood.Sentiment.Provider.ViewModels;

namespace RetroMood.Sentiment.Provider
{
    public interface ISentimentService
    {
        MessageViewModel GetMessageSentimentResultViewModel(RetroMessage message);
        IEnumerable<MessageViewModel> GetMessagesWithSentiment(IEnumerable<RetroMessage> messages);
        IEnumerable<AuthorMessagesViewModel> GetAuthorMessagesWithSentiment(IEnumerable<RetroMessage> messages);
    }
}