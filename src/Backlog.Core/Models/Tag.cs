using System.Collections.Generic;


using System;

namespace Backlog.Core.Models
{

    public class Tag: ILoggable
    {
        public int Id { get; set; }
        
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Article> Articles { get; set; } = new HashSet<Article>();
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public virtual Tenant Tenant { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
