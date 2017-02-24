namespace Backlog.Data.Models
{
    public class ProductSprint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public int? SprintId { get; set; }
        public Sprint Sprint { get; set; }
        public bool IsDeleted { get; set; }
    }
}
