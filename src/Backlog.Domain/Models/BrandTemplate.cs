using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Domain.Models
{    
    public class BrandTemplate
    {
        public Guid BrandTemplateId { get; set; }        
        [ForeignKey("Brand")]
        public Guid? BrandId { get; set; }
        [ForeignKey("Template")]
        public Guid? TemplateId { get; set; }        
        public virtual Brand Brand { get; set; }
        public virtual Template Template { get; set; }        
    }
}
