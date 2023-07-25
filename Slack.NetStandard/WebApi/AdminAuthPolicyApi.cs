using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi;

internal class AdminAuthPolicyApi : IAdminAuthPolicyApi
{
    private IWebApiClient _client;

    public AdminAuthPolicyApi(IWebApiClient client)
    {
        _client = client;

    }

    public Task<GetEntitiesResponse> GetEntities(GetEntitiesRequest request)
    {
        return _client.MakeJsonCall<GetEntitiesRequest, GetEntitiesResponse>("admin.auth.policy.getEntities", request);
    }

    public Task<WebApiResponse> AssignEntities(string policyName, List<string> entityIds, EntityType entityType)
    {
        return _client.MakeJsonCall("admin.auth.policy.assignEntities", new ChangeEntitiesRequest
        {
            PolicyName = policyName,
            EntityType = entityType,
            EntityIds = entityIds
        });
    }

    public Task<WebApiResponse> RemoveEntities(string policyName, List<string> entityIds, EntityType entityType)
    {
        return _client.MakeJsonCall("admin.auth.policy.removeEntities", new ChangeEntitiesRequest
        {
            PolicyName = policyName,
            EntityType = entityType,
            EntityIds = entityIds
        });
    }
}