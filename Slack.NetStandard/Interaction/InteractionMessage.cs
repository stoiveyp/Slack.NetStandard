using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slack.NetStandard.Messages;
using Slack.NetStandard.WebApi;

namespace Slack.NetStandard.Interaction
{
    public class InteractionMessage:Message
    {
        public InteractionMessage(bool? replaceOriginal = null) :this(ResponseType.Ephemeral,replaceOriginal){ }

        public InteractionMessage(ResponseType responseType,bool? replaceOriginal = null)
        {
            ResponseType = responseType;
            ReplaceOriginal = replaceOriginal;
        }

        [JsonProperty("response_type"),JsonConverter(typeof(StringEnumConverter))]
        public ResponseType ResponseType { get; set; }

        [JsonProperty("replace_original",NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReplaceOriginal { get; set; }

        public async Task<WebApiResponse> Send(string responseUrl, HttpClient client = null)
        {
            var content = new StringContent(JsonConvert.SerializeObject(this), Encoding.UTF8, "application/json");
            var currentClient = client ?? new HttpClient();
            var response = await currentClient.PostAsync(new Uri(responseUrl, UriKind.Absolute), content);
            return JsonConvert.DeserializeObject<WebApiResponse>(await response.Content.ReadAsStringAsync());
        }
    }
}
