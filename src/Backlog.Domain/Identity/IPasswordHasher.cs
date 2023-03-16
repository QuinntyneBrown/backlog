using System;
using System.Collections.Generic;
using System.Text;


namespace Backlog.Domain.Identity;

public interface IPasswordHasher
{
    string HashPassword(byte[] salt, string password);
}
