using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi
{
    internal class AdminTeamSettingsApi : IAdminTeamSettingsApi
    {
        private readonly IWebApiClient _client;
        public AdminTeamSettingsApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<TeamInfoResponse> Info(string teamId)
        {
            return _client.MakeUrlEncodedCall<TeamInfoResponse>("admin.teams.settings.info",
                new Dictionary<string, string>
                {
                    {"team_id", teamId}
                });
        }

        public Task<WebApiResponse> SetDefaultChannels(string teamId, params string[] defaultChannels)
        {
            return _client.MakeUrlEncodedCall("admin.teams.settings.setDefaultChannels",
                new Dictionary<string, string>
                {
                    {"team_id", teamId},
                    {"channel_ids",string.Join(",",defaultChannels) }
                });
        }

        public Task<WebApiResponse> SetDescription(string teamId, string description)
        {
            return _client.MakeUrlEncodedCall("admin.teams.settings.setDescription",
                new Dictionary<string, string>
                {
                    {"team_id", teamId},
                    {"description",description }
                });
        }

        public Task<WebApiResponse> SetDiscoverability(string teamId, TeamDiscoverability discoverability)
        {
            if (discoverability == TeamDiscoverability.Hidden)
            {
                throw new InvalidOperationException("Teams cannot be explicitly set to hidden");
            }

            return _client.MakeUrlEncodedCall("admin.teams.settings.setDiscoverability",
                new Dictionary<string, string>
                {
                    {"team_id", teamId},
                    {"discoverability",ToEnumString(typeof(TeamDiscoverability),discoverability) }
                });
        }

        private static string ToEnumString(Type enumType, object type)
        {
            var name = Enum.GetName(enumType, type);
            var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetTypeInfo().GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).FirstOrDefault();
            return enumMemberAttribute?.Value ?? type.ToString();
        }

        public Task SetIcon()
        {
            throw new NotImplementedException();
        }

        public Task SetName()
        {
            throw new NotImplementedException();
        }
    }
}