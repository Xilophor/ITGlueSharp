using System;

namespace Xilophor.ITGlueSharp.Model;

public class PasswordEntry
{
    public long Id { get; set; }
    public long OrganizationId { get; set; }
    public string OrganizationName { get; internal set; }
    public string ResourceUrl { get; internal set; }
    public bool Restricted { get; set; }
    public bool MyGlue { get; set; }
    public string Name { get; set; }
    public bool? AutofillSelectors { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? OtpSecret { get; set; }
    public string? Url { get; set; }
    public string? Notes { get; set; }
    public DateTime? PasswordUpdatedAt { get; internal set; }
    public long? UpdatedBy { get; internal set; }
    public long? ResourceId { get; set; }
    public string? ResourceType { get; set; }
    public string? CachedResourceTypeName { get; internal set; }
    public string? CachedResourceName { get; internal set; }
    public long? PasswordCategoryId { get; set; }
    public string PasswordCategoryName { get; set; }
    public DateTime CreatedAt { get; internal set; }
    public DateTime UpdatedAt { get; internal set; }
    public bool? IsLive { get; set; }
}