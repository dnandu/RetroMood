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
    public class RetroBoardCsvProvider
    {
        private readonly string _messageDelimiter = "-";

        public RetroBoardCsvProvider(string messageDelimiter)
        {
            _messageDelimiter = messageDelimiter;
        }

        public RetroBoardCsvProvider() { }

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
                // get entire record line
                var record = csvReader.Context.Record;
                // remove empty strings
                messages.AddRange(record.Where(x=>!string.IsNullOrEmpty(x)));
            }
            return messages;
        }

        public IEnumerable<MessageViewModel> GetMessagesFromFlatContent(IEnumerable<string> flatContent)
        {
            var messages = flatContent.Select(x => x.Split(_messageDelimiter)).Where(y => y.Length == 2).Select(z => new MessageViewModel() { Author = z[0], Content = z[1] });
            return messages;
        }
    }
}
