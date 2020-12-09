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
                        ("You cannot use \"-planet-info\"/\"-star-info\"" +
                        "and \"-search-planet\"/\"-search-star\" at the" + 
                        "same time");
                    break;
            }
        }
    }
}