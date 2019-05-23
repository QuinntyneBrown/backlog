using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Core.Models
{
    
    public class BrandTemplate
    {
        public Guid Id { get; set; }
        
        
        [ForeignKey("Brand")]
        public int? BrandId { get; set; }
        [ForeignKey("Template")]
        public int? TemplateId { get; set; }
        

        public virtual Brand Brand { get; set; }
        public virtual Template Template { get; set; }
        
    }
}
