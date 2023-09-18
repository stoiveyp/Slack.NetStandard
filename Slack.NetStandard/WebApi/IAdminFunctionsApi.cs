using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi;

public interface IAdminFunctionsApi
{
    Task<FunctionListResponse> List(params string[] appIds);
    Task<FunctionListResponse> List(FunctionListRequest request);
    Task<FunctionPermissionLookupResponse> PermissionLookup(params string[] functionIds);
    Task<WebApiResponse> SetPermission(string functionId, string visibility, params string[] userIds);
}