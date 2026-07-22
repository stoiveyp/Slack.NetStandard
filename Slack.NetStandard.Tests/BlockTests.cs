using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Messages.Blocks;
using Slack.NetStandard.Messages.Elements;
using Slack.NetStandard.Messages.Elements.RichText;
using Slack.NetStandard.Objects;
using System;
using System.Data.Common;
using System.Text.Json;
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
        public void Container()
        {
            Utility.AssertSubType<IMessageBlock, Container>("Blocks_Container.json");
        }
        
        [Fact]
        public void Callout()
        {
            Utility.AssertSubType<IMessageBlock, Callout>("Blocks_Callout.json");
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
            var element = Utility.AssertSubType<IMessageElement, RichTextInput>("Blocks_RichTextInput.json");
        }

        [Fact]
        public void RichTextPreformatted()
        {
            Utility.AssertSubType<RichTextElement, PreformattedElement>("Blocks_RichTextPreformatted.json");
        }

        [Fact]
        public void FileInput()
        {
            Utility.AssertSubType<IMessageElement, Files>("Blocks_Files.json");
        }

        [Fact]
        public void RichTextSection()
        {
            Utility.AssertSubType<IMessageBlock, RichText>("Blocks_RichTextSection.json");
        }

        [Fact]
        public void Markdown()
        {
            Utility.AssertSubType<IMessageBlock, Markdown>("Blocks_Markdown.json");
        }

        [Fact]
        public void ImageSlackFile()
        {
            var img = Utility.AssertSubType<IMessageBlock, Messages.Blocks.Image>("Blocks_ImageSlackFile.json");
            Assert.Equal("https://files.slack.com/files-pri/T0123456-F0123456/xyz.png", img.SlackFile.Url);
        }

        [Fact]
        public void ImageElementSlackFile()
        {
            var img = Utility.AssertSubType<IMessageElement, Messages.Elements.Image>("Blocks_ImageElementSlackFile.json");
            Assert.Equal("https://files.slack.com/files-pri/T0123456-F0123456/xyz.png", img.SlackFile.Url);
        }

        [Fact]
        public void RichTextElements()
        {
            var element = new TextElement { Text = "type check" };
            var json = JObject.FromObject(element);
            Assert.Equal("text", json.Value<string>("type"));
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
            var actual = new PlainTextInput()
            {
                DispatchActionConfig = new DispatchActionConfig(new ActionTrigger[] { ActionTrigger.OnEnterPressed })
            };

            Assert.True(JToken.DeepEquals(JObject.FromObject(actual), expected));

            var result = JsonConvert.DeserializeObject<PlainTextInput>(expected.ToString());
            Assert.Equal(ActionTrigger.OnEnterPressed, result.DispatchActionConfig.TriggerActionsOn[0]);
        }

        [Fact]
        public void SlackFiles()
        {
            var sfUrl = "https://files.slack.com/files-pri/T0123456-F0123456/xyz.png";
            var sfId = "F0123456";

            var file1 = new JObject(new JProperty("url", sfUrl));
            var file2 = new JObject(new JProperty("id", sfId));

            Assert.True(JToken.DeepEquals(JObject.FromObject(new SlackFile { Url = sfUrl }), file1));
            Assert.True(JToken.DeepEquals(JObject.FromObject(new SlackFile { Id = sfId }), file2));
        }

        [Fact]
        public void IconButton()
        {
            Utility.AssertSubType<IContextActionsElement, IconButton>("Blocks_IconButton.json");
        }

        [Fact]
        public void FeedbackButtons()
        {
            Utility.AssertSubType<IContextActionsElement, FeedbackButtons>("Blocks_FeedbackButtons.json");
        }

        [Fact]
        public void Table()
        {
            Utility.AssertSubType<IMessageBlock, Table>("Blocks_Table.json");
        }

        [Fact]
        public void TaskCard()
        {
            Utility.AssertSubType<IMessageBlock, TaskCard>("Blocks_TaskCard.json");
        }

        [Fact]
        public void Plan()
        {
            Utility.AssertSubType<IMessageBlock, Plan>("Blocks_Plan.json", "type");
        }

        [Fact]
        public void Alert()
        {
            Utility.AssertSubType<IMessageBlock, Alert>("Blocks_Alert.json");
        }

        [Fact]
        public void Card()
        {
            Utility.AssertSubType<IMessageBlock, Card>("Blocks_Card.json");
        }

        [Fact]
        public void Carousel()
        {
            Utility.AssertSubType<IMessageBlock, Carousel>("Blocks_Carousel.json");
        }

        [Fact]
        public void DataTable()
        {
            Utility.AssertSubType<IMessageBlock, DataTable>("Blocks_DataTable.json");
        }

        [Fact]
        public void DataVisualizationPie()
        {
            var visual = Utility.AssertSubType<IMessageBlock, DataVisualization>("Blocks_DataVisualization_Pie.json");
            var pie = Assert.IsType<PieChart>(visual.Chart);
            
            var json = JObject.Parse(Utility.ExampleFileContent("Blocks_DataVisualization_Pie.json"));
            Utility.CompareJson(pie,json.Value<JObject>("chart"));
        }

        [Fact]
        public void DataVisualizationBar()
        {
            var visual = Utility.AssertSubType<IMessageBlock, DataVisualization>("Blocks_DataVisualization_Bar.json");
            var bar = Assert.IsType<BarChart>(visual.Chart);

            var json = JObject.Parse(Utility.ExampleFileContent("Blocks_DataVisualization_Bar.json"));
            Utility.CompareJson(bar, json.Value<JObject>("chart"));
        }

        [Fact]
        public void DataVisualizationLine()
        {
            var visual = Utility.AssertSubType<IMessageBlock, DataVisualization>("Blocks_DataVisualization_Line.json");
            var line = Assert.IsType<LineChart>(visual.Chart);

            var json = JObject.Parse(Utility.ExampleFileContent("Blocks_DataVisualization_Line.json"));
            Utility.CompareJson(line, json.Value<JObject>("chart"));
        }

        [Fact]
        public void DataVisualizationArea()
        {
            var visual = Utility.AssertSubType<IMessageBlock, DataVisualization>("Blocks_DataVisualization_Area.json");
            var area = Assert.IsType<AreaChart>(visual.Chart);

            var json = JObject.Parse(Utility.ExampleFileContent("Blocks_DataVisualization_Area.json"));
            Utility.CompareJson(area, json.Value<JObject>("chart"));
        }
    }
}
