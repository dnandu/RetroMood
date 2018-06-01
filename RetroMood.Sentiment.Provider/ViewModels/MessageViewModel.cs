using System;
using System.Collections.Generic;
using System.Text;

namespace RetroMood.Sentiment.Provider.ViewModels
{
    public class MessageViewModel
    {
        public string Content { get; set; }
        public SentimentViewModel Sentiment { get; set; }
    }
}
