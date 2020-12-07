using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Projeto1_LP2
{
    class FileSearcher
    {
        private Dictionary<string, bool> boolArgs;
        private Dictionary<string, string> stringArgs;
        private Dictionary<string, float?> floatArgs;

        private HashSet<Planet> planetHashSet;
        private HashSet<Star> starHashSet;

        public IEnumerable<Planet> FilteredPlanetCollection { get; private set; }
        public IEnumerable<Star> FilteredStarCollection { get; private set; }

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

        // get the information chosen by the user on argument

        // Create a collection with the args inputed by the user

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
                where planet.Name.ToLower() == stringArgs["-planet-name"].ToLower()
                    && planet.HostName.ToLower() == stringArgs["-host-name"].ToLower()
                select planet;

            HashSet<Planet> fixedPlanets = new HashSet<Planet>();
            if (planetInfo.Count() >= 1)
            {
                fixedPlanets = new HashSet<Planet>();
                for (int i = planetInfo.Count() - 1; i > 0; i--)
                {
                    Planet planet1 =
                        planetInfo.ElementAt(i) + planetInfo.ElementAt(i - 1);

                    fixedPlanets.Add(planet1);
                }
                Console.WriteLine(fixedPlanets);
            }

            FilteredPlanetCollection = fixedPlanets;
        }

        private void StarInfo()
        {
            IEnumerable<Star> starInfo =
                from star in starHashSet
                where star.StarName.ToLower() == stringArgs["-host-name"].ToLower()
                select star;

            HashSet<Star> fixedStars = new HashSet<Star>();
            if (starInfo.Count() >= 1)
            {
                fixedStars = new HashSet<Star>();
                for (int i = starInfo.Count() - 1; i > 0; i--)
                {
                    Star star1 =
                        starInfo.ElementAt(i) + starInfo.ElementAt(i - 1);
                    fixedStars.Add(star1);
                }
                Console.WriteLine(fixedStars);
            }

            FilteredStarCollection = fixedStars;
        }

        private void SearchPlanet()
        {
            IEnumerable<Planet> planetInfo =
            from planet in planetHashSet
            where Single.Parse(planet.EqTemperature) >= floatArgs["-planet-temp-min"]
                && Single.Parse(planet.EqTemperature) <= floatArgs["-planet-temp-max"]
                && Single.Parse(planet.MassRatio) >= floatArgs["-planet-mass-min"]
                && Single.Parse(planet.MassRatio) <= floatArgs["-planet-mass-max"]
                && Single.Parse(planet.RadiusRatio) >= floatArgs["-planet-rade-min"]
                && Single.Parse(planet.RadiusRatio) <= floatArgs["-planet-rade-max"]
                && Single.Parse(planet.OrbitPeriod) >= floatArgs["-planet-orbper-min"]
                && Single.Parse(planet.OrbitPeriod) <= floatArgs["-planet-orbper-max"]
                && Single.Parse(planet.DiscoveryYear) >= floatArgs["-disc-year-min"]
                && Single.Parse(planet.DiscoveryYear) <= floatArgs["-disc-year-max"]
            select planet;

            if (stringArgs["-planet-name"] != "[MISSING]")
            {
                planetInfo = from planet in planetInfo
                             where planet.Name.ToLower() == stringArgs["-planet-name"].ToLower() 
                             select planet;
            }
            if (stringArgs["-host-name"] != "[MISSING]")
            {
                planetInfo = from planet in planetInfo
                             where planet.HostName.ToLower() == stringArgs["-host-name"].ToLower()
                             select planet;
            }
            if (stringArgs["-disc-method"] != "[MISSING]")
            {
                planetInfo = from planet in planetInfo
                             where planet.DiscoveryMethod.ToLower() == stringArgs["-disc-method"].ToLower()
                             select planet;
            }

            FilteredPlanetCollection = planetInfo;
        }

        public void SearchStar()
        {
            IEnumerable<Star> starInfo =
            from star in starHashSet
            where Single.Parse(star.EffectiveTemp) >= floatArgs["-star-temp-min"]
                && Single.Parse(star.EffectiveTemp) <= floatArgs["-star-temp-max"]
                && Single.Parse(star.MassRatio) >= floatArgs["-star-mass-min"]
                && Single.Parse(star.MassRatio) <= floatArgs["-star-mass-max"]
                && Single.Parse(star.RadiusRatio) >= floatArgs["-star-rade-min"]
                && Single.Parse(star.RadiusRatio) <= floatArgs["-star-rade-max"]
                && Single.Parse(star.RotationPeriod) >= floatArgs["-star-rotp-min"]
                && Single.Parse(star.RotationPeriod) <= floatArgs["-star-rotp-max"]
                && Single.Parse(star.RotationVel) >= floatArgs["-star-vsin-min"]
                && Single.Parse(star.RotationVel) <= floatArgs["-star-vsin-max"]
                && Single.Parse(star.Age) >= floatArgs["-star-age-min"]
                && Single.Parse(star.Age) <= floatArgs["-star-age-max"]
            select star;

            if (stringArgs["-host-name"] != "[MISSING]")
            {
                starInfo = from star in starInfo
                             where star.StarName.ToLower() == stringArgs["-host-name"].ToLower()
                             select star;
            }
        }
    }
}

