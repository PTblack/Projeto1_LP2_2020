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
        
        // Holds the number of columns named in the file header
        private int totalAttColl;

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
            CreateStarCollection(); 
        }

        // Public methods that return the Planet and Star collections
        public HashSet<Planet> ReturnPlanet() => HashSetPL;
        public HashSet<Star> ReturnStar() => HashSetST;

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
                    for (int i = 0; i <= firstValLine; i++) sr.ReadLine();

                    // Read through every line until reaching empty line (end)
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Turn line into string array (split csv line on ',')
                        string[] attribs = line.Split(',');

                        // Stops program and sends error message that a 
                        // line in the file didn't have the same number
                        // of elements as header
                        if (attribs.Length != totalAttColl)
                        {
                            Console.WriteLine(line);
                            ExceptionManager.ExceptionControl(
                                ErrorCodes.AttribNumFluct);
                        }

                        /*
                         * Select attributes significant to Planet and
                         * add them to planetAttributes
                         */

                        // Name
                        planetAttributes[0]= 
                            attribs.ElementAt(valAttPos[
                                (int)AttribPos.pl_name]) != "" ?

                            attribs.ElementAt(
                                valAttPos[(int)AttribPos.pl_name]) : 
                            "N/A";

                        // Host Name
                        planetAttributes[1] = 
                            attribs.ElementAt(valAttPos[
                                (int)AttribPos.pl_hostName]) != "" ?

                            attribs.ElementAt(
                                valAttPos[(int)AttribPos.pl_hostName]) : 
                            "N/A";

                        // Discovery Method
                        planetAttributes[2] = 
                            attribs.ElementAt(valAttPos[
                                (int)AttribPos.pl_discMethod]) != "" ?

                            attribs.ElementAt(
                                valAttPos[(int)AttribPos.pl_discMethod]) : 
                            "N/A";

                        // Discovery Year
                        planetAttributes[3] = 
                            attribs.ElementAt(valAttPos[
                                (int)AttribPos.pl_discYear]) != "" ?

                            attribs.ElementAt(
                                valAttPos[(int)AttribPos.pl_discYear]) : 
                            "N/A";

                        // Orbit Period
                        planetAttributes[4] = 
                            attribs.ElementAt(valAttPos[
                                (int)AttribPos.pl_orbPer]) != "" ?

                            attribs.ElementAt(
                                valAttPos[(int)AttribPos.pl_orbPer]) : 
                            "N/A";

                        // Radius
                        planetAttributes[5] = 
                            attribs.ElementAt(valAttPos[
                                (int)AttribPos.pl_rade]) != "" ?

                            attribs.ElementAt(
                                valAttPos[(int)AttribPos.pl_rade]) : 
                            "N/A";

                        // Mass
                        planetAttributes[6] = 
                            attribs.ElementAt(valAttPos[
                                (int)AttribPos.pl_mass]) != "" ?

                            attribs.ElementAt(
                                valAttPos[(int)AttribPos.pl_mass]) : 
                            "N/A";

                        // Equilibrium Temperature
                        planetAttributes[7] = 
                            attribs.ElementAt(valAttPos[
                                (int)AttribPos.pl_eqt]) != "" ?

                            attribs.ElementAt(
                                valAttPos[(int)AttribPos.pl_eqt]) : 
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

                        // Stops program and sends error message that a 
                        // line in the file didn't have the same number
                        // of elements as header
                        if (attribs.Length < totalAttColl)
                            ExceptionManager.ExceptionControl(
                                ErrorCodes.AttribNumFluct);

                        /*
                        * Select attributes significant to Star and
                        * add them to starAttributes
                        */

                        // Hosted Planet
                        starAttributes[0] = 
                            attribs.ElementAt(valAttPos[
                                (int)AttribPos.pl_name]) != "" ?
                            
                            attribs.ElementAt(
                                valAttPos[(int)AttribPos.pl_name]) : 
                            "N/A";

                        // Star Name (Host)
                        starAttributes[1] = 
                            attribs.ElementAt(valAttPos[
                                (int)AttribPos.pl_hostName]) != "" ?
                            
                            attribs.ElementAt(
                                valAttPos[(int)AttribPos.pl_hostName]) : 
                            "N/A";

                        // Effective Temperature
                        starAttributes[2] = 
                            attribs.ElementAt(valAttPos[
                                (int)AttribPos.st_teff]) != "" ?

                            attribs.ElementAt(
                                valAttPos[(int)AttribPos.st_teff]) : 
                            "N/A";

                        // Star Radius
                        starAttributes[3] = 
                            attribs.ElementAt(valAttPos[
                                (int)AttribPos.st_rad]) != "" ? 
                            
                            attribs.ElementAt(
                                valAttPos[(int)AttribPos.st_rad]) : 
                            "N/A";

                        // Star Mass
                        starAttributes[4] = 
                            attribs.ElementAt(valAttPos[
                                (int)AttribPos.st_mass]) != "" ? 
                            
                            attribs.ElementAt(
                                valAttPos[(int)AttribPos.st_mass]) : 
                            "N/A";

                        // Star Age
                        starAttributes[5] = 
                            attribs.ElementAt(valAttPos[
                                (int)AttribPos.st_age]) != "" ? 
                            
                            attribs.ElementAt(
                                valAttPos[(int)AttribPos.st_age]) : 
                            "N/A";

                        // Star Rotation Velocity
                        starAttributes[6] = 
                            attribs.ElementAt(valAttPos[
                                (int)AttribPos.st_vsin]) != "" ? 

                            attribs.ElementAt(
                                valAttPos[(int)AttribPos.st_vsin]) : 
                            "N/A";

                        // Star Rotation Period
                        starAttributes[7] = 
                            attribs.ElementAt(valAttPos[
                                (int)AttribPos.st_rotp]) != "" ? 

                            attribs.ElementAt(
                                valAttPos[(int)AttribPos.st_rotp]) : 
                            "N/A";

                        // Distance to Sun
                        starAttributes[8] = 
                            attribs.ElementAt(valAttPos[
                                (int)AttribPos.sy_dist]) != "" ? 

                            attribs.ElementAt(
                                valAttPos[(int)AttribPos.sy_dist]) : 
                            "N/A";

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

        // Find file header
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
                    do {attributeline = sr.ReadLine(); firstValLine++;}
                    // Skips lines that start with '#' or that are empty strings
                    // Ends with line holding column contents
                    while(attributeline[0] == '#' || attributeline == "");
                    //Console.WriteLine(firstValLine);

                    // Create array from columns' line
                    string[] attribs = attributeline.Split(',');
                    // Saves number of columns on file header in class variable
                    totalAttColl = attribs.Length;

                    FindValAttributes(attribs);
                }
            }
        }

        // Search file header line to find the positions of the 
        // Valuable Attributes (also identifying if attributes are missing)
        private void FindValAttributes(string[] atributeLine)
        {
            // Control variables to mark existence of wanted attributes
            bool nameFound, hostNameFound, discMethodFound, discYearFound,
                orbPerFound, plRadFound, plMassFound, eqTempFound, 
                effTempFound, stRadFound, stMassFound, ageFound, rotVelFound, 
                rotPerFound, distSunFound;
            // All start as 'false'
            nameFound=hostNameFound=discMethodFound=discYearFound=
                orbPerFound=plRadFound=plMassFound=eqTempFound=
                effTempFound=stRadFound=stMassFound=ageFound=rotVelFound= 
                rotPerFound=distSunFound = false;

            for(int i = 0; i < atributeLine.Length; i++)
            {
                switch(atributeLine[i])
                {
                    case "pl_name":
                        valAttPos[(int)AttribPos.pl_name] = i;
                        nameFound = true;
                        break;
                    case "hostname":
                        valAttPos[(int)AttribPos.pl_hostName] = i;
                        hostNameFound = true;
                        break;
                    case "discoverymethod":
                        valAttPos[(int)AttribPos.pl_discMethod] = i;
                        discMethodFound = true;
                        break;
                    case "disc_year":
                        valAttPos[(int)AttribPos.pl_discYear] = i;
                        discYearFound = true;
                        break;
                    case "pl_orbper":
                        valAttPos[(int)AttribPos.pl_orbPer] = i;
                        orbPerFound = true;
                        break;
                    case "pl_rade":
                        valAttPos[(int)AttribPos.pl_rade] = i;
                        plRadFound = true;
                        break;
                    case "pl_masse":
                        valAttPos[(int)AttribPos.pl_mass] = i;
                        plMassFound = true;
                        break;
                    case "pl_eqt":
                        valAttPos[(int)AttribPos.pl_eqt] = i;
                        eqTempFound = true;
                        break;
                    case "st_teff":
                        valAttPos[(int)AttribPos.st_teff] = i;
                        effTempFound = true;
                        break;
                    case "st_rad":
                        valAttPos[(int)AttribPos.st_rad] = i;
                        stRadFound = true;
                        break;
                    case "st_mass":
                        valAttPos[(int)AttribPos.st_mass] = i;
                        stMassFound = true;
                        break;
                    case "st_age":
                        valAttPos[(int)AttribPos.st_age] = i;
                        ageFound = true;
                        break;
                    case "st_vsin":
                        valAttPos[(int)AttribPos.st_vsin] = i;
                        rotVelFound = true;
                        break;
                    case "st_rotp":
                        valAttPos[(int)AttribPos.st_rotp] = i;
                        rotPerFound = true;
                        break;
                    case "sy_dist":
                        valAttPos[(int)AttribPos.sy_dist] = i;
                        distSunFound = true;
                        break;
                }
            }
            
            // Stops program and sends error message that 
            // the file is missing atleast one of the main attributes
            // 'pl_name' or 'hostname'
            if (!nameFound || !hostNameFound)
            { 
            ExceptionManager.ExceptionControl(
                ErrorCodes.AttribsMissing);
            }
        }
    }
}