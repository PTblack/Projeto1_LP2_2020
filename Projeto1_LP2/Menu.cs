using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Projeto1_LP2
{
    /// <summary>
    /// This class receives the arguments from the user 
    /// and gives them to the other classes
    /// </summary>
    class Menu
    {
        private readonly string[] args;

        private Dictionary<string, bool> boolArgs;      
        private Dictionary<string, string> stringArgs;  
        private Dictionary<string, float?> floatArgs;

        private HashSet<Planet> planetCollection;
        private HashSet<Star> starCollection;

        private FileManager fm;
        private FileSearcher fs;

        public Menu(string[] a)
        {
            args = a;
            AddToDictionary();
            Options();
            GetCollections();
        }
        /// <summary>
        /// Method that verifies the arguments from the user and adds them
        /// to their respective dictionary
        /// </summary>
        private void Options()
        {
            for (int i = 0; i < args.Length; i++)
            {
                if(boolArgs.ContainsKey(args[i].ToLower()))
                   boolArgs[args[i]] = true;

                if (stringArgs.ContainsKey(args[i].ToLower()))
                    stringArgs[args[i]] = args[i + 1].Trim();

                if (floatArgs.ContainsKey(args[i].ToLower()))
                    floatArgs[args[i]] = Single.Parse(args[i + 1].Trim(), 
                    NumberStyles.Any, CultureInfo.InvariantCulture);
            }
        }
        
        /// <summary>
        /// Method that creates the dictionarys
        /// </summary>
        private void AddToDictionary()
        {
            boolArgs = new Dictionary<string, bool>();
            stringArgs = new Dictionary<string, string>();
            floatArgs = new Dictionary<string, float?>();

            // Search Criteria
            boolArgs.Add("-search-planet", false);
            boolArgs.Add("-search-star", false);
            boolArgs.Add("-csv", false);
            boolArgs.Add("-help", false);

            // Names
            stringArgs.Add("-file", "");
            stringArgs.Add("-planet-name", "");
            stringArgs.Add("-host-name", "");
            stringArgs.Add("-disc-method", "");

            // Temperature
            floatArgs.Add("-star-temp-min", float.MinValue);
            floatArgs.Add("-star-temp-max", float.MaxValue);
            floatArgs.Add("-planet-temp-min", float.MinValue);
            floatArgs.Add("-planet-temp-max", float.MaxValue);

            // Radius
            floatArgs.Add("-star-rade-min", float.MinValue);
            floatArgs.Add("-star-rade-max", float.MaxValue);
            floatArgs.Add("-planet-rade-min", float.MinValue);
            floatArgs.Add("-planet-rade-max", float.MaxValue);

            // Mass
            floatArgs.Add("-star-mass-min", float.MinValue);
            floatArgs.Add("-star-mass-max", float.MaxValue);
            floatArgs.Add("-planet-mass-min", float.MinValue);
            floatArgs.Add("-planet-mass-max", float.MaxValue);
            
            // Rotation Velocity
            floatArgs.Add("-star-vsin-min", float.MinValue);
            floatArgs.Add("-star-vsin-max", float.MaxValue);

            // Rotation Period
            floatArgs.Add("-star-rotp-min", float.MinValue);
            floatArgs.Add("-star-rotp-max", float.MaxValue);

            // Star Age
            floatArgs.Add("-star-age-min", float.MinValue);
            floatArgs.Add("-star-age-max", float.MaxValue);

            // Planet Orbital Period
            floatArgs.Add("-planet-orbper-min", float.MinValue);
            floatArgs.Add("-planet-orbper-max", float.MaxValue);

            // Discovery Specs
            floatArgs.Add("-disc-year-min", float.MinValue);
            floatArgs.Add("-disc-year-max", float.MaxValue);

            // Star Distance to Sun
            floatArgs.Add("-sy-dist-min", float.MinValue);
            floatArgs.Add("-sy-dist-max", float.MaxValue);
        }

        /// <summary>
        /// Method that gives the user arguments to the FileManager 
        /// and FileSearcher classes 
        /// </summary>
        private void GetCollections()
        {
            fm = new FileManager(stringArgs["-file"]);
            CheckForArgumentExceptions();

            planetCollection = fm.ReturnPlanet();
            starCollection = fm.ReturnStar();
            fs = new FileSearcher(boolArgs,  stringArgs, floatArgs, 
                planetCollection, starCollection);
        }

        /// <summary>
        /// Method that shows the final filtered collection, to the user 
        /// </summary>
        public void ShowCollection()
        {
            if (boolArgs["-help"] == true)
                ExceptionManager.ShowHelp();

            if(boolArgs["-search-planet"] == true)
            {
                if (fs.FilteredPlanetCollection.Count() == 0)
                    ExceptionManager.ExceptionControl(ErrorCodes.NoDataFound);

                foreach (Planet p in fs.FilteredPlanetCollection)
                {
                    p.ConvertFloatablesToDefault();
                    Console.WriteLine(p.ToString(boolArgs["-csv"]));
                }
            }
                   
            else if (boolArgs["-search-star"] == true)
            {
                if (fs.FilteredStarCollection.Count() == 0)
                    ExceptionManager.ExceptionControl(ErrorCodes.NoDataFound);

                foreach (Star s in fs.FilteredStarCollection)
                {
                    s.ConvertFloatablesToDefault();
                    Console.WriteLine(s.ToString(boolArgs["-csv"]));
                }
            }

                   
        }
        /// <summary>
        /// Method that verifies exceptions in the user arguments
        /// </summary>
        public void CheckForArgumentExceptions()
        {
            // IncompatibleOptions
            if (boolArgs["-search-planet"] &&
                boolArgs["-search-star"])
            {
                ExceptionManager.ExceptionControl(
                        ErrorCodes.IncompatibleOptions);
            }

            // No Search Exception
            if (!boolArgs["-search-planet"] &&
                !boolArgs["-search-star"] &&
                !boolArgs["-help"])
            {
                ExceptionManager.ExceptionControl(ErrorCodes.NoSearchOption);
            }
        }
    }
}