namespace Salvation.Library.Models.Entities
{
    public class ProductImage : BaseEntity
    {
        public long ProductId { get; set; }

        public string Image { get; set; } = null!;
    }
}
