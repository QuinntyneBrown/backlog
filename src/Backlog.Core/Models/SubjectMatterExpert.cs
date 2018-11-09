using System.Collections.Generic;



namespace Backlog.Core.Models
{

    public class SubjectMatterExpert
    {
        public int Id { get; set; }
        
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Tenant Tenant { get; set; }
    }
}
