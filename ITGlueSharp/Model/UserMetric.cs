using System;

namespace Xilophor.ITGlueSharp.Model;

public class UserMetric
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long OrganizationId { get; set; }
    public string ResourceType { get; set; }
    public long Created { get; set; }
    public long Viewed { get; set; }
    public long Edited { get; set; }
    public long Deleted { get; set; }
    public DateTime Date { get; set; }
}
