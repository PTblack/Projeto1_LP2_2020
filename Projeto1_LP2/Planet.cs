using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto1_LP2
{
    public struct Planet
    {        
        //Star myStar;

        // Properties ordered as displayed in the CSV file

        // Planet's Name
        public string Name { get; private set;}
        
        // Host Star's name
        public string HostName { get; private set;} 

        // Method of Discovery
        public string DiscoveryMethod { get; private set;}
        
        // Year of Discovery
        public string DiscoveryYear { get; private set;}

        // Orbit Period (days)
        public string OrbitPeriod { get; private set;}

        // Planet's Radius compared to the Earth's Radius
        public string RadiusRatio { get; private set;}

        // Planet's Mass compared to the Earth's Mass
        public string MassRatio { get; private set;}

        // Planet's Equilibrium Temperature (unit: Kelvins)
        public string EqTemperature { get; private set;}

        // Constructor Parameters ordered as displayed in CSV file
        public Planet(string name, string hostName, string disc_method,
                      string disc_year, string orbPer, string radiusRt, 
                      string massRT, string eqTemp)
        {   
            //myStar = star;
            Name = name;
            HostName = hostName;
            DiscoveryMethod = disc_method;
            DiscoveryYear = disc_year;
            OrbitPeriod = orbPer;
            RadiusRatio = radiusRt;
            MassRatio = massRT;
            EqTemperature = eqTemp;

            ConvertDefaultToFloat();

            // Adds planet instance to the collection of its host star
            //myStar.myPlanetas.Add(this);
        }

        // Returns string with the Planet's Values in format determined by User
        public string ToString(bool csv)
        {
            if (csv)
            {
                // Return values in CSV format
                return Name + "," + HostName + "," + 
                DiscoveryMethod + "," + DiscoveryYear + "," + 
                OrbitPeriod + "," + RadiusRatio + "," + 
                MassRatio + "," + EqTemperature;
            }
            else
            {
                return
                "PLANET VALUES\n\n" +
                $"Name: {Name}\n" + 
                $"Host Star: {HostName}\n" +
                $"Discovery Method: {DiscoveryMethod}\n" + 
                $"Discovery Year: {DiscoveryYear}\n" + 
                $"Orbit Period: {OrbitPeriod} days\n" + 
                $"Radius (vs Earth): {RadiusRatio}\n" +
                $"Mass (vs Earth): {MassRatio}\n" +
                $"Equilibrium Temperature: {EqTemperature} kelvin\n";
            }
        }

        private void ConvertDefaultToFloat()
        {
            if(DiscoveryYear == "[MISSING]") DiscoveryYear = "0";
            if(OrbitPeriod == "[MISSING]") OrbitPeriod = "0";
            if(RadiusRatio == "[MISSING]") RadiusRatio = "0";
            if(MassRatio == "[MISSING]") MassRatio = "0";
            if(EqTemperature == "[MISSING]") EqTemperature = "0";
        }

        public void ConvertFloatablesToDefault()
        {
            if(DiscoveryYear == "0") DiscoveryYear = "[MISSING]";
            if(OrbitPeriod == "0") OrbitPeriod = "[MISSING]";
            if(RadiusRatio == "0") RadiusRatio = "[MISSING]";
            if(MassRatio == "0") MassRatio = "[MISSING]";
            if(EqTemperature == "0") EqTemperature = "[MISSING]";
        }

        public static Planet operator +(Planet planet1, Planet planet2)
        {
            if(planet1.Name == "[MISSING]") 
                planet1.Name = planet2.Name;
            if(planet1.HostName == "[MISSING]") 
                planet1.HostName = planet2.HostName;
            if(planet1.DiscoveryMethod == "[MISSING]") 
                planet1.DiscoveryMethod = planet2.DiscoveryMethod;
            if(planet1.DiscoveryYear == "[MISSING]") 
                planet1.DiscoveryYear = planet2.DiscoveryYear;
            if(planet1.OrbitPeriod == "[MISSING]") 
                planet1.OrbitPeriod = planet2.OrbitPeriod;
            if(planet1.RadiusRatio == "[MISSING]") 
                planet1.RadiusRatio = planet2.RadiusRatio;
            if(planet1.MassRatio == "[MISSING]") 
                planet1.MassRatio = planet2.MassRatio;
            if(planet1.EqTemperature == "[MISSING]") 
                planet1.EqTemperature = planet2.EqTemperature;

            return planet1;
        }
    }   
}