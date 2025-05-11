using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Xilophor.ITGlueSharp.Model;

namespace Xilophor.ITGlueSharp.API;

public class Users
{
    private static readonly HttpClient HttpClient = new ();

    static Users()
    {
        HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.api+json"));
    }

    private class IndexParams : Params
    {
        public string? sort { get; set; }
    }

    /// <summary>
    ///     List all users.
    /// </summary>
    /// <param name="baseUrl"> The api url to hit. </param>
    /// <param name="apiToken"> The ITGlue API token. </param>
    /// <param name="filterId"> The ID to search for. </param>
    /// <param name="filterName"> The name to search for. Must be an exact match. </param>
    /// <param name="filterEmail"> The email to search for. </param>
    /// <param name="filterRoleName"> The role name to search for. </param>
    /// <param name="filterSalesforceId"> The salesforce ID to search for. </param>
    /// <param name="sort"> The sort order to use. See <see href="https://api.itglue.com/developer/#accounts-users-index">ITGlue Docs</see> for more info. </param>
    /// <param name="pageNumber"> The number of the page to search in. </param>
    /// <param name="pageSize"> The size of the page to search in. </param>
    /// <returns> Returns a list of the users in your account. </returns>
    public static async Task<User[]> Index(string baseUrl, string apiToken,
        long? filterId = null, string? filterName = null, string? filterEmail = null, string? filterRoleName = null, long? filterSalesforceId = null, 
        string? sort = null, int? pageNumber = null, int? pageSize = null)
    {
        HttpClient.BaseAddress = new Uri(baseUrl);

        var param = new IndexParams
        {
            filter = new Filter(new Dictionary<string, object?>
            {
                ["id"] = filterId, ["name"] = filterName, ["email"] = filterEmail, 
                ["role_name"] = filterRoleName, ["salesforce_id"] = filterSalesforceId
            }),
            sort = sort,
            page = new Page(pageNumber, pageSize)
        };

        var request = new HttpRequestMessage(HttpMethod.Get, "users");
        request.Headers.Add("x-api-key", apiToken);
        request.Content = new StringContent(
            JsonSerializer.Serialize(param, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull }), 
            Encoding.UTF8,
            "application/vnd.api+json");

        var response = await HttpClient.SendAsync(request);
        
        return JsonSerializer.Deserialize<JsonNode>(await response.Content.ReadAsStringAsync())?["data"]?.GetValue<User[]>() ?? [];
    }
}