using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace Projeto1_LP2
{
    class FileManager
    {
        // Number of Attributes specific to planet
        private int planetAttNum = 8;

        // Number of Attributes specific to star
        static int starAttNum = 7;

        // Searches File and creates Collection with 
        // planets and their wanted values
        private void CreatePlanetCollection(Action<string> actionForEachPlanet)
        {
            // Array that holds one planet's attributes as strings
            string[] planetAttributes = new string[8];
            // String representing line of the file
            string line;

            // READS CSV FILE
            using (StreamReader sr = new StreamReader(csvfile))
            {
                // Skip the first 128 lines of the file
                for(int i = 0; i >= 127; i++) {sr.ReadLine();};

                // Read through every line until reaching empty line (end)
                while((line = sr.ReadLine()) != null)
                {
                    // Turn line into string array (split csv line on ',')
                    string[] attribs = line.Split(',');

                    /*
                     * Select attributes significant to Planet and
                     * add them to planetAttributes
                     */

                    // Name
                    planetAttributes [0] = attribs.ElementAt(
                    (int)AttributePositions.pl_namePOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.pl_namePOS) : 
                        "Data Missing";

                    // Host Name
                    planetAttributes [1] = attribs.ElementAt(
                    (int)AttributePositions.pl_hostNamePOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.pl_hostNamePOS) : 
                        "Data Missing";

                    // Discovery Method
                    planetAttributes [2] = attribs.ElementAt(
                    (int)AttributePositions.pl_discMethodPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.pl_discMethodPOS) : 
                        "Data Missing";

                    // Discovery Year
                    planetAttributes [3] = attribs.ElementAt(
                    (int)AttributePositions.pl_discYearPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.pl_discYearPOS) : 
                        "Data Missing";

                    // Orbit Period
                    planetAttributes [4] = attribs.ElementAt(
                    (int)AttributePositions.pl_orbPerPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.pl_orbPerPOS) : 
                        "Data Missing";

                    // Radius
                    planetAttributes [5] = attribs.ElementAt(
                    (int)AttributePositions.pl_radePOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.pl_radePOS) : 
                        "Data Missing";

                    // Mass
                    planetAttributes [6] = attribs.ElementAt(
                    (int)AttributePositions.pl_massPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.pl_massPOS) : 
                        "Data Missing";

                    // Equilibrium Temperature
                    planetAttributes [7] = attribs.ElementAt(
                    (int)AttributePositions.pl_eqtPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.pl_eqtPOS) : 
                        "Data Missing";

                    // Add planetAttributes array to collection
                    
                }
            }
        }

        // Searches File and creates Collection with 
        // stars and their wanted values
        private void CreateStarCollection(Action<string> actionForEachStar)
        {
            // Array that holds one star's attributes as strings
            string[] starAttributes = new string[7];
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
                    starAttributes [1] = attribs.ElementAt(
                    (int)AttributePositions.st_radPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.st_radPOS) : 
                        "Data Missing";

                    // Star Mass
                    starAttributes [2] = attribs.ElementAt(
                    (int)AttributePositions.st_massPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.st_massPOS) : 
                        "Data Missing";

                    // Star age
                    starAttributes [3] = attribs.ElementAt(
                    (int)AttributePositions.st_agePOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.st_agePOS) : 
                        "Data Missing";

                    // Star Rotation Velocity
                    starAttributes [4] = attribs.ElementAt(
                    (int)AttributePositions.st_vsinPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.st_vsinPOS) : 
                        "Data Missing";

                    // Star Rotation Period
                    starAttributes [5] = attribs.ElementAt(
                    (int)AttributePositions.st_rotpPOS) != null? 
                        attribs.ElementAt(
                            (int)AttributePositions.st_rotpPOS) : 
                        "Data Missing";

                    // Distance to Sun
                    starAttributes [6] = attribs.ElementAt(
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