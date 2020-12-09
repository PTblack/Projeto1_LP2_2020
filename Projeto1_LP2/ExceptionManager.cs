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
                    Console.WriteLine("\nERROR: Attributes Missing");
                    
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

                case ErrorCodes.NoSearchOption:
                    Console.WriteLine("\nERROR: No Search Option Entered");

                    Console.WriteLine(
                        "User did not specify search option\n");
                    break;
            }
        }
    }
}