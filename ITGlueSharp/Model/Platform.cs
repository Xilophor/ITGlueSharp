using System;

namespace Xilophor.ITGlueSharp.Model;

public class Platform
{
    public long Id { get; internal set; }
    public string Name { get; internal set; }
    public DateTime CreatedAt { get; internal set; }
    public DateTime UpdatedAt { get; internal set; }
}