using System;

namespace Xilophor.ITGlueSharp.Model;

public struct PasswordCategory
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime? CreatedAt { get; internal set; }
    public DateTime? UpdatedAt { get; internal set; }
    public int PasswordsCount { get; internal set; }
}