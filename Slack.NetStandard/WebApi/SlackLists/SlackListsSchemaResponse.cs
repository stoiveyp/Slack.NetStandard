using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public class SlackListsSchemaResponse: SlackListsSchema
    {
        public SlackListsSchemaResponse():base() { }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
