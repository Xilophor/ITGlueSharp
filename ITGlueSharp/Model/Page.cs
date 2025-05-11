namespace Xilophor.ITGlueSharp.Model;

internal struct Page(int? number, int? size)
{
    public int? number { get; set; } = number;
    public int? size { get; set; } = size;
}