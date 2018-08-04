using System;
using System.IO;

namespace FreezeFrame
{
    public class Transcript
    {

        // For writing the game transcript
        public bool logging;
        public string fileName;

        public Transcript(bool logging, string fileName)
        {
            this.logging = logging;
            this.fileName = fileName;
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
