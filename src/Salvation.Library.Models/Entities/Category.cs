namespace Salvation.Library.Models.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = null!;

        public string Image { get; set; } = null!;

        public long ParentId { get; set; }
    }
}
