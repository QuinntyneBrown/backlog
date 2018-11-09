using System;
using System.Collections.Generic;

namespace Backlog.Core.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid UniqueId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
