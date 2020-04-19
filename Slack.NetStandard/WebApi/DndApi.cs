using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Dnd;

namespace Slack.NetStandard.WebApi
{
    internal class DndApi : IDndApi
    {
        private readonly IWebApiClient _client;

        public DndApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<WebApiResponse> End()
        {
            return _client.MakeUrlEncodedCall("dnd.endDnd", new Dictionary<string, string>());
        }

        public Task<DndStatus> EndSnooze()
        {
            return _client.MakeUrlEncodedCall<DndStatus>("dnd.endSnooze", new Dictionary<string, string>());
        }

        public Task<DndStatus> Info(string user)
        {
            return _client.MakeUrlEncodedCall<DndStatus>("dnd.info", new Dictionary<string, string>{{"user",user}});
        }

        public Task<DndStatus> SetSnooze(int minutes)
        {
            return _client.MakeUrlEncodedCall<DndStatus>("dnd.setSnooze", new Dictionary<string, string> { { "num_minutes", minutes.ToString() } });
        }

        public Task<DndTeamInfoResponse> TeamInfo(params string[] users)
        {
            return _client.MakeUrlEncodedCall<DndTeamInfoResponse>("dnd.teamInfo", new Dictionary<string, string> { { "users", string.Join(",",users) } });
        }
    }
}