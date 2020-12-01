using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace Projeto1_LP2
{
    public struct Star
    {
        // Properties ordered as displayed in CSV file 
        
        // Method of Discovery
        public string DiscoveryMethod { get; }
        
        // Year of Discovery
        public int DiscoveryYear { get; }

        // Effective Temperature (unit: Kelvins)
        public int EffectiveTemp { get; }

        // Star's radius compared to the Sun's radius
        public float RadiusRatio { get; }

        // Star's mass compared to the Sun's mass
        public float MassRatio { get; }

        // Age in Giga-years (unit: Gy)
        public int Age { get; }

        // Rotation Velocity (unit: km/s)
        public float RotationVel { get; }

        // Rotation Period (days)
        public int RotationPeriod { get; }

        // Distance bettween Star and Sun (unit: Parsecs)
        public float DistToSun { get; }

        // Constructor Parameters ordered as displayed in CSV file
        public Star(string disc_method, int disc_year, int effTemp, float radius, 
        float mass, int age, float rotVel, int rotPer, float distSun)
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
        }
    }
}
