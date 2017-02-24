using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Data.Models
{
    public class BrandOwner
    {
        public int Id { get; set; }
        [ForeignKey("Brand")]
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
