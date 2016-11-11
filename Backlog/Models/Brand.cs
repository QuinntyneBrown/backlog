using System.Collections.Generic;

namespace Backlog.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BrandOwner> BrandOwners { get; set; } = new HashSet<BrandOwner>();
        public bool IsDeleted { get; set; }
    }
}
