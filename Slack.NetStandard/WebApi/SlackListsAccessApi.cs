using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.SlackLists;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    internal class SlackListsAccessApi : ISlackListsAccessApi
    {
        private class AccessRequest
        {
            [JsonProperty("list_id")]
            public string ListId { get; set; }

            [JsonProperty("access_level", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(StringEnumConverter))]
            public ListAccessLevel? AccessLevel { get; set; }

            [JsonExtensionData]
            public Dictionary<string, object> AdditionalData { get; set; } = new();
        }

        private readonly IWebApiClient _client;

        public SlackListsAccessApi(IWebApiClient client)
        {
            _client = client;
        }

        private Task<WebApiResponse> Delete(string listId, string idProperty, IEnumerable<string> ids)
        {
            var ar = new AccessRequest();
            ar.ListId = listId;
            ar.AdditionalData.Add(idProperty, ids);

            return _client.MakeJsonCall("slackLists.access.delete", ar);
        }

        private Task<WebApiResponse> Set(string listId, ListAccessLevel accessLevel, string idProperty, IEnumerable<string> ids)
        {
            var ar = new AccessRequest();
            ar.ListId = listId;
            ar.AccessLevel = accessLevel;
            ar.AdditionalData.Add(idProperty, ids);

            return _client.MakeJsonCall("slackLists.access.set", ar);
        }

        public Task<WebApiResponse> DeleteChannels(string listId, params string[] channelIds)
        {
            return Delete(listId, "channel_ids", channelIds);
        }

        public Task<WebApiResponse> DeleteChannels(string listId, List<string> channelIds)
        {
            return Delete(listId, "channel_ids", channelIds);
        }

        public Task<WebApiResponse> DeleteUsers(string listId, params string[] userIds)
        {
            return Delete(listId, "user_ids", userIds);
        }

        public Task<WebApiResponse> DeleteUsers(string listId, List<string> userIds)
        {
            return Delete(listId, "user_ids", userIds);
        }

        public Task<WebApiResponse> SetChannels(string listId, ListAccessLevel level, params string[] channelIds)
        {
            return Set(listId, level, "channel_ids", channelIds);
        }

        public Task<WebApiResponse> SetChannels(string listId, ListAccessLevel level, List<string> channelIds)
        {
            return Set(listId, level, "channel_ids", channelIds);
        }

        public Task<WebApiResponse> SetUsers(string listId, ListAccessLevel level, params string[] userIds)
        {
            return Set(listId, level, "user_ids", userIds);
        }

        public Task<WebApiResponse> SetUsers(string listId, ListAccessLevel level, List<string> userIds)
        {
            return Set(listId, level, "user_ids", userIds);
        }
    }
}