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
        private string file; // file name for now, we will need to change this to the argument passed by the user
        private string fileFolder;

        // Collections
        private HashSet<Planet> HashsetPL;
        private HashSet<Star> hashSetST;

        public FileManager(string file)
        {
            this.file = file;
            // Initialize the dictionaries for both planets and stars
            HashsetPL = new HashSet<Planet>();
            hashSetST = new HashSet<Star>();

            // Location of the folder that is going to be read
            fileFolder = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.Desktop), 
                        file);

            CreatePlanetCollection();                   
        }

        // Searches File and creates Collection with 
        // planets and their wanted values
        private void CreatePlanetCollection()
        {
            // Array that holds one line's important attributes as strings
            string[] planetAttributes = new string[8];
            // String representing line of the file
            string line;


            using (FileStream fileStream = new FileStream(
                fileFolder, FileMode.Open, FileAccess.Read))
            {
                // READS CSV FILE
                using (StreamReader sr = new StreamReader(file))
                {
                    // Skip the first 128 lines of the file
                    for (int i = 0; i <= 127; i++) 
                        sr.ReadLine();

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
                        planetAttributes[0]= attribs.ElementAt(
                        (int)AttributePositions.pl_namePOS) != "" ?
                            attribs.ElementAt(
                                (int)AttributePositions.pl_namePOS) :
                            "N/A";

                        // Host Name
                        planetAttributes[1] = attribs.ElementAt(
                        (int)AttributePositions.pl_hostNamePOS) != "" ?
                            attribs.ElementAt(
                                (int)AttributePositions.pl_hostNamePOS) :
                            "N/A";

                        // Discovery Method
                        planetAttributes[2] = attribs.ElementAt(
                        (int)AttributePositions.pl_discMethodPOS) != "" ?
                            attribs.ElementAt(
                                (int)AttributePositions.pl_discMethodPOS) :
                            "N/A";

                        // Discovery Year
                        planetAttributes[3] = attribs.ElementAt(
                        (int)AttributePositions.pl_discYearPOS) != "" ?
                            attribs.ElementAt(
                                (int)AttributePositions.pl_discYearPOS) :
                            "N/A";

                        // Orbit Period
                        planetAttributes[4] = attribs.ElementAt(
                        (int)AttributePositions.pl_orbPerPOS) != "" ?
                            attribs.ElementAt(
                                (int)AttributePositions.pl_orbPerPOS) :
                            "N/A";

                        // Radius
                        planetAttributes[5] = attribs.ElementAt(
                        (int)AttributePositions.pl_radePOS) != "" ?
                            attribs.ElementAt(
                                (int)AttributePositions.pl_radePOS) :
                            "N/A";

                        // Mass
                        planetAttributes[6] = attribs.ElementAt(
                        (int)AttributePositions.pl_massPOS) != "" ?
                            attribs.ElementAt(
                                (int)AttributePositions.pl_massPOS) :
                            "N/A";

                        // Equilibrium Temperature
                        planetAttributes[7] = attribs.ElementAt(
                        (int)AttributePositions.pl_eqtPOS) != "" ?
                            attribs.ElementAt(
                                (int)AttributePositions.pl_eqtPOS) :
                            "N/A";

                        Planet p = new Planet(planetAttributes[0], planetAttributes[1], planetAttributes[2], planetAttributes[3],
                                planetAttributes[4], planetAttributes[5], planetAttributes[6], planetAttributes[7]);

                        HashsetPL.Add(p);
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
            using (StreamReader sr = new StreamReader(file))
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
                    starAttributes[1] = attribs.ElementAt(
                    (int)AttributePositions.st_radPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.st_radPOS) : 
                        "Data Missing";

                    // Star Mass
                    starAttributes[2] = attribs.ElementAt(
                    (int)AttributePositions.st_massPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.st_massPOS) : 
                        "Data Missing";

                    // Star Age
                    starAttributes[3] = attribs.ElementAt(
                    (int)AttributePositions.st_agePOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.st_agePOS) : 
                        "Data Missing";

                    // Star Rotation Velocity
                    starAttributes[4] = attribs.ElementAt(
                    (int)AttributePositions.st_vsinPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.st_vsinPOS) : 
                        "Data Missing";

                    // Star Rotation Period
                    starAttributes[5] = attribs.ElementAt(
                    (int)AttributePositions.st_rotpPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.st_rotpPOS) : 
                        "Data Missing";

                    // Distance to Sun
                    starAttributes[6] = attribs.ElementAt(
                    (int)AttributePositions.sy_distPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.sy_distPOS) : 
                        "Data Missing";

                    // Add planetAttributes array to collection
                    
                }
            }
        }

        public HashSet<Planet> ReturnPlanet() => HashsetPL;
        
    }
}