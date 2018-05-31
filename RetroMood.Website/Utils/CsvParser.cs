using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;

namespace RetroMood.Website.Utils
{
    public class CsvParser
    {
        public void ReadFile(string fullFilePath)
        {
            TextReader textReader = File.OpenText(fullFilePath);
            var csvReader = new CsvReader(textReader);
            // we skip the header 
            csvReader.Read();
            csvReader.ReadHeader();

        }
    }
}
