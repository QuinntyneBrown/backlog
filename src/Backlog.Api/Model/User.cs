using System.Collections.Generic;
using Backlog.Data.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Model
{
    [SoftDelete("IsDeleted")]
    public class User
    {
        public int Id { get; set; }
        [ForeignKey("Tenant")]
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string ImageUrl { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }        
        public string Fullname { get { return $"{Firstname} {Lastname}"; } }
        public bool IsDeleted { get; set; }
        public ICollection<Role> Roles { get; set; } = new HashSet<Role>();
        public virtual Tenant Tenant { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
