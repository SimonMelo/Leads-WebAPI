namespace Leads.Domain.Entities.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public void MarkAsUpdated() => UpdatedAt = DateTime.UtcNow;
    }
}
