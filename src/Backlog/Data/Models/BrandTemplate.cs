using System.Collections.Generic;

namespace Backlog.Data.Models
{
    public class BrandTemplate
    {
        public int Id { get; set; }
        public int? BrandId { get; set; }
        public int? TemplateId { get; set; }
        public Brand Brand { get; set; }
        public Template Template { get; set; }
    }
}
