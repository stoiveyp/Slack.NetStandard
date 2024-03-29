﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Bots;

namespace Slack.NetStandard.WebApi
{
    internal class BotsApi : IBotsApi
    {
        private readonly IWebApiClient _client;

        public BotsApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<InfoResponse> Info(string bot = null, string teamId = null)
        {
            var dict = new Dictionary<string, string>().AddIfValue("bot", bot).AddIfValue("team_id", teamId);
            return _client.MakeUrlEncodedCall<InfoResponse>("bots.info", dict);
        }
    }
}