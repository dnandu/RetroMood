using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetroMood.Sentiment.Provider.ViewModels
{
    public class AuthorMessagesViewModel
    {
        public string Author { get; set; }
        public IEnumerable<MessageViewModel> Messages { get; set; }

        public AuthorMessagesViewModel()
        {
            this.Messages = new List<MessageViewModel>();
        }

        public double AverageSentimentCompound
        {
            get { return this.Messages.Average(x => x.Sentiment.Compound); }
        }
    }
}
