using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Projeto1_LP2
{
    class FileManager
    {
        private const string applicationName = "NasaExoplanetSearcher";
        private const string file = "NasaFile"; // file name for now, we will need to change this to the argument passed by the user
        private string fileFolder;

        // Collections
        public Dictionary<string, Planet> Planets {get; set;}
        public Dictionary<string, Star> Stars {get; set;}

        private int maxPlanets;
        private int maxStars;

        public FileManager()
        {
            // Initialize the dictionaries for both planets and stars
            Planets = new Dictionary<string, Planet>(maxPlanets);
            Stars = new Dictionary<string, Star>(maxStars);

            // Location of the folder that is going to be read
            fileFolder = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData), 
                        applicationName);
            
            // Count the lines in the File, to see how many number of planets/stars there is 
            OpenFile((line) => maxPlanets++);
            OpenFile((line) => maxStars++);         
        }

        private void OpenFile(Action<string> actionPerLine)
        {
            // Get the FileStream and the StreamReader...
            using (FileStream fileStream = new FileStream(
                fileFolder, FileMode.Open, FileAccess.Read))
            {
                using(StreamReader streamReader = new StreamReader(fileStream))
                {
                    string line;

                    // Skip the first line of the folder.
                    streamReader.ReadLine();

                    // Read through every line.
                    while((line = streamReader.ReadLine()) != null)
                    {
                        actionPerLine.Invoke(line);
                    }
                }
            }
        }
    }
}