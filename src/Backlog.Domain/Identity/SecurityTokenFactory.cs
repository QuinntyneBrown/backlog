using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog.Domain.Identity
{
    public class SecurityTokenFactory : ISecurityTokenFactory
    {
        public string Create(Guid userId, string uniqueName)
        {
            throw new NotImplementedException();
        }
    }
}
