using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard
{
    public interface IWebApiClient
    {
        HttpClient Client { get; set; }
        JsonSerializer Serializer { get; set; }
    }
}
