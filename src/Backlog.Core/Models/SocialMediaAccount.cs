using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Backlog.Constants;

namespace Backlog.Core.Models
{
    
    public class SocialMediaAccount
    {
        public Guid Id { get; set; }        
		
                
        [ForeignKey("Profile")]
        public int? ProfileId { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        [Index("SocialMediaAccountNameIndex", IsUnique = false)]
        [Column(TypeName = "VARCHAR")]     
        [StringLength(255)]		   
		public string Name { get; set; }
        public string Title { get; set; }
        public DateTime CreatedOn { get; set; }        
		public DateTime LastModifiedOn { get; set; }        
		public string CreatedBy { get; set; }        
		public string LastModifiedBy { get; set; }        
		
        
        public User User { get; set; }
        public Profile Profile { get; set; }
    }
}