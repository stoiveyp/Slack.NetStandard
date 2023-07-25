using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi;

public interface IAdminAuthPolicyApi
{
    Task<GetEntitiesResponse> GetEntities(GetEntitiesRequest request);
    Task<WebApiResponse> AssignEntities(string policyName, List<string> entityIds, EntityType entityType);
    Task<WebApiResponse> RemoveEntities(string policyName, List<string> entityIds, EntityType entityType);
}