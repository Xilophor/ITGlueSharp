using Xilophor.ITGlueSharp.Enum;

namespace Xilophor.ITGlueSharp.Model;

public class RelatedItem
{
    public long DestinationId { get; set; }
    public ResourceType ResourceType { get; set; }
    public string? Notes { get; set; }
    public bool? ViaCopilot { get; set; }
}
