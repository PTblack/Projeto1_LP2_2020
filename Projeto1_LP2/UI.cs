﻿using System;
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

        private HashSet<Planet> planetCollection;

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

            boolArgs.Add("-search-planet", false);
            boolArgs.Add("-search-star", false);
            boolArgs.Add("-planet-info", false);
            boolArgs.Add("-star-info", false);

            stringArgs.Add("-file", "");
            stringArgs.Add("-planet-name", "");
            stringArgs.Add("-star-name", "");
            stringArgs.Add("-host-name", "");

            floatArgs.Add("-star-temp-min", 0);
            floatArgs.Add("-star-temp", 0);
            floatArgs.Add("-planet-temp-min", 0);
            floatArgs.Add("-planet-temp", 0);

            floatArgs.Add("-star-rade-min", 0);
            floatArgs.Add("-star-rade", 0);
            floatArgs.Add("-planet-rade-min", 0);
            floatArgs.Add("-planet-rade", 0);

            floatArgs.Add("-star-mass-min", 0);
            floatArgs.Add("-star-mass", 0);
            floatArgs.Add("-planet-mass-min", 0);
            floatArgs.Add("-planet-mass", 0);
            
            floatArgs.Add("-star-vsin-min", 0);
            floatArgs.Add("-star-vsin", 0);

            floatArgs.Add("-star-rotp-min", 0);
            floatArgs.Add("-star-rotp", 0);

            floatArgs.Add("-star-age-min", 0);
            floatArgs.Add("--star-age", 0);

            floatArgs.Add("-planet-orbper-min", 0);
            floatArgs.Add("-planet-orbper", 0);

            floatArgs.Add("-disc-year", 0);
            floatArgs.Add("-disc-method", 0);

            floatArgs.Add("-sy-dist", 0);
        }
        public void Show()
        {
            Options();
            fm = new FileManager(stringArgs["-file"]);
            planetCollection = fm.ReturnPlanet();
            fs = new FileSearcher(boolArgs,  stringArgs, floatArgs, 
                planetCollection);
            foreach (Planet p in fs.PlanetCollection)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", p.Name,
                    p.HostName, p.DiscoveryMethod, p.DiscoveryYear,
                    p.OrbitPeriod, p.RadiusRatio, p.MassRatio,
                    p.EqTemperature);
            }               
        }
    }
}