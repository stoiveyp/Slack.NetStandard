using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi
{
    internal class AdminConversationsApi : IAdminConversationsApi
    {
        private readonly IWebApiClient _client;
        public AdminConversationsApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<WebApiResponse> Archive(string channelId)
        {
            return _client.SingleValueEncodedCall("admin.conversations.archive", "channel_id", channelId);
        }

        public Task<BulkActionResponse> BulkArchive(IEnumerable<string> channelIds)
        {
            return _client.MakeJsonCall<JObject,BulkActionResponse>("admin.conversations.bulkArchive",
                new JObject(new JProperty("channel_ids", new JArray(channelIds))));
        }

        public Task<BulkActionResponse> BulkDelete(IEnumerable<string> channelIds)
        {
            return _client.MakeJsonCall<JObject,BulkActionResponse>("admin.conversations.bulkDelete",
                new JObject(new JProperty("channel_ids", new JArray(channelIds))));
        }

        public Task<BulkActionResponse> BulkMove(string targetTeamId, IEnumerable<string> channelIds)
        {
            return _client.MakeJsonCall<JObject, BulkActionResponse>("admin.conversations.bulkMove",
                new JObject(
                    new JProperty("target_team_id", targetTeamId),
                    new JProperty("channel_ids", new JArray(channelIds))));
        }

        public Task<WebApiResponse> SetTeams(SetTeamsRequest request)
        {
            return _client.MakeJsonCall("admin.conversations.setTeams", request);
        }
    }
}