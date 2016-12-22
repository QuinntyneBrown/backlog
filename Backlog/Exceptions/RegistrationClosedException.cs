using System;


namespace Backlog.Exceptions
{
    public class RegistrationClosedException: Exception
    {
        public RegistrationClosedException()
            :base("Registration Closed")
        {

        }
    }
}
