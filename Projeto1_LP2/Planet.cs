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
        public string Name { get; }
        
        // Host Star's name
        public string HostName { get; } 

        // Method of Discovery
        public string DiscoveryMethod { get; }
        
        // Year of Discovery
        public string DiscoveryYear { get; }

        // Orbit Period (days)
        public string OrbitPeriod { get; }

        // Planet's Radius compared to the Earth's Radius
        public string RadiusRatio { get; }

        // Planet's Mass compared to the Earth's Mass
        public string MassRatio { get; }

        // Planet's Equilibrium Temperature (unit: Kelvins)
        public string EqTemperature { get; }

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
    }   
}
