namespace Salvation.Library.Models.Entities
{
    public class ProductDetail : BaseEntity
    {
        public long ProductId { get; set; }

        public long CategoryId { get; set; }

        public long ProductPropertyId { get; set; }

        public string? ProductProperty { get; set; }

        public string? Value { get; set; }
    }
}
