using System;

namespace Backlog.Exceptions
{
    public class EmailExistsException : Exception
    {
        public EmailExistsException()
            : base("Username Exists")
        { }
    }
}
