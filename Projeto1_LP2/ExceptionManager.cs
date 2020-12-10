using System;

namespace Projeto1_LP2
{
    /// <summary>
    /// This class Handles the exceptions and shows "help"
    /// </summary>
    public static class ExceptionManager
    {
        /// <summary>
        /// Handles exceptions. Stops the program and 
        /// sends message identifying the exception that happened
        /// </summary>
        /// <param name="errorCodes">Number identifying specific error</param>
        public static void ExceptionControl(ErrorCodes errorCodes)
        {
            switch(errorCodes)
            {
                case ErrorCodes.AttribsMissing:
                    Console.WriteLine("Error: Attribute(s) Missing");
                    
                    Console.WriteLine(
                        "Attributes \"pl_name\" and/or \"hostname\"" + 
                        "are missing in given file");
                    break;
                
                case ErrorCodes.AttribNumFluct:
                    Console.WriteLine("Error: Attribute Number Fluctuation");
                    
                    Console.WriteLine(
                        "The given file has line(s) that don't match the " + 
                        "number of attributes stated in the file header");
                    break;

                case ErrorCodes.IncompatibleOptions:
                    Console.WriteLine("Error: Incompatible Search Arguments");
                    
                    Console.WriteLine
                        ("You cannot use \"-search-planet\" and" +
                        "\"-search-star\" at the same time");
                        break;
                        
                case ErrorCodes.NoSearchOption:
                    Console.WriteLine("Error: No Search Option Entered");

                    Console.WriteLine(
                        "User did not specify search option");
                    break;

                case ErrorCodes.NoDataFound:
                    Console.WriteLine("Error: No results found for criteria");

                    Console.WriteLine(
                        "No item in document matches the parameters given by user");
                    break;
            }
            ShowHelp();
            System.Environment.Exit(0);
        }

        /// <summary>
        /// Method that prints on the screen all the information needed to 
        /// use the program flawlessly
        /// </summary>
        public static void ShowHelp()
        {
            Console.WriteLine(
                $"\nSEARCH OPTIONS\n\n" +

                $"File: -file\n" +
                $"Planet Information: -planet-info\n" +
                $"Star Information: -star-info\n" +
                $"Planet Search: -search-planet\n" +
                $"Star Search: -search-star\n\n" +

                $"PLANET OPTIONS \n\n" +

                $"(min = minimum) \n" +
                $"(max = maximum) \n\n" +

                $"Name: -planet-name\n" +
                $"Host Name (Star Name): -host-name\n" +
                $"Discovery Method: -disc-method\n" +
                $"Discovery Year: -disc-year-min or -disc-year-max\n" +
                $"Orbit Period: -planet-orbper-min or -planet-orbper-max\n" +
                $"Radius (vs Earth): -planet-rade-min or -planet-rade-max\n" +
                $"Mass (vs Earth): -planet-mass-min or -planet-mass-max\n" +
                $"Equilibrium Temperature: -planet-temp-min or -planet-temp-max\n\n" +

                $"STAR OPTIONS \n\n" +

                $"(min = minimum) \n" +
                $"(max = maximum) \n\n" +

                $"Star Name: -host-name\n" +
                $"Effective Temperature: -star-temp-min or -star-temp-max\n" +
                $"Radius (vs Earth): -star-rade-min or -star-rade-max\n" +
                $"Mass (vs Earth): -star-mass-min or -star-mass-max\n" +
                $"Age: -star-age-min or -star-age-max\n" +
                $"Rotation Velocity: -star-vsin-min or -star-vsin-max\n" +
                $"Rotation Period: -star-rotp-min or -star-rotp-max\n" +
                $"Distance to Sun: -sy-dist-min or -sy-dist-max\n\n" +

                $"HELP OPTIONS\n\n" +

                $"Help: -help\n" +
                $"Example: -file \"NasaExoplanetSearcher.csv\" -planet-search" +
                $"-planet-name \"XO-4 b\" -host-name \"XO-4\" -planet-mass-min " +
                $"2500 -planet-mass 50000\n\n" +
                $"(WARNING: IN REPEATED ARGUMENTS, ONLY THE LAST ONE IS READ)\n\n");
        }
    }
}