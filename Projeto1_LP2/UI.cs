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
            AddToDictionary();
            Options();
            GetCollections();
        }

        private void Options()
        {
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
            CheckForArgumentExceptions();
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
                // Select from Planets in the filtered collection who's name is 
                // equal to the argument given by the user
                IEnumerable<Planet> planetEqualInfo = 
                    from planet in fs.FilteredPlanetCollection
                    where planet.Name.ToLower().Equals(
                        stringArgs["-planet-name"].ToLower())
                    select planet;

                // Check if there are any Planets with a name equal to the one 
                // given by the user
                if (planetEqualInfo.Count() >= 1)
                {
                    Planet finalPlanet = new Planet();
                    for (int i = 0; i < planetEqualInfo.Count(); i++)
                    {
                        finalPlanet = 
                            planetEqualInfo.ElementAt(0) + 
                            planetEqualInfo.ElementAt(i);
                    }

                    finalPlanet.ConvertFloatablesToDefault();

                    Console.WriteLine(finalPlanet.ToString(boolArgs["-csv"]));
                }
                else
                {
                    // Give the collection only with names that contain the 
                    // user's argument
                    foreach (Planet p in fs.FilteredPlanetCollection)
                    {
                        p.ConvertFloatablesToDefault();
                        Console.WriteLine(p.ToString(boolArgs["-csv"]));
                    }
                }
            }

            if (boolArgs["-search-star"] == true)
            {
                // Select from Stars in the filtered collection who's name is 
                // equal to the argument given by the user
                IEnumerable<Star> starEqualInfo = 
                    from star in fs.FilteredStarCollection
                    where star.StarName.ToLower().Equals(
                        stringArgs["-host-name"].ToLower())
                    select star;

                // Check if there are any Stars with a name equal to the one 
                // given by the user
                if (starEqualInfo.Count() >= 1)
                {
                    Star finalStar = new Star();
                    for (int i = 0; i < starEqualInfo.Count(); i++)
                    {
                        finalStar = 
                            starEqualInfo.ElementAt(0) + 
                            starEqualInfo.ElementAt(i);
                    }

                    finalStar.ConvertFloatablesToDefault();

                    Console.WriteLine(finalStar.ToString(boolArgs["-csv"]));

                    // Show number of Planets hosted by the Star named by 
                    // the user
                    Console.WriteLine("Number of Orbiting Planets: " +
                        starEqualInfo.Count());
                }
                else
                {
                    // Give the collection only with names that contain the 
                    // user's argument
                    foreach (Star s in fs.FilteredStarCollection)
                    {
                        s.ConvertFloatablesToDefault();
                        Console.WriteLine(s.ToString(boolArgs["-csv"]));
                    }
                }
            }
        }

        public void CheckForArgumentExceptions()
        {
            // 'IncompatibleOptions' Exception
            if(boolArgs["-search-planet"] && boolArgs["-search-star"])
            {
                ExceptionManager.ExceptionControl(
                        ErrorCodes.IncompatibleOptions);
            }

            // 'NoSearchOption' Exception
            if (!boolArgs["-search-planet"] && !boolArgs["-search-star"])
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
                $"Example:\n-file \"NasaExoplanetSearcher.csv\" -planet-search" +
                $"-planet-name \"XO-4 b\" -host-name \"XO-4\" -planet-mass-min " +
                $"2500 -planet-mass 50000\n\n" +
                $"(WARNING: IN REPEATED ARGUMENTS, ONLY THE LAST ONE IS READ)\n\n");
        }
    }
}