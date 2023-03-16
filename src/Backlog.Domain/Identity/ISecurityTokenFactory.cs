using System;
using System.Collections.Generic;
using System.Text;


namespace Backlog.Domain.Identity;

public interface ISecurityTokenFactory
{
    string Create(Guid userId, string uniqueName);
}
