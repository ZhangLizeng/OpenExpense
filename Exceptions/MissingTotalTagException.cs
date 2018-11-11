using System;

namespace OpenExpense.Exceptions
{
    public class MissingTotalTagException: Exception
    {
        public MissingTotalTagException(): base("Total information is not provided.") 
        {

        }
    }
}