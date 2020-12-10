using System;

namespace Projeto1_LP2
{
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
                    Console.WriteLine("\nERROR: Attribute(s) Missing");
                    
                    Console.WriteLine(
                        "Attributes \"pl_name\" and/or \"hostname\"" + 
                        " are missing in given file\n");
                    break;
                
                case ErrorCodes.AttribNumFluct:
                    Console.WriteLine("\nERROR: Attribute Number Fluctuation");
                    
                    Console.WriteLine(
                        "The given file has line(s) that don't match the " + 
                        "number of attributes stated in the file header\n");
                    break;

                case ErrorCodes.IncompatibleOptions:
                    Console.WriteLine("\nERROR: Incompatible Search Arguments");
                    
                    Console.WriteLine
                        ("You cannot use \"-search-planet\" and" +
                        "\"-search-star\" at the same time\n");
                        break;
                        
                case ErrorCodes.NoSearchOption:
                    Console.WriteLine("\nERROR: No Search Option Entered");

                    Console.WriteLine(
                        "User did not specify search option\n");
                    break;

                case ErrorCodes.NoDataFound:
                    Console.WriteLine("\nERROR: No results found for criteria");

                    Console.WriteLine(
                        "No item in document matches the parameters given" +
                        " by user\n");
                    break;
            }
        }
    }
}