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

        // Variables to control if a specific valuable attribute as been found 
        // on the file
        private bool nameFound, hostNameFound, discMethodFound, discYearFound,
             orbPerFound, plRadFound, plMassFound, eqTempFound, effTempFound, 
             stRadFound, stMassFound, ageFound, rotVelFound, rotPerFound, 
             distSunFound;

        // Collections
        private HashSet<Planet> HashSetPL;
        private HashSet<Star> HashSetST;

        /// <summary>
        /// Gives class variables all their 'default' values and calls the 
        /// wanted methods to find the header of the csv file and create the 
        /// Planet and Star collections.
        /// </summary>
        /// <param name="file">the provided csv file</param>
        public FileManager(string file)
        {
            this.file = file;
            valAttPos = new int[15];
            firstValLine = 0;

            // Before reading the file, it is not certain if 
            // all attributes exist
            nameFound=hostNameFound=discMethodFound=discYearFound=
            orbPerFound=plRadFound=plMassFound=eqTempFound=
            effTempFound=stRadFound=stMassFound=ageFound=rotVelFound= 
            rotPerFound=distSunFound = false;
            
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

        /// <summary>
        /// Returns the Planet collection
        /// </summary>
        /// <returns>collection of planets</returns>
        public HashSet<Planet> ReturnPlanet() => HashSetPL;
        /// <summary>
        /// Creates the Star collection
        /// </summary>
        /// <returns>collection of stars</returns>
        public HashSet<Star> ReturnStar() => HashSetST;

        /// <summary>
        /// Creates a collection of Planets from the given csv file
        /// </summary>
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
                            ExceptionManager.ExceptionControl(
                                ErrorCodes.AttribNumFluct);
                        }

                        /*
                         * Select attributes significant to Planet and
                         * add them to planetAttributes
                         */

                        // Name
                        if (!nameFound)
                        planetAttributes[0] = null;
                        else 
                        {
                            planetAttributes[0]= 
                                attribs.ElementAt(valAttPos[
                                    (int)AttribPos.pl_name]) != "" ?

                                attribs.ElementAt(
                                    valAttPos[(int)AttribPos.pl_name]) : 
                                "[MISSING]";
                        }

                        // Host Name
                        if (!hostNameFound)
                        planetAttributes[1] = null;
                        else 
                        {
                            planetAttributes[1] = 
                                attribs.ElementAt(valAttPos[
                                    (int)AttribPos.pl_hostName]) != "" ?

                                attribs.ElementAt(
                                    valAttPos[(int)AttribPos.pl_hostName]) : 
                                "[MISSING]";
                        }

                        // Discovery Method
                        if (!discMethodFound)
                        planetAttributes[2] = null;
                        {
                            planetAttributes[2] = 
                                attribs.ElementAt(valAttPos[
                                    (int)AttribPos.pl_discMethod]) != "" ?

                                attribs.ElementAt(
                                    valAttPos[(int)AttribPos.pl_discMethod]) : 
                                "[MISSING]";
                        }

                        // Discovery Year
                        if (!discYearFound)
                        planetAttributes[3] = null;
                        {
                            planetAttributes[3] = 
                                attribs.ElementAt(valAttPos[
                                    (int)AttribPos.pl_discYear]) != "" ?

                                attribs.ElementAt(
                                    valAttPos[(int)AttribPos.pl_discYear]) : 
                                "0";
                        }

                        // Orbit Period
                        if (!orbPerFound)
                        planetAttributes[4] = null;
                        {
                            planetAttributes[4] = 
                                attribs.ElementAt(valAttPos[
                                    (int)AttribPos.pl_orbPer]) != "" ?

                                attribs.ElementAt(
                                    valAttPos[(int)AttribPos.pl_orbPer]) : 
                                "0";
                        }

                        // Radius
                        if (!plRadFound)
                        planetAttributes[5] = null;
                        {
                            planetAttributes[5] = 
                                attribs.ElementAt(valAttPos[
                                    (int)AttribPos.pl_rade]) != "" ?

                                attribs.ElementAt(
                                    valAttPos[(int)AttribPos.pl_rade]) : 
                                "0";
                        }

                        // Mass
                        if (!plMassFound)
                        planetAttributes[6] = null;
                        {
                            planetAttributes[6] = 
                                attribs.ElementAt(valAttPos[
                                    (int)AttribPos.pl_mass]) != "" ?

                                attribs.ElementAt(
                                    valAttPos[(int)AttribPos.pl_mass]) : 
                                "0";
                        }

                        // Equilibrium Temperature
                        if (!eqTempFound)
                        planetAttributes[7] = null;
                        {
                        planetAttributes[7] = 
                            attribs.ElementAt(valAttPos[
                                (int)AttribPos.pl_eqt]) != "" ?

                            attribs.ElementAt(
                                valAttPos[(int)AttribPos.pl_eqt]) : 
                            "0";
                        }

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

        /// <summary>
        /// Creates a collection of Stars from the given csv file
        /// </summary>
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
                        if (!nameFound)
                        starAttributes[0] = null;
                        else 
                        {
                            starAttributes[0] = 
                                attribs.ElementAt(valAttPos[
                                    (int)AttribPos.pl_name]) != "" ?
                                
                                attribs.ElementAt(
                                    valAttPos[(int)AttribPos.pl_name]) : 
                                "[MISSING]";
                        }

                        // Star Name (Host)
                        if (!hostNameFound)
                        starAttributes[1] = null;
                        else
                        {
                            starAttributes[1] = 
                                attribs.ElementAt(valAttPos[
                                    (int)AttribPos.pl_hostName]) != "" ?
                                
                                attribs.ElementAt(
                                    valAttPos[(int)AttribPos.pl_hostName]) : 
                                "[MISSING]";
                        }

                        // Effective Temperature
                        if (!effTempFound)
                        starAttributes[2] = null;
                        else 
                        {
                            starAttributes[2] = 
                                attribs.ElementAt(valAttPos[
                                    (int)AttribPos.st_teff]) != "" ?

                                attribs.ElementAt(
                                    valAttPos[(int)AttribPos.st_teff]) : 
                                "0";
                        }

                        // Star Radius
                        if (!stRadFound)
                        starAttributes[3] = null;
                        else 
                        {
                            starAttributes[3] = 
                                attribs.ElementAt(valAttPos[
                                    (int)AttribPos.st_rad]) != "" ? 
                                
                                attribs.ElementAt(
                                    valAttPos[(int)AttribPos.st_rad]) : 
                                "0";
                        }

                        // Star Mass
                        if (!stMassFound)
                        starAttributes[4] = null;
                        else 
                        {
                            starAttributes[4] = 
                                attribs.ElementAt(valAttPos[
                                    (int)AttribPos.st_mass]) != "" ? 
                                
                                attribs.ElementAt(
                                    valAttPos[(int)AttribPos.st_mass]) : 
                                "0";
                        }

                        // Star Age
                        if (!ageFound)
                        starAttributes[5] = null;
                        else 
                        {
                            starAttributes[5] = 
                                attribs.ElementAt(valAttPos[
                                    (int)AttribPos.st_age]) != "" ? 
                                
                                attribs.ElementAt(
                                    valAttPos[(int)AttribPos.st_age]) : 
                                "0";
                        }

                        // Star Rotation Velocity
                        if (!rotVelFound)
                        starAttributes[6] = null;
                        else 
                        {
                            starAttributes[6] = 
                                attribs.ElementAt(valAttPos[
                                    (int)AttribPos.st_vsin]) != "" ? 

                                attribs.ElementAt(
                                    valAttPos[(int)AttribPos.st_vsin]) : 
                                "0";
                        }

                        // Star Rotation Period
                        if (!rotPerFound)
                        starAttributes[7] = null;
                        else 
                        {
                            starAttributes[7] = 
                                attribs.ElementAt(valAttPos[
                                    (int)AttribPos.st_rotp]) != "" ? 

                                attribs.ElementAt(
                                    valAttPos[(int)AttribPos.st_rotp]) : 
                                "0";
                        }

                        // Distance to Sun
                        if (!distSunFound)
                        starAttributes[8] = null;
                        else 
                        {
                            starAttributes[8] = 
                                attribs.ElementAt(valAttPos[
                                    (int)AttribPos.sy_dist]) != "" ? 

                                attribs.ElementAt(
                                    valAttPos[(int)AttribPos.sy_dist]) : 
                                "0";
                        }

                        Star s = new Star(
                                starAttributes[0].Trim(), starAttributes[1].Trim(), 
                                starAttributes[2].Trim(), starAttributes[3].Trim(),
                                starAttributes[4].Trim(), starAttributes[5].Trim(), 
                                starAttributes[6].Trim(), starAttributes[7].Trim(),
                                starAttributes[8].Trim());

                        HashSetST.Add(s);
                    }
                }
            }
        }

        /// <summary>
        /// Opens file and identifies its header
        /// </summary>
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

                    // Create array from columns' line
                    string[] attribs = attributeline.Split(',');
                    // Saves number of columns on file header in class variable
                    totalAttColl = attribs.Length;

                    // Starts FindVallAttributes with the array containing the 
                    // items of the header
                    FindValAttributes(attribs);
                }
            }
        }

        /// <summary>
        /// Searches the file header to find the positions of the Valuable 
        /// Attributes, saving the positions of the ones that are found.
        /// </summary>
        /// <param name="atributeLine">csv file header</param>
        private void FindValAttributes(string[] atributeLine)
        {
            for(int i = 0; i < atributeLine.Length; i++)
            {
                switch(atributeLine[i].Trim())
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
                    default:
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