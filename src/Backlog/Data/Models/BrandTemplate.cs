using System.Collections.Generic;
using Backlog.Data.Helpers;

namespace Backlog.Data.Models
{
    [SoftDelete("IsDeleted")]
    public class BrandTemplate
    {
        public int Id { get; set; }
        public int? BrandId { get; set; }
        public int? TemplateId { get; set; }
        public Brand Brand { get; set; }
        public Template Template { get; set; }
    }
}
