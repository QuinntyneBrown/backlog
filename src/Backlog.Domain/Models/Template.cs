using System;
using System.Collections.Generic;

namespace Backlog.Domain.Models
{    
    public class Template
    {
        public Guid TemplateId { get; set; }        
        public string Name { get; set; }        
        public ICollection<Brand> Brands { get; set; }
    }
}
