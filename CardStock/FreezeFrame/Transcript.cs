using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace CardStock.FreezeFrame
{
    public class Transcript
    {
        
        // For writing the game transcript
        private bool logging;
        private string fileName;

        public Transcript(bool logging, string fileName)
        {
            this.logging = logging;
            this.fileName = fileName;
            if (logging) //logging
            {
                using (StreamWriter file = new StreamWriter(fileName + ".txt"))
                {
                    file.WriteLine("Starting Transcript");
                }
            }
        }

        // TODO Can we move this to another location and call it a Logging class?
        public void WriteToFile(string text)
        {
            if (logging) //logging
            {
                using (StreamWriter file = new StreamWriter(fileName + ".txt", true))
                {
                    file.WriteLine(text);
                }
            }
        }
    }
}
