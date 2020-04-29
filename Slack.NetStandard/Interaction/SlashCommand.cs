using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace Slack.NetStandard.Interaction
{
    public class SlashCommand
    {
        public const string SslCheckKey = "ssl_check";

        public SlashCommand(string payloadText) : this(Parse(payloadText))
        {

        }

        public SlashCommand(Dictionary<string, string> payload)
        {
            Payload = payload ?? throw new ArgumentNullException(nameof(payload));
        }

        private static Dictionary<string, string> Parse(string data)
        {
            var coll = HttpUtility.ParseQueryString(data);
            return coll.AllKeys.ToDictionary(k => k, k => coll[k].Trim());
        }

        private string KeyOrNull(string key)
        {
            return Payload.ContainsKey(key) ? Payload[key] : null;
        }

        public Dictionary<string, string> Payload { get; }
        public bool IsSslCheck => Payload.TryGetValue(SslCheckKey, out var result) && result == 1.ToString();

        public string Token => KeyOrNull("token");

        public string Command => KeyOrNull("command");

        public string Text => KeyOrNull("text");

        public string ResponseUrl => KeyOrNull("response_url");

        public string TriggerId => KeyOrNull("trigger_id");

        public string UserId => KeyOrNull("user_id");

        public string Username => KeyOrNull("user_name");

        public string ChannelId => KeyOrNull("channel_id");

        public string ChannelName => KeyOrNull("channel_name");

        public string TeamId => KeyOrNull("team_id");

        public string TeamName => KeyOrNull("team_name");

        public string EnterpriseId => KeyOrNull("enterprise_id");

        public string EnterpriseName => KeyOrNull("enterprise_name");

        public Task Respond(InteractionMessage message, HttpClient client = null)
        {
            return message.Send(ResponseUrl, message, client);
        }
    }
}
