﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Pins;

namespace Slack.NetStandard.WebApi
{
    internal class PinsApi : IPinsApi
    {
        private readonly IWebApiClient _client;

        public PinsApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<WebApiResponse> Add(string channel, Timestamp timestamp)
        {
            return _client.MakeUrlEncodedCall("pins.add", new Dictionary<string, string>
            {
                {"channel", channel},
                {"timestamp", timestamp}
            });
        }

        public Task<WebApiResponse> Remove(string channel, Timestamp timestamp)
        {
            return _client.MakeUrlEncodedCall("pins.remove", new Dictionary<string, string>
            {
                {"channel", channel},
                {"timestamp", timestamp}
            });
        }

        public Task<PinnedListResponse> List(string channel)
        {
            return _client.MakeUrlEncodedCall<PinnedListResponse>("pins.list", new Dictionary<string, string>
            {
                {"channel", channel}
            });
        }
    }
}