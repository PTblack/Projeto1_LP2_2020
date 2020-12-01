using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto1_LP2
{
    public struct Planet
    {
        // Properties ordered as displayed in CSV file

        // Planet's Name
        public string Name { get; }
        
        // Host Star's name
        public string HostName { get; } 

        // Method of Discovery
        public string DiscoveryMethod { get; }
        
        // Year of Discovery
        public int DiscoveryYear { get; }

        // Orbit Period (days)
        public int OrbitPeriod { get; }

        // Planet's Radius compared to the Earth's Radius
        public float RadiusRatio { get; }

        // Planet's Mass compared to the Earth's Mass
        public float MassRatio { get; }

        // Planet's Equilibrium Temperature (unit: Kelvins)
        public int EqTemperature { get; }

        // Constructor Parameters ordered as displayed in CSV file
        public Planet(string name, string hostName, string disc_method, 
        int disc_year, int orbPer, float radiusRt, float massRT, int eqTemp)
        {
            Name = name;
            HostName = hostName;
            DiscoveryMethod = disc_method;
            DiscoveryYear = disc_year;
            OrbitPeriod = orbPer;
            RadiusRatio = radiusRt;
            MassRatio = massRT;
            EqTemperature = eqTemp;
        }
    }   
}
