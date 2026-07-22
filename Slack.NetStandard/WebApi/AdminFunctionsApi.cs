using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi;

internal class AdminFunctionsApi : IAdminFunctionsApi
{
    private readonly IWebApiClient _client;
    public AdminFunctionsApi(IWebApiClient client)
    {
        _client = client;
    }

    public Task<FunctionListResponse> List(params string[] appIds)
    {
        return List(new FunctionListRequest { AppIds = appIds.ToList() });
    }

    public Task<FunctionListResponse> List(FunctionListRequest request)
    {
        return _client.MakeJsonCall<FunctionListRequest, FunctionListResponse>("admin.functions.list", request);
    }

    public Task<FunctionPermissionLookupResponse> PermissionLookup(params string[] functionIds)
    {
        var jo = new JObject(new JProperty("function_ids", new JArray(functionIds)));
        return _client.MakeJsonCall<JObject, FunctionPermissionLookupResponse>("admin.functions.permissions.lookup",
            jo);
    }

    public Task<WebApiResponse> SetPermission(string functionId, string visibility, params string[] userIds)
    {
        var jo = new JObject(
            new JProperty("function_id", functionId),
            new JProperty("visibility",visibility),
            new JProperty("user_ids",new JArray(userIds))
        );

        return _client.MakeJsonCall("admin.functions.permissions.set", jo);
    }
}