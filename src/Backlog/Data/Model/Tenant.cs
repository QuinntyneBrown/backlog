using System.Collections.Generic;

namespace Backlog.Data.Model
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
