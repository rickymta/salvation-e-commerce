namespace Salvation.Library.Models.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }

        public bool IsActived { get; set; }

        public bool IsDeleted { get; set; }
    }
}
