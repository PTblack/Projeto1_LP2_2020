using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Projeto1_LP2
{
    /// <summary>
    /// TROCAR DE NOME!!!!!!!!!!!!!!!!!!!!
    /// </summary>
    class UI
    {
        private readonly string[] args;

        private Dictionary<string, bool> boolArgs;      
        private Dictionary<string, string> stringArgs;  
        private Dictionary<string, float?> floatArgs;
        private Dictionary<string, string> SortArgs;

        private HashSet<Planet> planetCollection;
        private HashSet<Star> starCollection;

        private FileManager fm;
        private FileSearcher fs;

        public UI(string[] a)
        {
            args = a;
            GetCollections();
        }

        private void Options()
        {
            AddToDictionary();
            for (int i = 0; i < args.Length; i++)
            {
                if(boolArgs.ContainsKey(args[i].ToLower()))
                   boolArgs[args[i]] = true;

                if (stringArgs.ContainsKey(args[i].ToLower()))
                    stringArgs[args[i]] = args[i + 1];

                if (floatArgs.ContainsKey(args[i].ToLower()))
                    floatArgs[args[i]] = Single.Parse(args[i + 1], NumberStyles.Any,
                CultureInfo.InvariantCulture);

                if (SortArgs.ContainsKey(args[i].ToLower()))
                    SortArgs[args[i]] = args[i + 1];
            }
            CheckForExceptions();
        }
        
        private void AddToDictionary()
        {
            boolArgs = new Dictionary<string, bool>();
            stringArgs = new Dictionary<string, string>();
            floatArgs = new Dictionary<string, float?>();
            SortArgs = new Dictionary<string, string>();

            //Sort Order
            SortArgs.Add("-desc", "");
            SortArgs.Add("-asc", "");

            // Search Criteria
            boolArgs.Add("-search-planet", false);
            boolArgs.Add("-search-star", false);
            boolArgs.Add("-planet-info", false);
            boolArgs.Add("-star-info", false);
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

        // PASSAR PARA CLASSE DE UI NOVA QUE FOR CRIADA
        // Show collection of planets that fit the user's requests
        private void GetCollections()
        {
            Options();
            fm = new FileManager(stringArgs["-file"]);
            planetCollection = fm.ReturnPlanet();
            starCollection = fm.ReturnStar();
            fs = new FileSearcher(boolArgs,  stringArgs, floatArgs, 
                planetCollection, starCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ShowCollection()
        {
            if (boolArgs["-help"] == true)
                ShowHelp();

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
                    
            else if(boolArgs["-planet-info"] == true)
            {
                if (fs.FilteredPlanetCollection.Count() == 0)
                    ExceptionManager.ExceptionControl(ErrorCodes.NoDataFound);

                foreach (Planet p in fs.FilteredPlanetCollection)
                    p.ConvertFloatablesToDefault();
                Console.WriteLine(fs.FilteredPlanetCollection.
                    ElementAt(0).ToString(boolArgs["-csv"]));
            }

            if (boolArgs["-search-star"] == true)
            {
                if (fs.FilteredStarCollection.Count() == 0)
                    ExceptionManager.ExceptionControl(ErrorCodes.NoDataFound);

                foreach (Star s in fs.FilteredStarCollection)
                {
                    s.ConvertFloatablesToDefault();
                    Console.WriteLine(s.ToString(boolArgs["-csv"]));
                }
            }

                    
            else if(boolArgs["-star-info"] == true)
            {
                if (fs.FilteredStarCollection.Count() == 0)
                    ExceptionManager.ExceptionControl(ErrorCodes.NoDataFound);

                foreach (Star s in fs.FilteredStarCollection)
                    s.ConvertFloatablesToDefault();
                Console.WriteLine(fs.FilteredStarCollection.
                                ElementAt(0).ToString(boolArgs["-csv"]));
            }
        }

        private void SortCollection(HashSet<Star> collection)
        {
            if (SortArgs["-desc"].Contains("temp".ToLower()))
            {
            }
            if (SortArgs["-desc"].Contains("rade".ToLower()))
            {

            }
            if (SortArgs["-desc"].Contains("mass".ToLower()))
            {
                //HashSet<Star> d = collection.OrderBy(x => float.Parse(x.MassRatio));
            }
            if (SortArgs["-desc"].Contains("orbper".ToLower()))
            {

            }
            if (SortArgs["-desc"].Contains("year".ToLower()))
            {

            }
            if (SortArgs["-desc"].Contains("vsin".ToLower()))
            {

            }
            if (SortArgs["-desc"].Contains("rotp".ToLower()))
            {

            }
            if (SortArgs["-desc"].Contains("age".ToLower()))
            {

            }

        }

        public void CheckForExceptions()
        {
            int planetInfoValue = boolArgs["-planet-info"] ? 1 : 0;
            int starInfoValue = boolArgs["-star-info"] ? 1 : 0;
            int searchPlanetValue = boolArgs["-search-planet"] ? 1 : 0;
            int searchStarValue = boolArgs["-search-star"] ? 1 : 0; 

            // IncompatibleOptions
            if(planetInfoValue + starInfoValue 
                + searchPlanetValue + searchStarValue > 1)
            {
                ExceptionManager.ExceptionControl(
                        ErrorCodes.IncompatibleOptions);
            }

            // No Search Exception
            if (boolArgs["-search-planet"] == false &&
                boolArgs["-search-star"] == false &&
                boolArgs["-star-info"] == false &&
                boolArgs["-planet-info"] == false) 
            {
                ShowHelp();
                ExceptionManager.ExceptionControl(ErrorCodes.NoSearchOption);
            }
        }

        /// <summary>
        /// Method that prints on the screen all the information needed to 
        /// use the program flawlessly
        /// </summary>
        private void ShowHelp()
        {
            Console.WriteLine(
                $"\nSEARCH OPTIONS\n\n" +

                $"File: -file\n" +
                $"Planet Information: -planet-info\n" +
                $"Star Information: -star-info\n" +
                $"Planet Search: -search-planet\n" +
                $"Star Search: -search-star\n\n" +

                $"PLANET OPTIONS \n\n" +

                $"(min = minimum) \n" +
                $"(max = maximum) \n\n" +

                $"Name: -planet-name\n" +
                $"Host Name (Star Name): -host-name\n" +
                $"Discovery Method: -disc-method\n" +
                $"Discovery Year: -disc-year-min or -disc-year-max\n" +
                $"Orbit Period: -planet-orbper-min or -planet-orbper-max\n" +
                $"Radius (vs Earth): -planet-rade-min or -planet-rade-max\n" +
                $"Mass (vs Earth): -planet-mass-min or -planet-mass-max\n" +
                $"Equilibrium Temperature: -planet-temp-min or -planet-temp-max\n\n" +

                $"STAR OPTIONS \n\n" +

                $"(min = minimum) \n" +
                $"(max = maximum) \n\n" +

                $"Star Name: -host-name\n" +
                $"Effective Temperature: -star-temp-min or -star-temp-max\n" + 
                $"Radius (vs Earth): -star-rade-min or -star-rade-max\n" + 
                $"Mass (vs Earth): -star-mass-min or -star-mass-max\n" + 
                $"Age: -star-age-min or -star-age-max\n" +
                $"Rotation Velocity: -star-vsin-min or -star-vsin-max\n" +
                $"Rotation Period: -star-rotp-min or -star-rotp-max\n" +
                $"Distance to Sun: -sy-dist-min or -sy-dist-max\n\n" +

                $"HELP OPTIONS\n\n" +

                $"Help: -help\n" +
                $"Example: -file \"NasaExoplanetSearcher.csv\" -planet-search" +
                $"-planet-name \"XO-4 b\" -host-name \"XO-4\" -planet-mass-min " +
                $"2500 -planet-mass 50000\n\n" +
                $"(WARNING: IN REPEATED ARGUMENTS, ONLY THE LAST ONE IS READ)\n\n");
        }
    }
}