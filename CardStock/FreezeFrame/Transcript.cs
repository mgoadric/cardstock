using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace CardStock.FreezeFrame
{
    public class Transcript
    {
        
        // For writing the game transcript
        private readonly string? fileName;

        public Transcript(string? fileName)
        {
            this.fileName = fileName;
            using StreamWriter file = new(fileName + ".txt");
            file.WriteLine("Starting Transcript");
        }

        // TODO Can we move this to another location and call it a Logging class?
        public void WriteToFile(string text)
        {
            using StreamWriter file = new(fileName + ".txt", true);
            file.WriteLine(text);
        }
    }
}
