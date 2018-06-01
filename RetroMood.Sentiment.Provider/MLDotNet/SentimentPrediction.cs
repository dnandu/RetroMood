using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML.Runtime.Api;

namespace RetroMood.Sentiment.Provider.MLDotNet
{
    public class SentimentPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool Sentiment;
    }
}
