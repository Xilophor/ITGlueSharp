using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Xilophor.ITGlueSharp.Model;

namespace Xilophor.ITGlueSharp.API;

public class Users(string baseUrl, string apiKey)
{
    private class IndexParams : Params
    {
        [JsonPropertyName("sort")]
        public string? Sort { get; set; }
    }
    
    private static HttpClient HttpClient => Utils.HttpClient;

    #region Public Methods
    
    #region Index
    
    /// <summary>
    ///     List all users.
    /// </summary>
    /// <param name="baseUrl"> The api url to hit. See <see href="https://api.itglue.com/developer/">ITGlue Docs</see> for more info. </param>
    /// <param name="apiKey"> The ITGlue API token. </param>
    /// <param name="filterId"> The ID to search for. </param>
    /// <param name="filterName"> The name to search for. Must be an exact match. </param>
    /// <param name="filterEmail"> The email to search for. </param>
    /// <param name="filterRoleName"> The role name to search for. </param>
    /// <param name="filterSalesforceId"> The salesforce ID to search for. </param>
    /// <param name="sort"> The sort order to use. See <see href="https://api.itglue.com/developer/#accounts-users-index">Users Endpoint Docs</see> for valid values. </param>
    /// <param name="pageNumber"> The number of the page to search in. </param>
    /// <param name="pageSize"> The size of the page to search in. </param>
    /// <returns> Returns a list of the users in your account. </returns>
    public static async Task<User[]> IndexAsync(string baseUrl,
        string apiKey,
        long? filterId = null,
        string? filterName = null,
        string? filterEmail = null,
        string? filterRoleName = null,
        long? filterSalesforceId = null,
        string? sort = null,
        int? pageNumber = null,
        int? pageSize = null)
    {
        var param = new IndexParams
        {
            Filter = new Dictionary<string, object?>
            {
                ["id"] = filterId, ["name"] = filterName, ["email"] = filterEmail, 
                ["role_name"] = filterRoleName, ["salesforce_id"] = filterSalesforceId
            },
            Sort = sort,
            Page = new Page(pageNumber, pageSize)
        };

        var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/users");
        request.Headers.Add("x-api-key", apiKey);
        request.Content = new StringContent(JsonSerializer.Serialize(param, Utils.DefaultSerializerOptions), 
            Encoding.UTF8,
            "application/vnd.api+json");
        
        var response = await HttpClient.SendAsync(request);
        return JsonSerializer.Deserialize<DataArrayResponse<User>>(await response.Content.ReadAsStringAsync(),
            Utils.WithNullDefaultSerializerOptions).Data ?? [];
    }
    
    /// <summary>
    ///     List all users.
    /// </summary>
    /// <param name="baseUrl"> The api url to hit. See <see href="https://api.itglue.com/developer/">ITGlue Docs</see> for more info. </param>
    /// <param name="apiKey"> The ITGlue API token. </param>
    /// <param name="filterId"> The ID to search for. </param>
    /// <param name="filterName"> The name to search for. Must be an exact match. </param>
    /// <param name="filterEmail"> The email to search for. </param>
    /// <param name="filterRoleName"> The role name to search for. </param>
    /// <param name="filterSalesforceId"> The salesforce ID to search for. </param>
    /// <param name="sort"> The sort order to use. See <see href="https://api.itglue.com/developer/#accounts-users-index">Users Endpoint Docs</see> for valid values. </param>
    /// <param name="pageNumber"> The number of the page to search in. </param>
    /// <param name="pageSize"> The size of the page to search in. </param>
    /// <returns> Returns a list of the users in your account. </returns>
    public static User[] Index(string baseUrl, string apiKey, long? filterId = null, string? filterName = null,
        string? filterEmail = null, string? filterRoleName = null, long? filterSalesforceId = null, string? sort = null,
        int? pageNumber = null, int? pageSize = null) 
        => IndexAsync(baseUrl, apiKey, filterId, filterName, filterEmail, filterRoleName, filterSalesforceId, sort,
            pageNumber, pageSize).Result;
    
    /// <summary>
    ///     List all users.
    /// </summary>
    /// <param name="filterId"> The ID to search for. </param>
    /// <param name="filterName"> The name to search for. Must be an exact match. </param>
    /// <param name="filterEmail"> The email to search for. </param>
    /// <param name="filterRoleName"> The role name to search for. </param>
    /// <param name="filterSalesforceId"> The salesforce ID to search for. </param>
    /// <param name="sort"> The sort order to use. See <see href="https://api.itglue.com/developer/#accounts-users-index">Users Endpoint Docs</see> for valid values. </param>
    /// <param name="pageNumber"> The number of the page to search in. </param>
    /// <param name="pageSize"> The size of the page to search in. </param>
    /// <returns> Returns a list of the users in your account. </returns>
    public async Task<User[]> IndexAsync(long? filterId = null, string? filterName = null,
        string? filterEmail = null, string? filterRoleName = null, long? filterSalesforceId = null, string? sort = null,
        int? pageNumber = null, int? pageSize = null) 
        => await IndexAsync(baseUrl, apiKey, filterId, filterName, filterEmail, filterRoleName, filterSalesforceId, sort,
            pageNumber, pageSize);
    
    /// <summary>
    ///     List all users.
    /// </summary>
    /// <param name="filterId"> The ID to search for. </param>
    /// <param name="filterName"> The name to search for. Must be an exact match. </param>
    /// <param name="filterEmail"> The email to search for. </param>
    /// <param name="filterRoleName"> The role name to search for. </param>
    /// <param name="filterSalesforceId"> The salesforce ID to search for. </param>
    /// <param name="sort"> The sort order to use. See <see href="https://api.itglue.com/developer/#accounts-users-index">Users Endpoint Docs</see> for valid values. </param>
    /// <param name="pageNumber"> The number of the page to search in. </param>
    /// <param name="pageSize"> The size of the page to search in. </param>
    /// <returns> Returns a list of the users in your account. </returns>
    public User[] Index(long? filterId = null, string? filterName = null,
        string? filterEmail = null, string? filterRoleName = null, long? filterSalesforceId = null, string? sort = null,
        int? pageNumber = null, int? pageSize = null) 
        => IndexAsync(baseUrl, apiKey, filterId, filterName, filterEmail, filterRoleName, filterSalesforceId, sort,
            pageNumber, pageSize).Result;
    
    #endregion
    
    #region Show
    
    /// <summary>
    ///     Retrieve a user.
    /// </summary>
    /// <param name="baseUrl"> The api url to hit. See <see href="https://api.itglue.com/developer/">ITGlue Docs</see> for more info. </param>
    /// <param name="apiKey"> The ITGlue API token. </param>
    /// <param name="id"> The ID of the user. </param>
    /// <returns> Returns information about one user. </returns>
    public static async Task<User?> ShowAsync(string baseUrl,
        string apiKey,
        long id)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/users/{id}");
        request.Headers.Add("x-api-key", apiKey);
        
        var response = await HttpClient.SendAsync(request);
        return JsonSerializer.Deserialize<DataObjectResponse<User>>(await response.Content.ReadAsStringAsync(),
            Utils.WithNullDefaultSerializerOptions).Data ?? throw new IndexOutOfRangeException();
    }
    
    /// <summary>
    ///     Retrieve a user.
    /// </summary>
    /// <param name="baseUrl"> The api url to hit. See <see href="https://api.itglue.com/developer/">ITGlue Docs</see> for more info. </param>
    /// <param name="apiKey"> The ITGlue API token. </param>
    /// <param name="id"> The ID of the user. </param>
    /// <returns> Returns information about one user. </returns>
    public static User? Show(string baseUrl, string apiKey, long id) 
        => ShowAsync(baseUrl, apiKey, id).Result;
    
    /// <summary>
    ///     Retrieve a user.
    /// </summary>
    /// <param name="id"> The ID of the user. </param>
    /// <returns> Returns information about one user. </returns>
    public async Task<User?> ShowAsync(long id) 
        => await ShowAsync(baseUrl, apiKey, id);
    
    /// <summary>
    ///     Retrieve a user.
    /// </summary>
    /// <param name="id"> The ID of the user. </param>
    /// <returns> Returns information about one user. </returns>
    public User? Show(long id) 
        => ShowAsync(baseUrl, apiKey, id).Result;
    
    #endregion
    
    #region Update

    /// <summary>
    ///     Update a user.
    /// </summary>
    /// <param name="baseUrl"> The api url to hit. See <see href="https://api.itglue.com/developer/">ITGlue Docs</see> for more info. </param>
    /// <param name="apiKey"> The ITGlue API token. </param>
    /// <param name="userInfo"> The updated User Info. </param>
    /// <param name="ignoreNullInfo"> Whether null info should be ignored. Changing this will cause values to be nulled out if left empty. </param>
    public static async Task UpdateAsync(string baseUrl,
        string apiKey,
        User userInfo,
        bool ignoreNullInfo = true)
    {
        var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"{baseUrl}/users/{userInfo.Id}");
        request.Headers.Add("x-api-key", apiKey);
        request.Content = new StringContent(JsonSerializer.Serialize(new DataObjectRequest<User>("users", userInfo), ignoreNullInfo ? Utils.DefaultSerializerOptions : Utils.WithNullDefaultSerializerOptions), 
            Encoding.UTF8,
            "application/vnd.api+json");
        
        await HttpClient.SendAsync(request);
    }

    /// <summary>
    ///     Update a user.
    /// </summary>
    /// <param name="baseUrl"> The api url to hit. See <see href="https://api.itglue.com/developer/">ITGlue Docs</see> for more info. </param>
    /// <param name="apiKey"> The ITGlue API token. </param>
    /// <param name="userInfo"> The updated User Info. </param>
    /// <param name="ignoreNullInfo"> Whether null info should be ignored. Changing this will cause values to be nulled out if left empty. </param>
    public static void Update(string baseUrl, string apiKey, User userInfo, bool ignoreNullInfo = true) 
        => UpdateAsync(baseUrl, apiKey, userInfo, ignoreNullInfo).Wait();

    /// <summary>
    ///     Update a user.
    /// </summary>
    /// <param name="baseUrl"> The api url to hit. See <see href="https://api.itglue.com/developer/">ITGlue Docs</see> for more info. </param>
    /// <param name="apiKey"> The ITGlue API token. </param>
    /// <param name="id"> The ID of the user. </param>
    /// <param name="firstName"> The first name of the user. </param>
    /// <param name="lastName"> The last name of the user. </param>
    /// <param name="avatarContent"> The base64-encoded avatar image. </param>
    /// <param name="avatarFileName"> The filename of the image. </param>
    /// <param name="ignoreNullInfo"> Whether null info should be ignored. Changing this will cause values to be nulled out if left empty. </param>
    public static async Task UpdateAsync(string baseUrl,
        string apiKey,
        long id,
        string? firstName = null,
        string? lastName = null,
        string? avatarContent = null,
        string? avatarFileName = null,
        bool ignoreNullInfo = true)
    {
        var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"{baseUrl}/users/{id}");
        request.Headers.Add("x-api-key", apiKey);
        request.Content = new StringContent(JsonSerializer.Serialize(new DataObjectRequest<Dictionary<string, object?>>("users", new Dictionary<string, object?>
            {
                ["id"] = id, 
                ["first_name"] = firstName, 
                ["last_name"] = lastName, 
                ["avatar"] = new Dictionary<string, object?>
                {
                    ["content"] = avatarContent, 
                    ["file_name"] = avatarFileName
                }
            }), ignoreNullInfo ? Utils.DefaultSerializerOptions : Utils.WithNullDefaultSerializerOptions), 
            Encoding.UTF8,
            "application/vnd.api+json");
        
        await HttpClient.SendAsync(request);
    }
    
    #endregion
    
    #endregion
}