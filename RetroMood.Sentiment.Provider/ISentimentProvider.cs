﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RetroMood.Sentiment.Provider.ViewModels;

namespace RetroMood.Sentiment.Provider
{
    public interface ISentimentProvider
    {
        SentimentViewModel Get(string content);
    }
}
