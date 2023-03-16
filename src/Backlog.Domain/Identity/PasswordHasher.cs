using System;
using System.Collections.Generic;
using System.Text;


namespace Backlog.Domain.Identity;

public class PasswordHasher : IPasswordHasher
{
    public string HashPassword(byte[] salt, string password)
    {
        throw new NotImplementedException();
    }
}
