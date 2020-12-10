using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto1_LP2
{
    /// <summary>
    /// This struct saves the Planet's properties
    /// </summary>
    public struct Planet
    {        
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

        /// <summary>
        /// Planet struct constructor
        /// </summary>
        /// <param name="name">Planet's Name</param>
        /// <param name="hostName">Planet's Star Name</param>
        /// <param name="disc_method">Discovery Method</param>
        /// <param name="disc_year">Discovery Year</param>
        /// <param name="orbPer">Planet's Orbital Period</param>
        /// <param name="radiusRt">Planet's Radius compared to the Earth</param>
        /// <param name="massRt">Planet's Mass compared to the Earth</param>
        /// <param name="eqTemp">Planet's Equilibrium Temperature</param>

        public Planet(string name, string hostName, string disc_method,
                      string disc_year, string orbPer, string radiusRt, 
                      string massRt, string eqTemp)
        {   
            Name = name;
            HostName = hostName;
            DiscoveryMethod = disc_method;
            DiscoveryYear = disc_year;
            OrbitPeriod = orbPer;
            RadiusRatio = radiusRt;
            MassRatio = massRt;
            EqTemperature = eqTemp;
        }

        /// <summary>
        /// Returns string with the Planet's values in the format determined by 
        /// the user
        /// </summary>
        /// <param name="csv">bool to check if the user wants the information 
        /// to be printed in a csv format</param>
        /// <returns>string containing the Planet's attributes</returns>
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

        /// <summary>
        /// Converts default values back to their 'Missing' designation
        /// </summary>
        public void ConvertFloatablesToDefault()
        {
            if(DiscoveryYear == "0") DiscoveryYear = "[MISSING]";
            if(OrbitPeriod == "0") OrbitPeriod = "[MISSING]";
            if(RadiusRatio == "0") RadiusRatio = "[MISSING]";
            if(MassRatio == "0") MassRatio = "[MISSING]";
            if(EqTemperature == "0") EqTemperature = "[MISSING]";
        }

        /// <summary>
        /// Definition of '+' operator for Planet additions, used to combine 
        /// information from different entries of the same Planet to provide
        /// the most information possible of said Planet
        /// </summary>
        /// <param name="planet1">"Current" Planet info</param>
        /// <param name="planet2">Different entry of the same Planet</param>
        /// <returns>Planet with updated values</returns>
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