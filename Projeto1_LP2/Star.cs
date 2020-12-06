using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace Projeto1_LP2
{
    public struct Star
    {
        // Properties ordered as displayed in CSV file 

        public HashSet<string> myPlanets;
        // Method of Discovery
        public string DiscoveryMethod { get; }
        
        // Year of Discovery
        public string DiscoveryYear { get; }

        // Effective Temperature (unit: Kelvins)
        public string EffectiveTemp { get; }

        // Star's radius compared to the Sun's radius
        public string RadiusRatio { get; }

        // Star's mass compared to the Sun's mass
        public string MassRatio { get; }

        // Age in Giga-years (unit: Gy)
        public string Age { get; }

        // Rotation Velocity (unit: km/s)
        public string RotationVel { get; }

        // Rotation Period (days)
        public string RotationPeriod { get; }

        // Distance bettween Star and Sun (unit: Parsecs)
        public string DistToSun { get; }

        // Constructor Parameters ordered as displayed in CSV file
        public Star(string nomePL, string disc_method, string disc_year, string effTemp, 
        string radius, string mass, string age, string rotVel, string rotPer, 
        string distSun)
        {
            DiscoveryMethod = disc_method;
            DiscoveryYear = disc_year;
            EffectiveTemp = effTemp;
            RadiusRatio = radius;
            MassRatio = mass;
            Age = age;
            RotationVel = rotVel;
            RotationPeriod = rotPer;
            DistToSun = distSun;

            myPlanets = new HashSet<string>();
            myPlanets.Add(nomePL);
        }

        // Returns string with the Star's Values in format determined by User
        public string ToString(bool csv)
        {
            if (csv)
            {
                // Return values in CSV format
                return DiscoveryMethod + "," + DiscoveryYear + "," + 
                EffectiveTemp + "," + RadiusRatio + "," + MassRatio + "," + 
                Age + "," + RotationVel + "," + RotationPeriod + "," + 
                DistToSun;
            }
            else
            {
                return
                "STAR VALUES/n/n" +
                $"Discovery Method: {DiscoveryMethod}/n" + 
                $"Discovery Year: {DiscoveryYear}/n" +
                $"Effective Temperature: {EffectiveTemp} kelvin/n" + 
                $"Radius (vs Earth): {RadiusRatio}/n" + 
                $"Mass (vs Earth): {MassRatio}/n" + 
                $"Age: {Age} giga-years/n" +
                $"Rotation Velocity: {RotationVel} km/h/n" +
                $"Rotation Period: {RotationPeriod} days/n" +
                $"Distance to Sun: {DistToSun} parsecs";
            }
        }
    }
}