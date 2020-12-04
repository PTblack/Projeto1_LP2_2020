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
        private string file;
        private string fileFolder;

        // Collections
        private HashSet<Planet> HashSetPL;
        private HashSet<Star> HashSetST;

        public FileManager(string file)
        {
            this.file = file;
            // Initialize the collections for planets and stars
            HashSetPL = new HashSet<Planet>();
            HashSetST = new HashSet<Star>();

            // Location of the folder that is going to be read
            fileFolder = Path.Combine(
                Environment.GetFolderPath(
                Environment.SpecialFolder.Desktop), file);

            CreatePlanetCollection();
            // CreateStarCollection(); 
        }

        /* 
         * >>> QUESTION <<<
         * Can't this be a property that the UI "gets" from here?
         * >>> QUESTION <<<
         */
        public HashSet<Planet> ReturnPlanet() => HashSetPL;

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
                    for (int i = 0; i <= 127; i++) sr.ReadLine();

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

                        Planet p = new Planet(
                            planetAttributes[0], planetAttributes[1], 
                            planetAttributes[2], planetAttributes[3],
                            planetAttributes[4], planetAttributes[5], 
                            planetAttributes[6], planetAttributes[7]);

                        HashSetPL.Add(p);
                    }
                }
            }
        }

        // Searches File and creates Collection with 
        // stars and their wanted values
        private void CreateStarCollection()
        {
            // Array that holds one line's important attributes as strings
            string[] starAttributes = new string[10];
            // String representing line of the file
            string line;

            using (FileStream fileStream = new FileStream(
                fileFolder, FileMode.Open, FileAccess.Read))
            {
                // READS CSV FILE
                using (StreamReader sr = new StreamReader(file))
                {
                    // Skip the first 128 lines of the folder.
                    for(int i = 0; i >= 127; i++) sr.ReadLine();

                    // Read through every line until reaching end of file
                    while((line = sr.ReadLine()) != null)
                    {
                        // Turn line into string array (split csv line on ',')
                        string[] attribs = line.Split(',');

                        /*
                        * Select attributes significant to Star and
                        * add them to starAttributes
                        */

                        // Hosted Planet
                        starAttributes[0] = attribs.ElementAt(
                        (int)AttributePositions.pl_namePOS) != "" ?
                            attribs.ElementAt(
                                (int)AttributePositions.pl_namePOS) :
                                "N/A";

                        // Discovery Method
                        starAttributes[1] = attribs.ElementAt(
                        (int)AttributePositions.pl_discMethodPOS) != "" ?
                            attribs.ElementAt(
                                (int)AttributePositions.pl_discMethodPOS) :
                                "N/A";

                        // Discovery Year
                        starAttributes[2] = attribs.ElementAt(
                        (int)AttributePositions.pl_discYearPOS) != "" ?
                            attribs.ElementAt(
                                (int)AttributePositions.pl_discYearPOS) :
                                "N/A";
                        
                        // Effective Temperature
                        starAttributes[3] = attribs.ElementAt(
                        (int)AttributePositions.st_teffPOS) != "" ?
                            attribs.ElementAt(
                                (int)AttributePositions.st_teffPOS) :
                                "N/A";

                        // Star Radius
                        starAttributes[4] = attribs.ElementAt(
                        (int)AttributePositions.st_radPOS) != "" ? 
                            attribs.ElementAt(
                                (int)AttributePositions.st_radPOS) : 
                                "N/A";

                        // Star Mass
                        starAttributes[5] = attribs.ElementAt(
                        (int)AttributePositions.st_massPOS) != "" ? 
                            attribs.ElementAt(
                                (int)AttributePositions.st_massPOS) : 
                                "N/A";

                        // Star Age
                        starAttributes[6] = attribs.ElementAt(
                        (int)AttributePositions.st_agePOS) != "" ? 
                            attribs.ElementAt(
                                (int)AttributePositions.st_agePOS) : 
                                "N/A";

                        // Star Rotation Velocity
                        starAttributes[7] = attribs.ElementAt(
                        (int)AttributePositions.st_vsinPOS) != "" ? 
                            attribs.ElementAt(
                                (int)AttributePositions.st_vsinPOS) : 
                                "N/A";

                        // Star Rotation Period
                        starAttributes[8] = attribs.ElementAt(
                        (int)AttributePositions.st_rotpPOS) != "" ? 
                            attribs.ElementAt(
                                (int)AttributePositions.st_rotpPOS) : 
                                "N/A";

                        // Distance to Sun
                        starAttributes[9] = attribs.ElementAt(
                        (int)AttributePositions.sy_distPOS) != "" ? 
                            attribs.ElementAt(
                                (int)AttributePositions.sy_distPOS) : 
                                "N/A";

                        Star s = new Star(
                                starAttributes[0], starAttributes[1], 
                                starAttributes[2], starAttributes[3],
                                starAttributes[4], starAttributes[5], 
                                starAttributes[6], starAttributes[7],
                                starAttributes[8], starAttributes[9]);

                        HashSetST.Add(s);
                    }
                }
            }
        }

        // Find and save position of columns with wanted attributes
        // IN CONSTRUCTION
         private void FindValAttributeIndex()
        {
            // Array that holds one line's important attributes as strings
            string[] valAttributes = new string[15];
            // String representing line of the file
            string attributeline;

            using (FileStream fileStream = new FileStream(
                fileFolder, FileMode.Open, FileAccess.Read))
            {
                // READS CSV FILE
                using (StreamReader sr = new StreamReader(file))
                {
                    // Skip the first 127 lines of the folder.
                    for(int i = 0; i >= 126; i++) sr.ReadLine();

                    // Read and save line with attribute columns
                    attributeline = sr.ReadLine();

                    // Create array from column lines
                    string[] attribs = attributeline.Split(',');

                    /*
                     * >>> TO DO <<<
                     * find important things and create collection with 
                     * valuable coordinates to be used in Create[BLANK]Collection
                     * >>> TO DO <<<
                     */
                }
            }
        }
    }
}