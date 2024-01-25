namespace Salvation.Library.Models.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; } = null!;

        public bool IsActived { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? CreatedId { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string? UpdatedId { get; set; }

        public DateTime DeletedAt { get; set; }

        public string? DeletedId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
