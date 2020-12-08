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

        // Star Name
        public string StarName { get; private set;}

        // Effective Temperature (unit: Kelvins)
        public string EffectiveTemp { get; private set;}

        // Star's radius compared to the Sun's radius
        public string RadiusRatio { get; private set;}

        // Star's mass compared to the Sun's mass
        public string MassRatio { get; private set;}

        // Age in Giga-years (unit: Gy)
        public string Age { get; private set;}
            
        // Rotation Velocity (unit: km/s)
        public string RotationVel { get; private set;}

        // Rotation Period (days)
        public string RotationPeriod { get; private set;}

        // Distance bettween Star and Sun (unit: Parsecs)
        public string DistToSun { get; private set;}

        // Constructor Parameters ordered as displayed in CSV file
        public Star(string namePL, string starName, string effTemp, 
                    string radius, string mass, string age, string rotVel, 
                    string rotPer, string distSun)
        {
            StarName = starName;
            EffectiveTemp = effTemp;
            RadiusRatio = radius;
            MassRatio = mass;
            Age = age;
            RotationVel = rotVel;
            RotationPeriod = rotPer;
            DistToSun = distSun;

            myPlanets = new HashSet<string>();
          
            myPlanets.Add(namePL);
        }

        // Returns string with the Star's Values in format determined by User
        public string ToString(bool csv)
        {
            if (csv)
            {
                // Return values in CSV format
                return myPlanets.Count + "," + StarName + "," + EffectiveTemp + "," + 
                RadiusRatio + "," + MassRatio + "," + Age + "," + 
                RotationVel + "," + RotationPeriod + "," + DistToSun;
            }
            else
            {
                return
                "STAR VALUES\n\n" +
                $"Planets: {myPlanets.Count}\n" +
                $"Name: {StarName}\n" +
                $"Effective Temperature: {EffectiveTemp} kelvin\n" + 
                $"Radius (vs Earth): {RadiusRatio}\n" + 
                $"Mass (vs Earth): {MassRatio}\n" + 
                $"Age: {Age} giga-years\n" +
                $"Rotation Velocity: {RotationVel} km/h\n" +
                $"Rotation Period: {RotationPeriod} days\n" +
                $"Distance to Sun: {DistToSun} parsecs\n";
            }
        }

        public void ConvertDefaultToFloat()
        {
            if(EffectiveTemp == "[MISSING]") EffectiveTemp = "0";
            if(RadiusRatio == "[MISSING]") RadiusRatio = "0";
            if(MassRatio == "[MISSING]") MassRatio = "0";
            if(Age == "[MISSING]") Age = "0";
            if(RotationVel == "[MISSING]") RotationVel = "0";
            if(RotationPeriod == "[MISSING]") RotationPeriod = "0";
            if(DistToSun == "[MISSING]") DistToSun = "0";
        }

        public void ConvertFloatablesToDefault()
        {
            if(EffectiveTemp == "0") EffectiveTemp = "[MISSING]";
            if(RadiusRatio == "0") RadiusRatio = "[MISSING]";
            if(MassRatio == "0") MassRatio = "[MISSING]";
            if(Age == "0") Age = "[MISSING]";
            if(RotationVel == "0") RotationVel = "[MISSING]";
            if(RotationPeriod == "0") RotationPeriod = "[MISSING]";
            if(DistToSun == "0") DistToSun = "[MISSING]";
        }

        public static Star operator +(Star star1, Star star2)
        {
            if(star1.StarName == "[MISSING]") 
                star1.StarName = star2.StarName;
            if(star1.EffectiveTemp == "[MISSING]") 
                star1.EffectiveTemp = star2.EffectiveTemp;
            if(star1.RadiusRatio == "[MISSING]") 
                star1.RadiusRatio = star2.RadiusRatio;
            if(star1.MassRatio == "[MISSING]") 
                star1.MassRatio = star2.MassRatio;
            if(star1.Age == "[MISSING]") 
                star1.Age = star2.Age;
            if(star1.RotationVel == "[MISSING]") 
                star1.RotationVel = star2.RotationVel;
            if(star1.RotationPeriod == "[MISSING]") 
                star1.RotationPeriod = star2.RotationPeriod;
            if(star1.DistToSun == "[MISSING]") 
                star1.DistToSun = star2.DistToSun;

            return star1;
        }
    }
}