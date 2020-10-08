using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Messages;
using Slack.NetStandard.Messages.Blocks;
using Slack.NetStandard.Messages.Elements;
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

            var result = JsonConvert.DeserializeObject<IMessageBlock>(expected.ToString());
            Assert.IsType<Divider>(result);
        }

        [Fact]
        public void MarkdownTextGeneratedCorrectly()
        {
            var original = new JObject(new JProperty("type", "mrkdwn"), new JProperty("text", "testing 1.2.3"));
            var text = JsonConvert.DeserializeObject<TextObject>(original.ToString());
            var mrkdwn = Assert.IsType<MarkdownText>(text);
            JToken.DeepEquals(JObject.FromObject(mrkdwn), original);
            Assert.Equal("testing 1.2.3", mrkdwn.Text);
        }

        [Fact]
        public void RadioButtons()
        {
            Utility.AssertSubType<IMessageElement, RadioButtons>("Blocks_RadioButtons.json");
        }

        [Fact]
        public void StaticSelect()
        {
            Utility.AssertSubType<IMessageElement, StaticSelect>("Blocks_StaticSelect.json");
        }

        [Fact]
        public void Checkboxes()
        {
            Utility.AssertSubType<IMessageElement, Checkboxes>("Blocks_Checkboxes.json");
        }
    }
}
