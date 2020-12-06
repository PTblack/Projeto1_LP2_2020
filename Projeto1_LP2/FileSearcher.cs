using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Projeto1_LP2
{
    class FileSearcher
    {
        private Dictionary<string, bool> boolArgs;
        private Dictionary<string, string> stringArgs;
        private Dictionary<string, float> floatArgs;
        private HashSet<Planet> planetHashSet;
        private HashSet<Star> starHashSet;
        public IEnumerable<Planet> PlanetCollection{get; private set;}
        public IEnumerable<Star> StarCollection{get; private set;}

        public FileSearcher(Dictionary<string, bool> boolArgs,  
            Dictionary<string, string> stringArgs, 
            Dictionary<string, float> floatArgs, 
            HashSet<Planet> planetHashSet/*, HashSet<Star> starHashSet*/)
        {
            this.boolArgs = boolArgs ;
            this.stringArgs = stringArgs;
            this.floatArgs = floatArgs;
            this.planetHashSet = planetHashSet;
            //this.starHashSet = starHashSet;
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
                
            }
            if(boolArgs["-search-star"] == true)
            {

            }
            if(boolArgs["-planet-info"] == true)
            {
                PlanetInfo();
            }
            if(boolArgs["-star-info"] == true)
            {

            }
        }
        
        private void PlanetInfo()
        {
            IEnumerable<Planet> planetInfo = 
                from planet in planetHashSet 
                where planet.Name == stringArgs["-planet-name"] 
                && planet.HostName == stringArgs["-host-name"] select planet;
            
            PlanetCollection = planetInfo;
        }

        /*private void SearchPlanet()
        {
            IEnumerable<Planet> planetInfo = 
                from planet in planetHashSet 
                where planet. == stringArgs["-search-planet"] select planet;
            
            PlanetCollection = planetInfo;
        }

        private void StarInfo()
        {
            IEnumerable<Star> starInfo = 
                from star in starHashSet 
                where star. == stringArgs["-planet-name"] select star;
            
            StarCollection = starInfo;
        }*/
    }
}