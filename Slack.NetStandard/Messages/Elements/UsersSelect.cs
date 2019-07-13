using System.Collections.Generic;
using System.Xml.Schema;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements
{
    public class UsersSelect:IMessageElement
    {
        [JsonProperty("type")] public string Type => "users_select";

        [JsonProperty("placeholder")]
        public PlainText Placeholder { get; set; }

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        [JsonProperty("initial_user",NullValueHandling = NullValueHandling.Ignore)]
        public string InitialUser { get; set; }

        [JsonProperty("confirm",NullValueHandling = NullValueHandling.Ignore)]
        public Confirmation Confirm { get; set; }
    }
}