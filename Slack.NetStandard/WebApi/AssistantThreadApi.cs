using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.Assistant;
using System.Linq;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    public class AssistantThreadApi(IWebApiClient client, string channelId, Timestamp threadTimestamp) : IAssistantThreadApi
    {
        public Task<WebApiResponse> SetStatus(string status)
        {
            var jo = ThreadObject();
            jo.Add(new JProperty("status", status));
            return client.MakeJsonCall("assistant.threads.setStatus", jo);
        }

        public Task<WebApiResponse> SetSuggestedPrompts(params Prompt[] prompts) => SetSuggestedPrompts(null, prompts);

        public Task<WebApiResponse> SetSuggestedPrompts(string title, params Prompt[] prompts)
        {
            var jo = ThreadObject();
            if (!string.IsNullOrWhiteSpace(title))
            {
                jo.Add(new JProperty("title", title));
            }
            jo.Add("prompts", new JArray(prompts.Select(JToken.FromObject)));
            return client.MakeJsonCall("assistant.threads.setSuggestedPrompts", jo);
        }

        public Task<WebApiResponse> SetTitle(string title)
        {
            var jo = ThreadObject();
            jo.Add(new JProperty("title", title));
            return client.MakeJsonCall("assistant.threads.setTitle", jo);
        }

        private JObject ThreadObject() => new JObject(new JProperty("channel_id", channelId), new JProperty("thread_ts", threadTimestamp.ToString()));
    }
}