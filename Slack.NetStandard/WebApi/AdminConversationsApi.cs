using System.Collections.Generic;
using System.Linq;
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

        public Task<WebApiResponse> Unarchive(string channelId)
        {
            return _client.SingleValueEncodedCall("admin.conversations.unarchive", "channel_id", channelId);
        }

        public Task<BulkActionResponse> BulkArchive(IEnumerable<string> channelIds)
        {
            return _client.MakeJsonCall<JObject, BulkActionResponse>("admin.conversations.bulkArchive",
                new JObject(new JProperty("channel_ids", new JArray(channelIds))));
        }

        public Task<BulkActionResponse> BulkDelete(IEnumerable<string> channelIds)
        {
            return _client.MakeJsonCall<JObject, BulkActionResponse>("admin.conversations.bulkDelete",
                new JObject(new JProperty("channel_ids", new JArray(channelIds))));
        }

        public Task<BulkActionResponse> BulkMove(string targetTeamId, IEnumerable<string> channelIds)
        {
            return _client.MakeJsonCall<JObject, BulkActionResponse>("admin.conversations.bulkMove",
                new JObject(
                    new JProperty("target_team_id", targetTeamId),
                    new JProperty("channel_ids", new JArray(channelIds))));
        }

        public Task<WebApiResponse> ConvertToPublic(string channelId)
        {
            return _client.SingleValueEncodedCall("admin.conversations.convertToPublic", "channel_id", channelId);
        }

        public Task<WebApiResponse> ConvertToPrivate(string channelId)
        {
            return _client.SingleValueEncodedCall("admin.conversations.convertToPrivate", "channel_id", channelId);
        }

        public Task<CreateConversationResponse> Create(CreateConversationRequest request)
        {
            return _client.MakeJsonCall<CreateConversationRequest, CreateConversationResponse>("admin.conversations.create", request);
        }

        public Task<WebApiResponse> Delete(string channelId)
        {
            return _client.SingleValueEncodedCall("admin.conversations.delete", "channel_id", channelId);
        }

        public Task<WebApiResponse> SetTeams(SetTeamsRequest request)
        {
            return _client.MakeJsonCall("admin.conversations.setTeams", request);
        }

        public Task<WebApiResponse> DisconnectShared(string channelId, IEnumerable<string> leavingTeamsId = null)
        {
            var jobj = new JObject(new JProperty("channel_id", channelId));
            if (leavingTeamsId != null)
            {
                jobj.Add("leaving_team_ids", new JArray(leavingTeamsId));
            }
            return _client.MakeJsonCall("admin.conversations.disconnectShared", jobj);
        }

        public Task<ConversationPrefsResponse> GetConversationPrefs(string channelId)
        {
            return _client.SingleValueEncodedCall<ConversationPrefsResponse>("admin.conversations.getConversationPrefs",
                "channel_id", channelId);
        }

        public Task<CustomRetentionResponse> GetCustomRetention(string channelId)
        {
            return _client.SingleValueEncodedCall<CustomRetentionResponse>("admin.conversations.getCustomRetention",
                "channel_id", channelId);
        }

        public Task<GetTeamsResponse> GetTeams(string channelId, string cursor = null, int? limit = null)
        {
            var dict = new Dictionary<string, string>
            {
                {"channel_id",channelId}
            }.AddPaging(cursor, limit);

            return _client.MakeUrlEncodedCall<GetTeamsResponse>("admin.conversations.getTeams", dict);
        }

        public Task<WebApiResponse> Invite(string channelId, IEnumerable<string> userIds)
        {
            return _client.MakeJsonCall("admin.conversations.invite", new ConversationInviteRequest
            {
                ChannelId = channelId,
                UserIds = userIds.ToList()
            });
        }

        public Task<LookupResponse> Lookup(LookupRequest request)
        {
            return _client.MakeJsonCall<LookupRequest,LookupResponse>("admin.conversations.lookup", request);
        }

        public Task<WebApiResponse> RemoveCustomRetention(string channelId)
        {
            return _client.SingleValueEncodedCall("admin.conversations.removeCustomRetention", "channel_id", channelId);
        }

        public Task<WebApiResponse> Rename(string channelId, string name)
        {
            var nvc = new Dictionary<string, string>
            {
                { "channel_id", channelId },
                { "name", name }
            };
            return _client.MakeUrlEncodedCall("admin.conversations.rename",nvc);
        }

        public Task<SearchConversationResponse> Search(SearchConversationRequest request)
        {
            return _client.MakeJsonCall<SearchConversationRequest,SearchConversationResponse>("admin.conversations.search", request);
        }

        public Task<WebApiResponse> SetConversationPrefs(string channelId, SetConversationPrefsRequest request)
        {
            var nvc = new Dictionary<string, string>
            {
                { "channel_id", channelId },
                { "prefs", _client.EncodeJsonForWebApi(request) }
            };
            return _client.MakeUrlEncodedCall("admin.conversations.setConversationPrefs", nvc);
        }

        public Task<WebApiResponse> SetCustomRetention(string channelId, int durationDays)
        {
            var nvc = new Dictionary<string, string>
            {
                { "channel_id", channelId },
                { "duration_days", durationDays.ToString() }
            };
            return _client.MakeUrlEncodedCall("admin.conversations.setCustomRetention", nvc);
        }
    }
}
