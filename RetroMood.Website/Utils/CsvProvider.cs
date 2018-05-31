using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CsvHelper;
using RetroMood.Sentiment.Provider.ViewModels;

namespace RetroMood.Website.Utils
{
    public class CsvProvider
    {
        public IEnumerable<string> ReadFile(string fullFilePath)
        {
            List<string> messages = new List<string>();
            TextReader textReader = File.OpenText(fullFilePath);
            var csvReader = new CsvReader(textReader);
            // we skip the header 
            csvReader.Read();
            csvReader.ReadHeader();
            while (csvReader.Read())
            {
                //var record = csvReader[0];
                // get entire record line
                var record = csvReader.Context.Record;
                messages.AddRange(record.Where(x=>!string.IsNullOrEmpty(x)));
            }

            return messages;
        }

        public IEnumerable<MessageViewModel> GetMessagesFromFlatContent(IEnumerable<string> flatContent)
        {
            var result = flatContent.Select(x => new MessageViewModel()
            {
                Author = x.Split("-")
            })
        }
    }
}
