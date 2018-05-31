using System;
using System.Collections.Generic;
using System.Text;

namespace RetroMood.Sentiment.Provider.ViewModels
{
    public class SentimentViewModel
    {
        public double Positive { get; set; }
        public double Negative { get; set; }
        public double Neutral { get; set; }
        public double Compound { get; set; }
    }
}
