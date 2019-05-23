using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Backlog.Domain.Models
{
    
    public class Profile
    {
        public Guid ProfileId { get; set; }        
		
        [Column(TypeName = "VARCHAR")]     
        [StringLength(255)]		   
		public string Name { get; set; }
        public string AvatarImageUrl { get; set; }
        public string Description { get; set; }
        public ICollection<SocialMediaAccount> SocialMediaAccounts { get; set; } = new HashSet<SocialMediaAccount>();
		public DateTime CreatedOn { get; set; }        
		public DateTime LastModifiedOn { get; set; }        
		public string CreatedBy { get; set; }        
		public string LastModifiedBy { get; set; }        
		
        
        public virtual User User { get; set; }
    }
}
