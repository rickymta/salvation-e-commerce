namespace Salvation.Library.Models.Entities
{
    public class ProductProperty : BaseEntity
    {
        public long CategoryId { get; set; }

        public string Name { get; set; } = null!;
    }
}
