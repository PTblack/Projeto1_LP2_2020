using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        private Dictionary<string, float> floatArgs;

        private HashSet<Planet> PlanetCollection;

        private FileManager fm;
        private FileSearcher fs;

        public UI(string[] a)
        {
            args = a;
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
                    floatArgs[args[i]] = Single.Parse(args[i + 1]);
            }
        }
        
        private void AddToDictionary()
        {
            boolArgs = new Dictionary<string, bool>();
            stringArgs =new Dictionary<string, string>();
            floatArgs =new Dictionary<string, float>();

            // Search Criteria
            boolArgs.Add("-search-planet", false);
            boolArgs.Add("-search-star", false);
            boolArgs.Add("-planet-info", false);
            boolArgs.Add("-star-info", false);

            // Names
            stringArgs.Add("-file", "");
            stringArgs.Add("-planet-name", "");
            stringArgs.Add("-star-name", "");
            stringArgs.Add("-host-name", "");

            // Temperature
            floatArgs.Add("-star-temp-min", 0);
            floatArgs.Add("-star-temp", 0);
            floatArgs.Add("-planet-temp-min", 0);
            floatArgs.Add("-planet-temp", 0);

            // Radius
            floatArgs.Add("-star-rade-min", 0);
            floatArgs.Add("-star-rade", 0);
            floatArgs.Add("-planet-rade-min", 0);
            floatArgs.Add("-planet-rade", 0);

            // Mass
            floatArgs.Add("-star-mass-min", 0);
            floatArgs.Add("-star-mass", 0);
            floatArgs.Add("-planet-mass-min", 0);
            floatArgs.Add("-planet-mass", 0);
            
            // Rotation Velocity
            floatArgs.Add("-star-vsin-min", 0);
            floatArgs.Add("-star-vsin", 0);

            // Rotation Period
            floatArgs.Add("-star-rotp-min", 0);
            floatArgs.Add("-star-rotp", 0);

            // Star Age
            floatArgs.Add("-star-age-min", 0);
            floatArgs.Add("--star-age", 0);

            // Planet Orbital Period
            floatArgs.Add("-planet-orbper-min", 0);
            floatArgs.Add("-planet-orbper", 0);

            // Discovery Specs
            floatArgs.Add("-disc-year", 0);
            floatArgs.Add("-disc-method", 0);

            // Star Distance to Sun
            floatArgs.Add("-sy-dist", 0);
        }

        // PASSAR PARA CLASSE DE UI NOVA QUE FOR CRIADA
        // Show collection of planets that fit the user's requests
        public void ShowPlCollection()
        {
            Options();
            fm = new FileManager(stringArgs["-file"]);
            fs = new FileSearcher();
            PlanetCollection = fm.ReturnPlanet();
            foreach (Planet p in PlanetCollection)
            {
                Console.WriteLine(
                    "{0} / {1} / {2} / {3} / {4:f4} / {5:f4} / {6:f4} / {7:f4}", 
                    p.Name, p.HostName, p.DiscoveryMethod, p.DiscoveryYear,
                    p.OrbitPeriod, p.RadiusRatio, p.MassRatio, p.EqTemperature);
            }               
        }
    }
}
