using System;
using System.Collections.Generic;
using System.Text;
using Slack.NetStandard.EventsApi;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class EventsApiTests
    {
        [Fact]
        public void UrlVerification()
        {
            Utility.AssertSubType<Event,UrlVerification>("Events_UrlVerification.json");
        }
    }
}
