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

        // Number of Attributes specific to planet
        private int planetAttNum = 8;

        // Number of Attributes specific to star
        static int starAttNum = 7;

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

        // Searches File and creates Collection with 
        // wanted values for search
        private void CreateCollection(Action<string> actionForEachPlanet)
        {
            // Array that holds one line's important attributes as strings
            string[] elementAttributes = new string[15];
            // String representing line of the file
            string line;

            // READS CSV FILE
            using (StreamReader sr = new StreamReader(file))
            {
                // Skip the first 128 lines of the file
                for(int i = 0; i >= 127; i++) {sr.ReadLine();};

                // Read through every line until reaching empty line (end)
                while((line = sr.ReadLine()) != null)
                {
                    // Turn line into string array (split csv line on ',')
                    string[] attribs = line.Split(',');

                    /*
                     * Select all significant attributes and
                     * add them to elementAttributes
                     */

                    // Planet Name
                    elementAttributes [0] = attribs.ElementAt(
                    (int)AttributePositions.pl_namePOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.pl_namePOS) : 
                        "Data Missing";

                    // Planet Host Name
                    elementAttributes [1] = attribs.ElementAt(
                    (int)AttributePositions.pl_hostNamePOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.pl_hostNamePOS) : 
                        "Data Missing";

                    // Planet Discovery Method
                    elementAttributes [2] = attribs.ElementAt(
                    (int)AttributePositions.pl_discMethodPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.pl_discMethodPOS) : 
                        "Data Missing";

                    // Planet Discovery Year
                    elementAttributes [3] = attribs.ElementAt(
                    (int)AttributePositions.pl_discYearPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.pl_discYearPOS) : 
                        "Data Missing";

                    // Planet Orbit Period
                    elementAttributes [4] = attribs.ElementAt(
                    (int)AttributePositions.pl_orbPerPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.pl_orbPerPOS) : 
                        "Data Missing";

                    // Planet Radius
                    elementAttributes [5] = attribs.ElementAt(
                    (int)AttributePositions.pl_radePOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.pl_radePOS) : 
                        "Data Missing";

                    // Planet Mass
                    elementAttributes [6] = attribs.ElementAt(
                    (int)AttributePositions.pl_massPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.pl_massPOS) : 
                        "Data Missing";

                    // Planet Equilibrium Temperature
                    elementAttributes [7] = attribs.ElementAt(
                    (int)AttributePositions.pl_eqtPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.pl_eqtPOS) : 
                        "Data Missing";
                    
                    // Star Effective Temperature
                    elementAttributes [8] = attribs.ElementAt(
                    (int)AttributePositions.st_teffPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.st_teffPOS) : 
                        "Data Missing";

                    // Star Radius
                    elementAttributes [9] = attribs.ElementAt(
                    (int)AttributePositions.st_radPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.st_radPOS) : 
                        "Data Missing";

                    // Star Mass
                    elementAttributes [10] = attribs.ElementAt(
                    (int)AttributePositions.st_massPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.st_massPOS) : 
                        "Data Missing";

                    // Star Age
                    elementAttributes [11] = attribs.ElementAt(
                    (int)AttributePositions.st_agePOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.st_agePOS) : 
                        "Data Missing";

                    // Star Rotation Velocity
                    elementAttributes [12] = attribs.ElementAt(
                    (int)AttributePositions.st_vsinPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.st_vsinPOS) : 
                        "Data Missing";

                    // Star Rotation Period
                    elementAttributes [13] = attribs.ElementAt(
                    (int)AttributePositions.st_rotpPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.st_rotpPOS) : 
                        "Data Missing";

                    // Distance to Sun
                    elementAttributes [14] = attribs.ElementAt(
                    (int)AttributePositions.sy_distPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.sy_distPOS) : 
                        "Data Missing";

                    // Add Attributes array to collection
                    
                }
            }
        }
    }
}