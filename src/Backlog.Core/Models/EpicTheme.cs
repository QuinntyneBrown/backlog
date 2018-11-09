


namespace Backlog.Core.Models
{

    public class EpicTheme
    {
        public int Id { get; set; }
        
        public int? TenantId { get; set; }
        //[ForeignKey("Epic")]
        public int? EpicId { get; set; }
        //[ForeignKey("Theme")]
        public int? ThemeId { get; set; }
        public Epic Epic { get; set; }
        public Theme Theme { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}
