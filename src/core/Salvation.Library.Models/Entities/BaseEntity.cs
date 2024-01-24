namespace Salvation.Library.Models.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; } = null!;

        public bool IsActived { get; set; }

        public bool IsDeleted { get; set; }
    }
}
