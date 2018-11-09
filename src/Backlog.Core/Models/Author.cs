


namespace Backlog.Core.Models
{

    public class Author
    {
        public int Id { get; set; }
        
        public int? TenantId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string AvatarUrl { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Tenant Tenant { get; set; }
    }
}
