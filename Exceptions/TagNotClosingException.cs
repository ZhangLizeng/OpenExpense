using System;

namespace OpenExpense.Exceptions 
{
    public class TagNotClosingException: Exception 
    {
        private static string modifyMessage(string tagThatNotClosed) 
        {
            return string.Format("The tag {0} is not closed.", tagThatNotClosed);
        }
        public TagNotClosingException(string tagThatNotClosed): base(modifyMessage(tagThatNotClosed))
        {
            
        }
    }
}