using System;

namespace Projeto1_LP2
{
    public class ExceptionManager
    {

        // Talvez se passe para um delegate Action que recebe um int
        public void ExceptionControl(int errorCode)
        {
            switch(errorCode)
            {
                case (int)ErrorCodes.AttribsMissing:
                    Console.WriteLine(
                        "Attributes \"pl_name\" and \"hostname\"" + 
                        "missing in given file");
                    break;
            }

        }
    }
}