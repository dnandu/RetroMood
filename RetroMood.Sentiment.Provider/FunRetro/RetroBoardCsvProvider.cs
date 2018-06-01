using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using RetroMood.Sentiment.Provider.Models;

namespace RetroMood.Sentiment.Provider.FunRetro
{
    public class RetroBoardCsvProvider
    {
        private readonly char _messageDelimiter = '-';

        public RetroBoardCsvProvider(char messageDelimiter)
        {
            _messageDelimiter = messageDelimiter;
        }

        public RetroBoardCsvProvider() { }

        public IEnumerable<string> ReadFile(string fullFilePath)
        {
            List<string> messages = new List<string>();
            TextReader textReader = File.OpenText(fullFilePath);
            var csvReader = new CsvReader(textReader, false);
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
            textReader.Close();
            
            return messages;
        }

        public IEnumerable<RetroMessage> GetRetroMessagesFromFlatContent(IEnumerable<string> flatContent)
        {
            var messages = flatContent.Select(x => x.Split(_messageDelimiter)).Where(y => y.Length == 2).Select(z => new RetroMessage() { Author = z[0], Content = z[1] });
            return messages;
        }
    }
}
