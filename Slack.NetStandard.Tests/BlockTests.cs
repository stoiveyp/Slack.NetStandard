using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.MessageBlocks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class BlockTests
    {
        [Fact]
        public void DividerGeneratesCorrectJson()
        {
            var expected = new JObject(new JProperty("type", "divider"), new JProperty("block_id", "test"));
            var actual = new Divider("test");
            Assert.True(JToken.DeepEquals(JObject.FromObject(actual), expected));
        }
    }
}
