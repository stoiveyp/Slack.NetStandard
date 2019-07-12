using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.Messages.Elements
{
    public class Image:IContextElement,IMessageElement
    {
        public string Type => nameof(Image).ToLower();

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("alt_text")]
        public string AltText { get; set; }
    }
}
