using System;

namespace Backlog.Exceptions
{
    public class EmailConfirmationException: Exception
    {
        public EmailConfirmationException()
            :base("Email Confirmation Failed")
        { }        
    }
}
