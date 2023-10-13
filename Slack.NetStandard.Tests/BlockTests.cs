using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Messages.Blocks;
using Slack.NetStandard.Messages.Elements;
using System;
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
        public void Header()
        {
            Utility.AssertSubType<IMessageBlock, Header>("Blocks_Header.json");
        }

        [Fact]
        public void Call()
        {
            Utility.AssertSubType<IMessageBlock, Call>("Blocks_Call.json");
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

        [Fact]
        public void Timepicker()
        {
            Utility.AssertSubType<IMessageElement, TimePicker>("Blocks_TimePicker.json");
        }

        [Fact]
        public void Video()
        {
            Utility.AssertSubType<IMessageBlock, Video>("Blocks_Video.json");
        }

        [Fact]
        public void Url()
        {
            Utility.AssertSubType<IMessageElement, Url>("Blocks_Url.json");
        }

        [Fact]
        public void Email()
        {
            Utility.AssertSubType<IMessageElement, Email>("Blocks_Email.json");
        }

        [Fact]
        public void Number()
        {
            Utility.AssertSubType<IMessageElement, Number>("Blocks_Number.json");
        }

        [Fact]
        public void DateTimePicker()
        {
            Utility.AssertSubType<IMessageElement, DateTimePicker>("Blocks_DateTimePicker.json");
        }

        [Fact]
        public void RichTextInput()
        {
            Utility.AssertSubType<IMessageElement, RichTextInput>("Blocks_RichTextInput.json");
        }

        [Fact]
        public void OptionExtensions()
        {
            IOption option = new Option();
            Assert.NotNull(option.AsOption());
            Assert.Null(option.AsOptionGroup());

            IOption optionGroup = new OptionGroup();
            Assert.Null(optionGroup.AsOption());
            Assert.NotNull(optionGroup.AsOptionGroup());
        }

        [Fact]
        public void PlainTextInputElementSupportsDispatchConfig()
        {
            var expected = new JObject(
                new JProperty("type", "plain_text_input"),
                new JProperty("dispatch_action_config", new JObject(
                    new JProperty("trigger_actions_on", new JArray("on_enter_pressed"))
                    )
                )
			);
            var actual = new PlainTextInput() {
                DispatchActionConfig = new DispatchActionConfig(new ActionTrigger[] { ActionTrigger.OnEnterPressed })
            };

            Assert.True(JToken.DeepEquals(JObject.FromObject(actual), expected));

            var result = JsonConvert.DeserializeObject<PlainTextInput>(expected.ToString());
            Assert.Equal(ActionTrigger.OnEnterPressed, result.DispatchActionConfig.TriggerActionsOn[0]);
        }
    }
}
