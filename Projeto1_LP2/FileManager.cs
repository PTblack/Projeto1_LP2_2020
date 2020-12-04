using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Microsoft.VisualBasic;

namespace Projeto1_LP2
{
    class FileManager
    {
        private const string applicationName = "NasaExoplanetSearcher";
        private string file; // file name for now, we will need to change this to the argument passed by the user
        private string fileFolder;

        // Collections
        private Dictionary<string, Planet> hashSetPL;
        private HashSet<Star> hashSetST;

        // Number of Attributes specific to planet
        private int planetAttNum = 8;

        // Number of Attributes specific to star
        static int starAttNum = 7;

        public FileManager(string file)
        {
            this.file = file;
            // Initialize the dictionaries for both planets and stars
            hashSetPL = new Dictionary<string, Planet>();
            hashSetST = new HashSet<Star>();

            // Location of the folder that is going to be read
            fileFolder = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData), 
                        applicationName);
                   
        }

        // Searches File and creates Collection with 
        // planets and their wanted values
        private void CreatePlanetCollection(Func<string> actionForEachPlanet)
        {
            // Array that holds one line's important attributes as strings
            string[] elementAttributes = new string[15];
            // String representing line of the file
            string line;


            using (FileStream fileStream = new FileStream(
                fileFolder, FileMode.Open, FileAccess.Read))
            {
                // READS CSV FILE
                using (StreamReader sr = new StreamReader(file))
                {
                    // Skip the first 128 lines of the file
                    for (int i = 0; i <= 127; i++) { sr.ReadLine(); };

                    // Read through every line until reaching empty line (end)
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Turn line into string array (split csv line on ',')
                        string[] attribs = line.Split(',');
                        /*
                         * Select attributes significant to Planet and
                         * add them to planetAttributes
                         */

                        // Name
                        planetAttributes[0] = attribs.ElementAt(
                        (int)AttributePositions.pl_namePOS) != null ?
                            attribs.ElementAt(
                                (int)AttributePositions.pl_namePOS) :
                            "Data Missing";

                        // Host Name
                        planetAttributes[1] = attribs.ElementAt(
                        (int)AttributePositions.pl_hostNamePOS) != null ?
                            attribs.ElementAt(
                                (int)AttributePositions.pl_hostNamePOS) :
                            "Data Missing";

                        // Discovery Method
                        planetAttributes[2] = attribs.ElementAt(
                        (int)AttributePositions.pl_discMethodPOS) != null ?
                            attribs.ElementAt(
                                (int)AttributePositions.pl_discMethodPOS) :
                            "Data Missing";

                        // Discovery Year
                        planetAttributes[3] = attribs.ElementAt(
                        (int)AttributePositions.pl_discYearPOS) != null ?
                            attribs.ElementAt(
                                (int)AttributePositions.pl_discYearPOS) :
                            "Data Missing";

                        // Orbit Period
                        planetAttributes[4] = attribs.ElementAt(
                        (int)AttributePositions.pl_orbPerPOS) != null ?
                            attribs.ElementAt(
                                (int)AttributePositions.pl_orbPerPOS) :
                            "Data Missing";

                        // Radius
                        planetAttributes[5] = attribs.ElementAt(
                        (int)AttributePositions.pl_radePOS) != null ?
                            attribs.ElementAt(
                                (int)AttributePositions.pl_radePOS) :
                            "Data Missing";

                        // Mass
                        planetAttributes[6] = attribs.ElementAt(
                        (int)AttributePositions.pl_massPOS) != null ?
                            attribs.ElementAt(
                                (int)AttributePositions.pl_massPOS) :
                            "Data Missing";

                        // Equilibrium Temperature
                        planetAttributes[7] = attribs.ElementAt(
                        (int)AttributePositions.pl_eqtPOS) != null ?
                            attribs.ElementAt(
                                (int)AttributePositions.pl_eqtPOS) :
                            "Data Missing";

                        Planet p = new Planet(planetAttributes[0], planetAttributes[1], planetAttributes[2], planetAttributes[3],
                                planetAttributes[4], planetAttributes[5], planetAttributes[6], planetAttributes[7]);

                    }
                }

            }
        }

        // Searches File and creates Collection with 
        // stars and their wanted values
        private void CreateStarCollection(Action<string> actionForEachStar)
        {
            // Array that holds one star's attributes as strings
            string[] starAttributes = new string[8];
            // String representing line of the file
            string line;

            // READS CSV FILE
            using (StreamReader sr = new StreamReader(csvfile))
            {
                // Skip the first 128 lines of the folder.
                for(int i = 0; i >= 127; i++) {sr.ReadLine();};

                // Read through every line until reaching end of file
                while((line = sr.ReadLine()) != null)
                {
                    // Turn line into string array (split csv line on ',')
                    string[] attribs = line.Split(',');

                    /*
                     * Select attributes significant to Star and
                     * add them to starAttributes
                     */

                    // Effective Temperature
                    starAttributes [0] = attribs.ElementAt( 
                    (int)AttributePositions.st_teffPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.st_teffPOS) : 
                        "Data Missing";

                    // Star Radius
                    elementAttributes [1] = attribs.ElementAt(
                    (int)AttributePositions.st_radPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.st_radPOS) : 
                        "Data Missing";

                    // Star Mass
                    elementAttributes [2] = attribs.ElementAt(
                    (int)AttributePositions.st_massPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.st_massPOS) : 
                        "Data Missing";

                    // Star Age
                    elementAttributes [3] = attribs.ElementAt(
                    (int)AttributePositions.st_agePOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.st_agePOS) : 
                        "Data Missing";

                    // Star Rotation Velocity
                    elementAttributes [4] = attribs.ElementAt(
                    (int)AttributePositions.st_vsinPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.st_vsinPOS) : 
                        "Data Missing";

                    // Star Rotation Period
                    elementAttributes [5] = attribs.ElementAt(
                    (int)AttributePositions.st_rotpPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.st_rotpPOS) : 
                        "Data Missing";

                    // Distance to Sun
                    elementAttributes [6] = attribs.ElementAt(
                    (int)AttributePositions.sy_distPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.sy_distPOS) : 
                        "Data Missing";

                    // Add planetAttributes array to collection
                    
                }
            }
        }
    }
}