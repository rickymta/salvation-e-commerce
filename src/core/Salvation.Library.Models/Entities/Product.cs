namespace Salvation.Library.Models.Entities
{
    public class Product : BaseEntity
    {
        public long CategoryId { get; set; }

        public long ManufactureId { get; set; }

        public string Name { get; set; } = null!;

        public string FeatureImage { get; set; } = null!;

        public long Price { get; set; }
    }
}
