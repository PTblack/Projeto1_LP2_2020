using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Projeto1_LP2
{
    class FileSearcher
    {
        Dictionary<string, bool> boolArgs;
        Dictionary<string, string> stringArgs;
        Dictionary<string, float> floatArgs;
        public HashSet<Planet> planetCollection {get; private set;}
        public HashSet<Star> starCollection{get; private set;}

        public FileSearcher(Dictionary<string, bool> boolArgs,  
            Dictionary<string, string> stringArgs, 
            Dictionary<string, float> floatArgs, 
            HashSet<Planet> planetCollection, HashSet<Star> starCollection)
        {
            this.boolArgs = boolArgs ;
            this.stringArgs = stringArgs;
            this.floatArgs = floatArgs;
            this.planetCollection = planetCollection;
            this.starCollection = starCollection;
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

        }
    }
}