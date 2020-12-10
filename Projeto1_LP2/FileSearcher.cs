﻿using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Globalization;

namespace Projeto1_LP2
{
    /// <summary>
    /// This class filters the file's collections 
    /// to match the user criteria
    /// </summary>
    class FileSearcher
    {
        // Collection that stores arguments of type boolean
        private Dictionary<string, bool> boolArgs;

        // Collection that stores arguments of type string
        private Dictionary<string, string> stringArgs;

        // Collection that stores arguments of type float
        private Dictionary<string, float?> floatArgs;

        // Collection where is stores all planets
        private HashSet<Planet> planetHashSet;

        // Collection where is stored all stars
        private HashSet<Star> starHashSet;

        // Properties with filtered planets and stars 
        public IEnumerable<Planet> FilteredPlanetCollection { get; private set; }
        public IEnumerable<Star> FilteredStarCollection { get; private set; }

        /// <summary>
        /// Constructor Method. Initializes all variables and collections
        /// </summary>
        /// <param name="boolArgs">Bools Collection</param>
        /// <param name="stringArgs">String Collection</param>
        /// <param name="floatArgs">Float Collection</param>
        /// <param name="planetHashSet">Collection with all Planets</param>
        /// <param name="starHashSet">Collection with all Stars</param>
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

            CompareInfoWithBoolArgs();
        }

        /// <summary>
        /// Checks which arguments where selected by the user
        /// for search
        /// </summary>
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
        }
        
        /// <summary>
        /// Includes the query for all the information that can be searched
        /// for a planet
        /// </summary>
        private void SearchPlanet()
        {
            // Collection planetInfo is given the Planets that fit the value 
            // intervals given by the user (that have attributes inside the 
            // numerical intervals set by the user)
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

            // Keeps only planets that contain in their "planet-name"
            // category a substring equal to the one given by the user
            if (stringArgs["-planet-name"] != "")
            {
                planetInfo = from planet in planetInfo
                            // the string given by the user is included in 
                            // the planet name
                            where planet.Name.ToLower().Contains(
                                stringArgs["-planet-name"].ToLower())
                            select planet;
            }
            // Keeps only planets that contain in their "host-name"
            // category a substring equal to the one given by the user
            if (stringArgs["-host-name"] != "")
            {
                planetInfo = from planet in planetInfo
                            // the string given by the user is included in 
                            // the host name
                            where planet.HostName.ToLower().Contains(
                                stringArgs["-host-name"].ToLower())
                            select planet;
            }
            // Keeps only Planets that contain in their "disc-method"
            // category a substring equal to the one given by the user
            if (stringArgs["-disc-method"] != "")
            {
                planetInfo = from planet in planetInfo
                            // the string given by the user is included in 
                            // the discovery method
                            where planet.DiscoveryMethod.ToLower().Contains(
                                stringArgs["-disc-method"].ToLower())
                            select planet;
            }

            FilteredPlanetCollection = planetInfo;

            // If no Planet matches the criteria given by the user, 
            // give exception
            if (FilteredPlanetCollection.Count() == 0)
                    ExceptionManager.ExceptionControl(ErrorCodes.NoDataFound);
        }
        
        /// <summary>
        /// Includes the query for all the information that can be searched
        /// for a Star
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

            // Keeps only Stars that contain in their "host-name"
            // category a substring equal to the one given by the user
            if (stringArgs["-host-name"] != "")
            {
                starInfo = from star in starInfo
                            // The string given by the user is included 
                            // in the Star's host name
                            where star.StarName.ToLower().Contains(
                                stringArgs["-host-name"].ToLower())
                            select star;
            }

            IEnumerable<Star> starEqualInfo =
            from star in starInfo
            where star.StarName.ToLower().Equals(
                    stringArgs["-host-name"].ToLower())
            select star;

            Star finalStar;

            if(starEqualInfo.Count() >= 1)
            {
                finalStar = starEqualInfo.First();
                for (int i = 0; i < starEqualInfo.Count(); i++)
                {
                    finalStar = 
                        finalStar + starEqualInfo.ElementAt(i);
                }

                FilteredStarCollection = starEqualInfo.Append(finalStar);
            }

            else FilteredStarCollection = starInfo;
            
            // Give the collection with names that Contain the
            // string inputted by the user
            FilteredStarCollection = starInfo;

            // If no Star matches the criteria given by the user, 
            // give exception
            if (FilteredStarCollection.Count() == 0)
                    ExceptionManager.ExceptionControl(ErrorCodes.NoDataFound);
        }

    }
}