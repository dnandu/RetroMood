using System;
using System.Collections.Generic;
using System.Text;

namespace RetroMood.Sentiment.Provider.ViewModels
{
    /// <summary>
    /// Percentage value
    /// </summary>
    public class SentimentViewModel
    {
        public double Positive { get; set; }
        public double Negative { get; set; }
        public double Neutral { get; set; }
        /// <summary>
        /// Represented as percentage
        /// </summary>
        public double Compound { get; set; }
    }
}
