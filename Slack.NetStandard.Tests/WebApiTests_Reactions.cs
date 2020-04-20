﻿using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Reactions
    {
        [Fact]
        public async Task Reactions_Add()
        {
            await Utility.AssertEncodedWebApi(c => c.Reactions.Add("C123","12345","test"), "reactions.add", nvc =>
            {
                Assert.Equal("C123", nvc["channel"]);
                Assert.Equal("12345", nvc["timestamp"]);
                Assert.Equal("test", nvc["name"]);
            });
        }

        [Fact]
        public async Task Reactions_Get()
        {
            await Utility.AssertEncodedWebApi(c => c.Reactions.Get("C123", "12345.6789",true), "reactions.get", "Web_ReactionsGet.json",nvc =>
            {
                Assert.Equal("C123", nvc["channel"]);
                Assert.Equal("12345.6789", nvc["timestamp"]);
                Assert.Equal("true", nvc["full"]);
            });
        }

        [Fact]
        public async Task Reactions_List()
        {
            await Utility.AssertEncodedWebApi(c => c.Reactions.List("C123", "12345", 10), "reactions.list","Web_MessageItems.json", nvc =>
            {
                Assert.Equal("C123", nvc["user"]);
                Assert.Equal("12345", nvc["cursor"]);
                Assert.Equal("10", nvc["limit"]);
            });
        }

        [Fact]
        public async Task Reactions_Remove()
        {
            await Utility.AssertEncodedWebApi(c => c.Reactions.Remove("C123", "12345", "test"), "reactions.remove", nvc =>
            {
                Assert.Equal("C123", nvc["channel"]);
                Assert.Equal("12345", nvc["timestamp"]);
                Assert.Equal("test", nvc["name"]);
            });
        }
    }
}