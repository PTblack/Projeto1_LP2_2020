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

        // Planet Name
        public string NamePL { get; set; }

        // Star Name
        public string StarName { get;  set;}

        // Effective Temperature (unit: Kelvins)
        public string EffectiveTemp { get;  set;}

        // Star's radius compared to the Sun's radius
        public string RadiusRatio { get;  set;}

        // Star's mass compared to the Sun's mass
        public string MassRatio { get;  set;}

        // Age in Giga-years (unit: Gy)
        public string Age { get;  set;}
            
        // Rotation Velocity (unit: km/s)
        public string RotationVel { get;  set;}

        // Rotation Period (days)
        public string RotationPeriod { get;  set;}

        // Distance bettween Star and Sun (unit: Parsecs)
        public string DistToSun { get;  set;}

        /// <summary>
        /// Star struct constructor
        /// </summary>
        /// <param name="namePL">Planet identified in the Star's csv 
        /// line</param>
        /// <param name="starName">Star's Name</param>
        /// <param name="effTemp">Star's Effective Temperature</param>
        /// <param name="radius">Star's Radius compared to the Sun's</param>
        /// <param name="mass">Star's Mass compared to the Sun's</param>
        /// <param name="age">Star's Age</param>
        /// <param name="rotVel">Star's Rotation Velocity</param>
        /// <param name="rotPer">Star's Rotation Period</param>
        /// <param name="distSun">Star's distance to the Sun</param>
        public Star(string namePL, string starName, string effTemp, 
                    string radius, string mass, string age, string rotVel, 
                    string rotPer, string distSun)
        {
            // Star instance variables
            StarName = starName;
            EffectiveTemp = effTemp;
            RadiusRatio = radius;
            MassRatio = mass;
            Age = age;
            RotationVel = rotVel;
            RotationPeriod = rotPer;
            DistToSun = distSun;
            NamePL = namePL;
            // Collection of Planets orbiting (hosted by) Star
            myPlanets = new HashSet<string>();
          
            myPlanets.Add(namePL);
        }

        /// <summary>
        /// Returns string with the Star's values in the format determined by 
        /// the user
        /// </summary>
        /// <param name="csv">bool to check if the user wants the information 
        /// to be printed in a csv format</param>
        /// <returns>string containing the Star's attributes</returns>
        public string ToString(bool csv = true)
        {
            if (csv)
            {
                // Return values in CSV format
                return myPlanets.Count + "," + StarName + "," + EffectiveTemp + 
                "," + RadiusRatio + "," + MassRatio + "," + Age + "," + 
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

        /// <summary>
        /// Converts default values back to their 'Missing' designation
        /// </summary>
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

        /// <summary>
        /// Definition of '+' operator for Star additions, used to combine 
        /// information from different entries of the same star to provide
        /// the most information possible of said Star
        /// </summary>
        /// <param name="star1">"Current" Star info</param>
        /// <param name="star2">Different entry of the same Star</param>
        /// <returns>Star with updated values</returns>
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