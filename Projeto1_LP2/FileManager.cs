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

        // Array that holds The positions of the valuable attributes
        private int[] valAttPos;

        // Number of first valid line in file
        private int firstValLine;

        // Collections
        private HashSet<Planet> HashSetPL;
        private HashSet<Star> HashSetST;

        public FileManager(string file)
        {
            this.file = file;
            valAttPos = new int[15];
            firstValLine = 0;
            
            // Initialize the collections for planets and stars
            HashSetPL = new HashSet<Planet>();
            HashSetST = new HashSet<Star>();

            // Location of the folder that is going to be read (Desktop)
            fileFolder = Path.Combine(
                Environment.GetFolderPath(
                Environment.SpecialFolder.Desktop), file);

            FindValAttributeIndex();
            CreatePlanetCollection();
            // CreateStarCollection(); 
        }

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
                    // Skip unwanted lines of the file
                    for (int i = 0; i < firstValLine; i++) sr.ReadLine();

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
                        planetAttributes[0]= 
                            attribs.ElementAt((int)valAttPos[0]) != "" ?
                            attribs.ElementAt((int)valAttPos[0]) : "N/A";

                        // Host Name
                        planetAttributes[1] = 
                            attribs.ElementAt((int)valAttPos[1]) != "" ?
                            attribs.ElementAt((int)valAttPos[1]) : "N/A";

                        // Discovery Method
                        planetAttributes[2] = 
                            attribs.ElementAt((int)valAttPos[2]) != "" ?
                            attribs.ElementAt((int)valAttPos[2]) : "N/A";

                        // Discovery Year
                        planetAttributes[3] = 
                            attribs.ElementAt((int)valAttPos[3]) != "" ?
                            attribs.ElementAt((int)valAttPos[3]) : "N/A";

                        // Orbit Period
                        planetAttributes[4] = 
                            attribs.ElementAt((int)valAttPos[4]) != "" ?
                            attribs.ElementAt((int)valAttPos[4]) : "N/A";

                        // Radius
                        planetAttributes[5] = 
                            attribs.ElementAt((int)valAttPos[5]) != "" ?
                            attribs.ElementAt((int)valAttPos[5]) : "N/A";

                        // Mass
                        planetAttributes[6] = 
                            attribs.ElementAt((int)valAttPos[6]) != "" ?
                            attribs.ElementAt((int)valAttPos[6]) : "N/A";

                        // Equilibrium Temperature
                        planetAttributes[7] = 
                            attribs.ElementAt((int)valAttPos[7]) != "" ?
                            attribs.ElementAt((int)valAttPos[7]) : "N/A";

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
            string[] starAttributes = new string[9];
            // String representing line of the file
            string line;

            using (FileStream fileStream = new FileStream(
                fileFolder, FileMode.Open, FileAccess.Read))
            {
                // READS CSV FILE
                using (StreamReader sr = new StreamReader(file))
                {
                    // Skip unwanted lines of the file
                    for (int i = 0; i < firstValLine; i++) sr.ReadLine();

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
                        starAttributes[0] = 
                            attribs.ElementAt((int)valAttPos[0]) != "" ?
                            attribs.ElementAt((int)valAttPos[0]) : "N/A";

                        // Star Name
                        starAttributes[1] = 
                            attribs.ElementAt((int)valAttPos[1]) != "" ?
                            attribs.ElementAt((int)valAttPos[1]) : "N/A";

                        // Effective Temperature
                        starAttributes[2] = 
                            attribs.ElementAt((int)valAttPos[8]) != "" ?
                            attribs.ElementAt((int)valAttPos[8]) : "N/A";

                        // Star Radius
                        starAttributes[3] = 
                            attribs.ElementAt((int)valAttPos[9]) != "" ? 
                            attribs.ElementAt((int)valAttPos[9]) : "N/A";

                        // Star Mass
                        starAttributes[4] = 
                            attribs.ElementAt((int)valAttPos[10]) != "" ? 
                            attribs.ElementAt((int)valAttPos[10]) : "N/A";

                        // Star Age
                        starAttributes[5] = 
                            attribs.ElementAt((int)valAttPos[11]) != "" ? 
                            attribs.ElementAt((int)valAttPos[11]) : "N/A";

                        // Star Rotation Velocity
                        starAttributes[6] = 
                            attribs.ElementAt((int)valAttPos[12]) != "" ? 
                            attribs.ElementAt((int)valAttPos[12]) : "N/A";

                        // Star Rotation Period
                        starAttributes[7] = 
                            attribs.ElementAt((int)valAttPos[13]) != "" ? 
                            attribs.ElementAt((int)valAttPos[13]) : "N/A";

                        // Distance to Sun
                        starAttributes[8] = 
                            attribs.ElementAt((int)valAttPos[14]) != "" ? 
                            attribs.ElementAt((int)valAttPos[14]) : "N/A";

                        Star s = new Star(
                                starAttributes[0], starAttributes[1], 
                                starAttributes[2], starAttributes[3],
                                starAttributes[4], starAttributes[5], 
                                starAttributes[6], starAttributes[7],
                                starAttributes[8]);

                        HashSetST.Add(s);
                    }
                }
            }
        }

        // Find and save position of columns with wanted attributes
        // IN CONSTRUCTION
         private void FindValAttributeIndex()
        {
            // String representing line of the file
            string attributeline;

            using (FileStream fileStream = new FileStream(
                fileFolder, FileMode.Open, FileAccess.Read))
            {
                // READS CSV FILE
                using (StreamReader sr = new StreamReader(file))
                {
                    // Saves document's first line
                    attributeline = sr.ReadLine();

                    // Skips lines that start with '#' or that are empty strings
                    // Ends with line holding collumn contents
                    while(attributeline[0] == '#' || attributeline == "")
                    {
                        attributeline = sr.ReadLine(); firstValLine++;
                    }

                    // Create array from columns' line
                    string[] attribs = attributeline.Split(',');

                    for(int i = 0; i < attribs.Length; i++)
                    {
                        switch(attribs[i])
                        {
                            case "pl_name":
                                valAttPos[0] = i;
                                break;
                            case "hostname":
                                valAttPos[1] = i;
                                break;
                            case "discoverymethod":
                                valAttPos[2] = i;
                                break;
                            case "disc_year":
                                valAttPos[3] = i;
                                break;
                            case "pl_orbper":
                                valAttPos[4] = i;
                                break;
                            case "pl_rade":
                                valAttPos[5] = i;
                                break;
                            case "pl_masse":
                                valAttPos[6] = i;
                                break;
                            case "pl_eqt":
                                valAttPos[7] = i;
                                break;
                            case "st_teff":
                                valAttPos[8] = i;
                                break;
                            case "st_rad":
                                valAttPos[9] = i;
                                break;
                            case "st_mass":
                                valAttPos[10] = i;
                                break;
                            case "st_age":
                                valAttPos[11] = i;
                                break;
                            case "st_vsin":
                                valAttPos[12] = i;
                                break;
                            case "st_rotp":
                                valAttPos[13] = i;
                                break;
                            case "sy_dist":
                                valAttPos[14] = i;
                                // This line makes it so that 'i' will not meet 
                                // the criteria to continue
                                i = attribs.Length;
                                break;
                        }
                    }
                }
            }
        }
    }
}