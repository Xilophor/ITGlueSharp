namespace Xilophor.ITGlueSharp.API;

/// <summary>
///     ITGlue API Instance. Use to quickly access API endpoints without needing to specify baseUrl and apiKey for each request.
/// </summary>
/// <param name="baseUrl"></param>
/// <param name="apiKey"></param>
public class ITGlueAPI(string baseUrl, string apiKey)
{
    public Users Users { get; } = new Users(baseUrl, apiKey);
}