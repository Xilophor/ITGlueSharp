namespace Xilophor.ITGlueSharp.Model;

/// <summary>
///     An avatar image.
/// </summary>
public class Avatar
{
    /// <summary>
    ///     The base64-encoded image.
    /// </summary>
    public string? Content { get; set; }
    
    /// <summary>
    ///     The image file name.
    /// </summary>
    public string? FileName { get; set; }
}
