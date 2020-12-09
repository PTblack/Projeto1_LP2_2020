using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Globalization;

namespace Projeto1_LP2
{
    class FileSearcher
    {
        private Dictionary<string, bool> boolArgs;
        private Dictionary<string, string> stringArgs;
        private Dictionary<string, float?> floatArgs;

        private HashSet<Planet> planetHashSet;
        private HashSet<Star> starHashSet;

        // Star that holds the final values for a star-info action
        private Star finalStar = new Star();

        public IEnumerable<Planet> FilteredPlanetCollection { get; private set; }
        public IEnumerable<Star> FilteredStarCollection { get; private set; }
        
        // Gives value of private finalStar variable
        public Star ReturnFinalStar(){return finalStar;}

        public FileSearcher(Dictionary<string, bool> boolArgs,
            Dictionary<string, string> stringArgs,
            Dictionary<string, float?> floatArgs,
            HashSet<Planet> planetHashSet, HashSet<Star> starHashSet)
        {
            this.boolArgs = boolArgs;
            this.stringArgs = stringArgs;
            this.floatArgs = floatArgs;
            this.planetHashSet = planetHashSet;
            this.starHashSet = starHashSet;

            foreach (Planet p in planetHashSet)
                p.ConvertDefaultToFloat();

            foreach (Star s in starHashSet)
                s.ConvertDefaultToFloat();

            CompareInfoWithBoolArgs();
        }

        // get the information chosen by the user on argument

        // Create a collection with the args inputted by the user

        // Check what the user chose and compare it with the file on filemanager
        // print
        private void CompareInfoWithBoolArgs()
        {
            if (boolArgs["-search-planet"] == true)
            {
                SearchPlanet();
            }
            else if (boolArgs["-search-star"] == true)
            {
                SearchStar();
            }
            else if (boolArgs["-planet-info"] == true)
            {
                PlanetInfo();
            }
            else if (boolArgs["-star-info"] == true)
            {
                StarInfo();
            }
        }

        private void PlanetInfo()
        {
            IEnumerable<Planet> planetInfo =
                from planet in planetHashSet
                where planet.Name.ToLower() == 
                    stringArgs["-planet-name"].ToLower()
                    && planet.HostName.ToLower() == 
                    stringArgs["-host-name"].ToLower()
                select planet;

            /* HashSet<Planet> fixedPlanets = new HashSet<Planet>();
             if (planetInfo.Count() >= 0)
             {
                 fixedPlanets = new HashSet<Planet>();
                 for (int i = planetInfo.Count() - 1; i > 0; i--)
                 {
                     Planet planet1 =
                         planetInfo.ElementAt(i) + planetInfo.ElementAt(i - 1);

                     fixedPlanets.Add(planet1);  
                 }
                 Console.WriteLine(fixedPlanets);
             }*/

            foreach (Planet p in planetInfo)
                p.ConvertFloatablesToDefault();

            FilteredPlanetCollection = planetInfo;
        }

        /// <summary>
        /// Finds Star that matches the arguments given by the user
        /// </summary>
        private void StarInfo()
        {
            // Create collection with Stars that have the same name as the one 
            // given by the user
            IEnumerable<Star> starInfo =
                from star in starHashSet
                where star.StarName.ToLower().Trim() == 
                        stringArgs["-host-name"].ToLower()
                select star;

            // Star that will hold the Final values for the searched Star
            // Star finalStar = new Star();

            // For every Star with the same name as the one given by the user...
            for (int i = 0; i < starInfo.Count(); i++)
            {
                // For first time, make finalStar have same values as a Star 
                // in the starInfo collection
                if (i == 0) finalStar = starInfo.ElementAt(i);
                else finalStar = finalStar + starInfo.ElementAt(i);
            }
        }

        /// <summary>
        /// Search for Planets that fit the criteria chosen by the user
        /// </summary>
        private void SearchPlanet()
        {
            /*
            POR ISTO DE MODO A CONFIRMAR QUE TUDO ESTA COM NUMEROS?
            foreach (Planet p in planetHashSet)
                p.ConvertDefaultToFloat();
            */

            // Collection planetInfo is given the Planets that fit the value 
            // intervals given by the user
            IEnumerable<Planet> planetInfo =
            from planet in planetHashSet
            where Single.Parse(planet.EqTemperature, NumberStyles.Any, 
            CultureInfo.InvariantCulture) >= floatArgs["-planet-temp-min"]
                && Single.Parse(planet.EqTemperature, NumberStyles.Any, 
                CultureInfo.InvariantCulture) <= floatArgs["-planet-temp-max"]

                && Single.Parse(planet.MassRatio, NumberStyles.Any, 
                CultureInfo.InvariantCulture) >= floatArgs["-planet-mass-min"]
                && Single.Parse(planet.MassRatio, NumberStyles.Any, 
                CultureInfo.InvariantCulture) <= floatArgs["-planet-mass-max"]

                && Single.Parse(planet.RadiusRatio, NumberStyles.Any, 
                CultureInfo.InvariantCulture) >= floatArgs["-planet-rade-min"]
                && Single.Parse(planet.RadiusRatio, NumberStyles.Any, 
                CultureInfo.InvariantCulture) <= floatArgs["-planet-rade-max"]

                && Single.Parse(planet.OrbitPeriod, NumberStyles.Any, 
                CultureInfo.InvariantCulture) >= floatArgs["-planet-orbper-min"]
                && Single.Parse(planet.OrbitPeriod, NumberStyles.Any, 
                CultureInfo.InvariantCulture) <= floatArgs["-planet-orbper-max"]

                && Single.Parse(planet.DiscoveryYear, NumberStyles.Any, 
                CultureInfo.InvariantCulture) >= floatArgs["-disc-year-min"]
                && Single.Parse(planet.DiscoveryYear, NumberStyles.Any, 
                CultureInfo.InvariantCulture) <= floatArgs["-disc-year-max"]
            select planet;

            /*
            POR ISTO DE MODO A CONFIRMAR QUE TUDO ESTA COM [MISSING]]?
            foreach (Planet p in planetInfo)
                p.ConvertFloatablesToDefault();
            */
            // In planetInfo, keep Planets with the name given by the user
            // ESTA CONDIÇÃO É - EM TEORIA - DESNECESSÁRIA
            if (stringArgs["-planet-name"] != "[MISSING]")
            {
                planetInfo = from planet in planetInfo
                             where planet.Name.ToLower() == 
                                    stringArgs["-planet-name"].ToLower() 
                             select planet;
            }
            // In planetInfo, keep Planets with Stars that have the name given 
            // by the user in the arguments
            // ESTA CONDIÇÃO É - EM TEORIA - DESNECESSÁRIA
            if (stringArgs["-host-name"] != "[MISSING]")
            {
                planetInfo = from planet in planetInfo
                             where planet.HostName.ToLower() == 
                                    stringArgs["-host-name"].ToLower()
                             select planet;
            }
            // In planetInfo, keep Planets with the Discovery Method given 
            // by the user
            if (stringArgs["-disc-method"] != "[MISSING]")
            {
                planetInfo = from planet in planetInfo
                             where planet.DiscoveryMethod.ToLower() == 
                                    stringArgs["-disc-method"].ToLower()
                             select planet;
            }

            // ISTO NÃO DEVERIA ESTAR ATRÁS DESTAS TRÊS CONDIÇÕES?
            foreach (Planet p in planetInfo)
                p.ConvertFloatablesToDefault();

            FilteredPlanetCollection = planetInfo;
        }

        /// <summary>
        /// Search for Stars that fit the criteria chosen by the user
        /// </summary>
        public void SearchStar()
        {
            IEnumerable<Star> starInfo =
            from star in starHashSet
            where Single.Parse(star.EffectiveTemp, NumberStyles.Any,
                CultureInfo.InvariantCulture) >= floatArgs["-star-temp-min"]
                && Single.Parse(star.EffectiveTemp, NumberStyles.Any,
                CultureInfo.InvariantCulture) <= floatArgs["-star-temp-max"]

                && Single.Parse(star.MassRatio, NumberStyles.Any,
                CultureInfo.InvariantCulture) >= floatArgs["-star-mass-min"]
                && Single.Parse(star.MassRatio, NumberStyles.Any,
                CultureInfo.InvariantCulture) <= floatArgs["-star-mass-max"]

                && Single.Parse(star.RadiusRatio, NumberStyles.Any,
                CultureInfo.InvariantCulture) >= floatArgs["-star-rade-min"]
                && Single.Parse(star.RadiusRatio, NumberStyles.Any,
                CultureInfo.InvariantCulture) <= floatArgs["-star-rade-max"]

                && Single.Parse(star.RotationPeriod, NumberStyles.Any,
                CultureInfo.InvariantCulture) >= floatArgs["-star-rotp-min"]
                && Single.Parse(star.RotationPeriod, NumberStyles.Any,
                CultureInfo.InvariantCulture) <= floatArgs["-star-rotp-max"]

                && Single.Parse(star.RotationVel, NumberStyles.Any,
                CultureInfo.InvariantCulture) >= floatArgs["-star-vsin-min"]
                && Single.Parse(star.RotationVel, NumberStyles.Any,
                CultureInfo.InvariantCulture) <= floatArgs["-star-vsin-max"]

                && Single.Parse(star.Age, NumberStyles.Any,
                CultureInfo.InvariantCulture) >= floatArgs["-star-age-min"]
                && Single.Parse(star.Age, NumberStyles.Any,
                CultureInfo.InvariantCulture) <= floatArgs["-star-age-max"]
            select star;

            if (stringArgs["-host-name"] != "[MISSING]")
            {
                starInfo = from star in starInfo
                             where star.StarName.ToLower() == 
                                    stringArgs["-host-name"].ToLower()
                             select star;
            }

            foreach (Star s in starInfo)
                s.ConvertFloatablesToDefault();

            FilteredStarCollection = starInfo;
        }
    }
}

