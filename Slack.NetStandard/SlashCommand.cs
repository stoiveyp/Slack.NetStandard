using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;

namespace Slack.NetStandard
{
    public class SlashCommand
    {
        public SlashCommand(string payloadText) : this(Parse(payloadText))
        {

        }

        public SlashCommand(Dictionary<string, string> payload)
        {
            Payload = payload;
        }

        private static Dictionary<string, string> Parse(string data)
        {
            var coll = HttpUtility.ParseQueryString(data);
            return coll.AllKeys.ToDictionary(k => k, k => coll[k]);
        }


        public Dictionary<string, string> Payload { get; }
    }
}
