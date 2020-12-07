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
        public IEnumerable<Planet> FilteredPlanetCollection{get; private set;}
        public IEnumerable<Star> FilteredStarCollection{get; private set;}

        public FileSearcher(Dictionary<string, bool> boolArgs,  
            Dictionary<string, string> stringArgs, 
            Dictionary<string, float?> floatArgs, 
            HashSet<Planet> planetHashSet, HashSet<Star> starHashSet)
        {
            this.boolArgs = boolArgs ;
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
            if(boolArgs["-search-planet"] == true)
            {
                SearchPlanet();
            }
            else if(boolArgs["-search-star"] == true)
            {

            }
            else if(boolArgs["-planet-info"] == true)
            {
                PlanetInfo();
            }
            else if(boolArgs["-star-info"] == true)
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
            
            FilteredPlanetCollection = planetInfo;
        }

        private void StarInfo()
        {
            IEnumerable<Star> starInfo =
                from star in starHashSet
                where star.StarName == stringArgs["-host-name"]
                select star;

            FilteredStarCollection = starInfo;
        }

        private void SearchPlanet()
        {
            IEnumerable<Planet> planetInfo =
            from planet in planetHashSet
                /*where planet.Name.ToLower() == stringArgs["-planet-name"].ToLower();
            where planet.HostName.ToLower() == stringArgs["-host-name"].ToLower()
                && planet.DiscoveryMethod.ToLower() == stringArgs["-disc-method"].ToLower()*/
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
    }
}