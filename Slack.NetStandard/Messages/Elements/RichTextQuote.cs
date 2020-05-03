using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.Messages.Elements.RichText;

namespace Slack.NetStandard.Messages.Elements
{
    public class RichTextQuote : IMessageElement
    {
        public const string ElementType = "rich_text_quote";
        public string Type => ElementType;

        [JsonProperty("elements", NullValueHandling = NullValueHandling.Ignore)]
        public IList<RichTextElement> Elements { get; set; }
    }
}
