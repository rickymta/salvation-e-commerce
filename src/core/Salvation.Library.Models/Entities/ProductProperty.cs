namespace Salvation.Library.Models.Entities;

/// <summary>
/// ProductProperty
/// </summary>
public class ProductProperty : BaseEntity
{
    /// <summary>
    /// Foreign key of category
    /// </summary>
    public long CategoryId { get; set; }

    /// <summary>
    /// Property Name
    /// </summary>
    public string Name { get; set; } = null!;
}
