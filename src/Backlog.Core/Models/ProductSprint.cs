
using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Core.Models
{
    
    public class ProductSprint
    {
        public Guid Id { get; set; }
        
        
        public string Name { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public int? SprintId { get; set; }
        public Sprint Sprint { get; set; }
        

        
    }
}
