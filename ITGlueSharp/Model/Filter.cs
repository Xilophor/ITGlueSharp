using System.Collections.Generic;

namespace Xilophor.ITGlueSharp.Model;

internal struct Filter(Dictionary<string, object?> filters)
{
    public Dictionary<string, object?> Values { get; set; } = filters;
}