﻿namespace Salvation.Library.Models.Entities;

/// <summary>
/// Base Entity
/// </summary>
public class BaseEntity
{
    /// <summary>
    /// GUID
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// IsActived
    /// </summary>
    public bool IsActived { get; set; }

    /// <summary>
    /// CreatedAt
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// CreatedId
    /// </summary>
    public string? CreatedId { get; set; }

    /// <summary>
    /// UpdatedAt
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// UpdatedId
    /// </summary>
    public string? UpdatedId { get; set; }

    /// <summary>
    /// DeletedAt
    /// </summary>
    public DateTime? DeletedAt { get; set; }

    /// <summary>
    /// DeletedId
    /// </summary>
    public string? DeletedId { get; set; }

    /// <summary>
    /// IsDeleted
    /// </summary>
    public bool IsDeleted { get; set; }
}
